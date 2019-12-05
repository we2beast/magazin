using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Domain;

namespace DataLayer.Repositories
{
    public interface ICustomerRepository
    {
        Customer Find(Expression<Func<Customer, bool>> query);
        IEnumerable<Customer> Get();
        Customer GetById(Guid code);
        void Insert(Customer obj);
        void Update(Customer obj);
        void Delete(Customer obj);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private EFDBContex context;
        public CustomerRepository(EFDBContex contex)
        {
            this.context = contex;
        }

        public Customer Find(Expression<Func<Customer, bool>> query)
        {
            return context.Set<Customer>().FirstOrDefault(query);
        }

        public IEnumerable<Customer> Get()
        {
            var query = context.Customers.ToList();
            return query;
        }

        public Customer GetById(Guid id)
        {
            var query = context.Customers.Find(id);
            return query;
        }
      
        public void Insert(Customer obj)
        {
            context.Customers.Add(obj);
            context.SaveChanges();
        }

        public void Update(Customer obj)
        {
         
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Customer obj)
        {                     
            context.Customers.Remove(obj);
            context.SaveChanges();
        }
    }
}
