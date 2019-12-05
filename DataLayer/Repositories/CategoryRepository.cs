using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLayer.Domain;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public interface ICategoryRepository
    {
        Category Find(Expression<Func<Category, bool>> query);
        IEnumerable<Category> Get();
        Category GetByID(Guid id);
        void Insert(Category obj);
        void Update(Category obj);
        void Delete(Category obj);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private EFDBContex context;
        public CategoryRepository(EFDBContex contex)
        {
            this.context = contex;
        }
        public Category Find(Expression<Func<Category, bool>> query)
        {
            return context.Set<Category>().FirstOrDefault(query);
        }
        public IEnumerable<Category> Get()
        {
            var query = context.Categories.ToList();
            return query;
        }

        public Category GetByID(Guid id)
        {
            var query = context.Categories.Find(id);
            return query;
        }

        public void Insert(Category obj)
        {
            context.Categories.Add(obj);
            context.SaveChanges();
        }

        public void Update(Category obj)
        {
            context.Categories.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Category obj)
        {
            context.Categories.Remove(obj);
            context.SaveChanges();
        }
    }
}
