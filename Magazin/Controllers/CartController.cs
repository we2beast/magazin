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
    public class CartController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        public IItemService itemService;
        public CartController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public async Task<ActionResult> AddToCart(string code, string returnUrl)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            Item item = itemService.GetItemByCodeWithDiscount(code, user.UserName);

            if (item != null)
            {
                GetCart().AddItem(item, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(Cart cart, string code)
        {
            Item item = itemService.GetItemByCode(code);

            if (item != null)
            {
                cart.RemoveLine(item);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}