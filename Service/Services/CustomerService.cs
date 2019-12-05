using System;
using System.Collections.Generic;
using BusinessLayer.Domain;
using DataLayer;

namespace Service.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByCode(string code);
        void CreateCustomer(Customer obj);
        void EditCustomer(Customer obj);
        void DeleteCustomer(string code);
    }

    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork unitOfWork;
        public CustomerService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = unitOfWork.CustomerRepository.Get();
            return customers;
        }

        public Customer GetCustomerByCode(string code)
        {
            var customer = unitOfWork.CustomerRepository.Find(n=>n.Code==code);
           
            return customer;
        }
        #region GenerateCode
        public string GenerateCode()
        {
            bool check = false;
            string fullCode = "";

            while (!check)
            {
                Random rnd = new Random();      
                fullCode = (rnd.Next(1000, 9999).ToString()+"-"+DateTime.Now.Year.ToString()).ToString();
                check = CheckCode(fullCode);
            }
            return fullCode;
        }
        
        public bool CheckCode(string code)
        {
            bool isUnique = false;
            Customer customer = unitOfWork.CustomerRepository.Find(c => c.Code == code);
            if (customer == null)
                isUnique = true;
            else isUnique = false;
            return isUnique;
        }
        #endregion

        public void CreateCustomer(Customer obj)
        {
            obj.CustomerId = Guid.NewGuid();
            obj.Code = GenerateCode();
            unitOfWork.CustomerRepository.Insert(obj);
        }
        
        public void EditCustomer(Customer obj)
        {
            unitOfWork.CustomerRepository.Update(obj);
        }

        public void DeleteCustomer(string code)
        {
            Customer Customer = unitOfWork.CustomerRepository.Find(c => c.Code == code);
            unitOfWork.CustomerRepository.Delete(Customer);
        }
    }
}
