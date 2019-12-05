using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLayer.Domain;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public interface IStatusRepository
    {
        Status Find(Expression<Func<Status, bool>> query);
        IEnumerable<Status> Get();
        Status GetByID(Guid id);
        void Insert(Status obj);
        void Update(Status obj);
        void Delete(Status obj);
    }
    public class StatusRepository : IStatusRepository
    {
        private EFDBContex context;
        public StatusRepository(EFDBContex contex)
        {
            this.context = contex;
        }
        public Status Find(Expression<Func<Status, bool>> query)
        {
            return context.Set<Status>().FirstOrDefault(query);
        }
        public IEnumerable<Status> Get()
        {
            var query = context.Statuses.ToList();
            return query;
        }

        public Status GetByID(Guid id)
        {
            var query = context.Statuses.Find(id);
            return query;
        }

        public void Insert(Status obj)
        {
            context.Statuses.Add(obj);
            context.SaveChanges();
        }

        public void Update(Status obj)
        {
            context.Statuses.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Status obj)
        {
            context.Statuses.Remove(obj);
            context.SaveChanges();
        }
    }
}
