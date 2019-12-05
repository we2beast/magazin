using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin.Models;
using BusinessLayer.Domain;
using Service.Services;
using Magazin.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace Magazin.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : MyController
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        private IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<ActionResult>  MyOrders()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IEnumerable<Order> orders = orderService.GetOrdersByCustomer(user.UserName);
                var orderLMs = Mapper.Map<IEnumerable<Order>, List<MyOrdersModel>>(orders);
                return View(orderLMs);
            }
            return View();
        }
        public ActionResult DetailsMyOrder(int code)
        {
                Order order = orderService.GetOrderByCode(code);
                var orderVM = Mapper.Map<Order, MyOrderViewModel>(order);
                return View(orderVM);
        }

        public ActionResult CancalOrder(int code)
        {
            orderService.DeleteOrder(code);
            return RedirectToAction("MyOrders");
        }

        public async Task<ActionResult> Create()
        {      
           ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                var cart = GetCart();
                var lines = cart.Lines.ToList();
                var orderItems = new List<OrderItem>();
                foreach (var line in lines)
                {
                    var orderItem = new OrderItem
                    {
                        ItemId = line.Item.ItemId,
                        Item = line.Item,
                        ItemCount = line.Quantity,
                        ItemPrice = (decimal)line.Item.Price,
                    };
                    orderItems.Add(orderItem);
                }
                orderService.CreateOrder(orderItems, user.Email);

                Session["Cart"] = null;

                return RedirectToAction("Index", "Item");
            }
            return View();
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            return cart;
        }
    }
}