using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService
    {
        private readonly UnitOfWork unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CategoryAddDto Add(CategoryAddDto payload)
        {
            if (payload == null) return null;

            if (payload == null) return null;

            var hasNameConflict = unitOfWork.Categories
                .Any(c => c.Name == payload.Name);

            if (hasNameConflict) return null;

            var newCategory = new Category
            {
                Name = payload.Name,
                Warranty = payload.Warranty,
                Cars = new List<Car>()
            };

            unitOfWork.Categories.Insert(newCategory);
            unitOfWork.SaveChanges();

            return payload;
        }

        public List<Category> GetAll()
        {
            var results = unitOfWork.Categories.GetAll().ToList();

            return results;
        }

        public bool Delete(int categoryId)
        {
            var category = unitOfWork.Categories.GetById(categoryId);
            if (category == null) return false;

            unitOfWork.Categories.Remove(category);
            unitOfWork.SaveChanges();
            return true;
        }

    }
}
