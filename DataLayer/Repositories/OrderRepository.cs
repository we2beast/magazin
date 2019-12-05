using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Domain;

namespace DataLayer.Repositories
{
    public interface IOrderRepository
    {
        Order Find(Expression<Func<Order, bool>> query);
        IEnumerable<Order> Get();
        IEnumerable<Order> GetMany(Expression<Func<Order, bool>> where);
        Order GetByCode(int code);
        void Insert(Order obj);
        void Update(Order obj);
        void Delete(Order obj);
    }
    public class OrderRepository : IOrderRepository
    {
        private EFDBContex context;
        public OrderRepository(EFDBContex contex)
        {
            this.context = contex;
        }
        public IEnumerable<Order> GetMany(Expression<Func<Order, bool>> where)
        {
            return context.Orders.Where(where).ToList();
        }
        public Order Find(Expression<Func<Order, bool>> query)
        {
            return context.Set<Order>().FirstOrDefault(query);
        }

        public IEnumerable<Order> Get()
        {
            var query = context.Orders.ToList();
            return query;
        }

        public Order GetByCode(int code)
        {
            var query = context.Orders.Where(s => s.OrderNumber == code).FirstOrDefault();
            return query;
        }

        public void Insert(Order obj)
        {
            context.Orders.Add(obj);
            context.SaveChanges();
        }

        public void Update(Order obj)
        {
           
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Order obj)
        {
            context.Orders.Remove(obj);
            context.SaveChanges();
        }
    }
}
