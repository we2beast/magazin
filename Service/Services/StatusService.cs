using System;
using System.Collections.Generic;
using BusinessLayer.Domain;
using DataLayer;
namespace Service.Services
{
    public interface IStatusService
    {
        IEnumerable<Status> GetStatuses();
        Status GetStatusById(Guid id);
        Status GetStatusByName(string name);
        void CreateStatus(Status obj);
        //void EditStatus(Status obj);
        //void DeleteStatus(Guid id);
    }

    public class StatusService : IStatusService
    {
        private readonly UnitOfWork unitOfWork;
        public StatusService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Status> GetStatuses()
        {
            var statuses = unitOfWork.StatusRepository.Get();
            return statuses;
        }

        public Status GetStatusById(Guid id)
        {
            var status = unitOfWork.StatusRepository.GetByID(id);
            return status;
        }
        public Status GetStatusByName(string name)
        {
            var status = unitOfWork.StatusRepository.Find(n => n.Name == name);
            return status;
        }
        public void CreateStatus(Status obj)
        {
            obj.StatusId = Guid.NewGuid();
            unitOfWork.StatusRepository.Insert(obj);
        }

        public void DeleteStatus(Status obj)
        {
            unitOfWork.StatusRepository.Update(obj);
        }

        public void DeleteCategory(Guid id)
        {
            var categorie = unitOfWork.StatusRepository.GetByID(id);
            unitOfWork.StatusRepository.Delete(categorie);
        }
    }
}
