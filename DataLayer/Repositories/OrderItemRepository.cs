using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLayer.Domain;

namespace DataLayer.Repositories
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> Get();
        IEnumerable<OrderItem> GetByOrder(Guid id);
        void InsertList(IEnumerable<OrderItem> obj);
        void Delete(Guid id);
    }
    public class OrderItemRepository : IOrderItemRepository
    {
        private EFDBContex context;
        public OrderItemRepository(EFDBContex contex)
        {
            this.context = contex;
        }
       
        public IEnumerable<OrderItem> Get()
        {
            var query = context.OrderItems.ToList();
            return query;
        }

        public void Delete(Guid id)
        {
            OrderItem orderItem = context.OrderItems.Find(id);
            context.OrderItems.Remove(orderItem);
            context.SaveChanges();
        }

        public void InsertList(IEnumerable<OrderItem> obj)
        {
            foreach (var orderItem in obj)
            {
                context.OrderItems.Add(orderItem);
            }
            context.SaveChanges();
        }

        public IEnumerable<OrderItem> GetByOrder(Guid id)
        {
            IEnumerable<OrderItem> orderItems = (from c in context.OrderItems
                                                 where c.OrderId == id
                                                 select c).ToList();
            return orderItems;
        }
    }
}
