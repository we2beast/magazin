using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Domain;
using DataLayer;
namespace Service.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrdersByCustomer(string username);
        Order GetOrderByCode(int code);
        void CreateOrder(List<OrderItem> orderItems,string email);
        void EditOrder(Order obj);
        void DeleteOrder(int code);
    }

    public class OrderService : IOrderService
    {
        private readonly UnitOfWork unitOfWork;
        public OrderService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = unitOfWork.OrderRepository.Get();
            return orders;
        }

        public IEnumerable<Order> GetOrdersByCustomer(string username)
        {
            var orders = unitOfWork.OrderRepository.GetMany(x=>x.Customer.UserName== username);
            return orders;
        }
        public Order GetOrderByCode(int code)
        {
            var order = unitOfWork.OrderRepository.GetByCode(code);
            order.Total = (from items in order.OrderItems
                            select items).Sum(e => (decimal)e.Item.Price * e.ItemCount);
            return order;
        }

        #region GenerateCode
        public int GenerateCode()
        {
            bool check = false;
            int OrderNumber = 0;
            while (!check)
            {
                Random rnd = new Random();
                OrderNumber = rnd.Next(1000, 9999);
                check = CheckCode(OrderNumber);
            }
            return OrderNumber;
        }

        public bool CheckCode(int code)
        {
            bool isUnique = false;
            Order order = unitOfWork.OrderRepository.GetByCode(code);
            if (order == null)
                isUnique = true;
            else isUnique = false;
            return isUnique;
        }
        #endregion

        public void CreateOrder(List<OrderItem> orderItems, string email)
        {
            Order order = new Order();
            order.OrderId = Guid.NewGuid();
            order.OrderNumber = GenerateCode();
            order.OrderDate = DateTime.Now;
            order.Status = unitOfWork.StatusRepository.Find(c => c.Name == "Новый");
            order.Customer = unitOfWork.CustomerRepository.Find(e=>e.UserName==email);
         
            List<OrderItem> items = new List<OrderItem>();
            foreach (OrderItem line in orderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderItemId = Guid.NewGuid(),
                    OrderId = order.OrderId,
                    ItemId = line.ItemId,
                    ItemCount = line.ItemCount,
                    ItemPrice = line.ItemPrice  
                };
                items.Add(orderItem);
            }
            order.OrderItems = items;

            unitOfWork.OrderRepository.Insert(order);
        }
        
        public void EditOrder(Order obj)
        {
            unitOfWork.OrderRepository.Update(obj);
        }

        public void DeleteOrder(int code)
        {
           Order order= unitOfWork.OrderRepository.GetByCode(code);
           unitOfWork.OrderRepository.Delete(order);
        }
    }
}
