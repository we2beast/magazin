using System;
using System.Collections.Generic;
using BusinessLayer.Domain;
using DataLayer;
namespace Service.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(Guid id);
        Category GetCategoryByName(string name);
        void CreateCategory(Category obj);
        void EditCategory(Category obj);
        void DeleteCategory(Guid id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork unitOfWork;
        public CategoryService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = unitOfWork.CategoryRepository.Get();
            return categories;
        }

        public Category GetCategoryById(Guid id)
        {
            var categories = unitOfWork.CategoryRepository.GetByID(id);
            return categories;
        }
        public Category GetCategoryByName(string name)
        {
            var category = unitOfWork.CategoryRepository.Find(n=>n.Name==name);
            return category;
        }
        public void CreateCategory(Category obj)
        {
            obj.CategoryId = Guid.NewGuid();
            unitOfWork.CategoryRepository.Insert(obj);
        }
        
        public void EditCategory(Category obj)
        {
            unitOfWork.CategoryRepository.Update(obj);
        }

        public void DeleteCategory(Guid id)
        {
            var categorie = unitOfWork.CategoryRepository.GetByID(id);
            unitOfWork.CategoryRepository.Delete(categorie);
        }
    }
}
