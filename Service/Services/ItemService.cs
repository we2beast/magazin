using System;
using System.Collections.Generic;
using BusinessLayer.Domain;
using DataLayer;
namespace Service.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetItemsWithDiscount(string username);
        Item GetItemByCode(string code);
        Item GetItemByCodeWithDiscount(string code, string username);
        void CreateItem(Item obj);
        void EditItem(Item obj);
        void DeleteItem(string code);
    }

    public class ItemService : IItemService
    {
        private readonly UnitOfWork unitOfWork;
  
        public ItemService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
           
        }

        public Item GetItemByCodeWithDiscount(string code, string username)
        {
            IEnumerable<Item> items = unitOfWork.ItemRepository.Get();
            Customer customer = unitOfWork.CustomerRepository.Find(c => c.UserName == username);
            var item = unitOfWork.ItemRepository.Find(c => c.Code == code);
            item.Price= (item.Price * (100 - customer.Discount)) / 100;
            return item;
        }
        public IEnumerable<Item> GetItems()
        {
            var items = unitOfWork.ItemRepository.Get();
            return items;
        }
        public IEnumerable<Item> GetItemsWithDiscount(string username)
        {
            IEnumerable<Item> items = unitOfWork.ItemRepository.Get();
            Customer customer = unitOfWork.CustomerRepository.Find(c => c.UserName == username);
            foreach (var item in items)
            {
                item.Price = (item.Price * (100-customer.Discount))/100;  
            }
            return items;
        }
        public Item GetItemByCode(string code)
        {
            var item = unitOfWork.ItemRepository.Find(c=>c.Code==code);
            return item;
        }

        public void CreateItem(Item obj)
        {
            obj.ItemId = Guid.NewGuid();
            obj.Code = GenerateCode();
            unitOfWork.ItemRepository.Insert(obj);
        }

        #region GenerateCode
        public string GenerateCode()
        {
            bool check = false;
            int value1;
            int value2;
            string value3;
            int value4;
            string fullCode = "";

            while (!check)
            {
                Random rnd = new Random();
                value1 = rnd.Next(10, 99);
                value2 = rnd.Next(1000, 9999);
                value3 = RandomString();
                value4 = rnd.Next(10, 99);
                fullCode = (value1.ToString() + "-" + value2.ToString() + "-" + value3 + value4.ToString()).ToString();
                check = CheckCode(fullCode);
            }
            return fullCode;
        }
        public string RandomString()
        {
            Random rand = new Random();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string word = "";
            for (int j = 0; j < 2; j++)
            {
                char lette = Convert.ToChar(letters[rand.Next(0, 25)]);
                word += lette;
            }
            return word;
        }
        public bool CheckCode(string code)
        {
            bool isUnique = false;
            Item itemDB = unitOfWork.ItemRepository.Find(c => c.Code == code); 
            if (itemDB == null)
                isUnique = true;
            else isUnique = false;
            return isUnique;
        }
        #endregion


        public void EditItem(Item obj)
        {
            unitOfWork.ItemRepository.Update(obj);
        }

        public void DeleteItem(string code)
        {
            var item = unitOfWork.ItemRepository.Find(c=>c.Code==code);
            unitOfWork.ItemRepository.Delete(item);
        }
    }
}
