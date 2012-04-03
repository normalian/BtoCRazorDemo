using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Models
{
    public interface ICategoryRepository<T>
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        T GetByName(string name);
        void Add(T category);
        void Remove(T category);
        void Save();
    }

    public class CategoryRepository : ICategoryRepository<Category>
    {
        readonly protected B2CDbEntities dbEntities;

        public CategoryRepository()
        {
            dbEntities = new B2CDbEntities();
        }

        public IQueryable<Category> GetAll()
        {
            return dbEntities.Categories.AsQueryable();
        }

        public Category GetByID(int id)
        {
            var inst = dbEntities.Categories.SingleOrDefault(category => category.CategoryID == id);
            if (inst == null)
            {
                throw new ArgumentOutOfRangeException("categoryIDが不正だと思われる");
            }
            return inst;
        }

        public Category GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("名前がNULLか空白です");
            }
            return dbEntities.Categories.SingleOrDefault(category => category.CategoryName == name);
        }

        public void Add(Category category)
        {
            dbEntities.AddToCategories(category);
        }

        public void Remove(Category category)
        {
            dbEntities.Categories.DeleteObject(category);
        }

        public void Save()
        {
            dbEntities.SaveChanges();
        }
    }
}
