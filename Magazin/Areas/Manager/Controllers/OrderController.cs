using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Magazin.Areas.Manager.Models;
using BusinessLayer.Domain;
using Service.Services;
using Magazin.Controllers;
namespace Magazin.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class OrderController : MyController
    {
        public IOrderService orderService;
        public IStatusService statusService;
        public OrderController(IOrderService orderService, IStatusService statusService)
        {
            this.orderService = orderService;
            this.statusService = statusService;
        }

        public List<SelectListItem> GetSelectList(Guid statusId)
        {
            var statuses = statusService.GetStatuses();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var status in statuses)
            {
                list.Add(new SelectListItem()
                {
                    Text = status.Name,
                    Value = status.StatusId.ToString(),
                    Selected = (status.StatusId == statusId ? true : false)
                });
            }
            return list;
        }

        public ActionResult Index()
        {
            IEnumerable<Order> orders = orderService.GetOrders();
            var orderLMs = Mapper.Map<IEnumerable<Order>, List<OrderListModel>>(orders);
            return View(orderLMs);
        }

        public ActionResult Details(int code)
        {
            Order order = orderService.GetOrderByCode(code);
            var orderVM = Mapper.Map<Order, OrderViewModel>(order);
            return View(orderVM);
        }

        public ActionResult Edit(int code)
        {
            Order order = orderService.GetOrderByCode(code);
            OrderEditModel orderEM = Mapper.Map<Order,OrderEditModel>(order);
            orderEM.StatusList = GetSelectList(order.StatusId);
            return View(orderEM);
        }

        [HttpPost]
        public ActionResult Edit(OrderEditModel editModel)
        {
            Order order = orderService.GetOrderByCode(editModel.OrderNumber);
            order.ShipmentDate = editModel.ShipmentDate;
            order.StatusId = Guid.Parse(editModel.StatusId);
            orderService.EditOrder(order);
            return RedirectToAction("Index");
        }
    }
}