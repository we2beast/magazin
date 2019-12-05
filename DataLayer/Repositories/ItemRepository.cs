using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Domain;

namespace DataLayer.Repositories
{
    public interface IItemRepository
    {
        Item Find(Expression<Func<Item, bool>> query);
        IEnumerable<Item> Get();
        IEnumerable<Item> GetMany(Expression<Func<Item, bool>> where);
        void Insert(Item obj);
        void Update(Item obj);
        void Delete(Item obj);
    }

    public class ItemRepository : IItemRepository
    { 
        private EFDBContex context;
        public ItemRepository(EFDBContex contex)
        {
            this.context = contex;
        }

        public Item Find(Expression<Func<Item, bool>> query)
        {          
            return context.Set<Item>().FirstOrDefault(query);
        }
         
        public IEnumerable<Item> Get()
        {
            var query = context.Items.ToList();
            return query;
        }

        public  IEnumerable<Item> GetMany(Expression<Func<Item, bool>> where)
        {
            return context.Items.Where(where).ToList();
        }

        public void Insert(Item obj)
        {
            context.Items.Add(obj);
            context.SaveChanges();
        }

        public void Update(Item obj)
        { 
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    
        public void Delete(Item obj)
        {
            context.Items.Remove(obj);
            context.SaveChanges();
        }
    }
}
