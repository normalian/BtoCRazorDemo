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
        readonly protected BtoCDataClassesDataContext dataContext;

        public CategoryRepository()
        {
            dataContext = new BtoCDataClassesDataContext();
        }

        public IQueryable<Category> GetAll()
        {
            return dataContext.Categories.AsQueryable();
        }

        public Category GetByID(int id)
        {
            var inst = dataContext.Categories.SingleOrDefault(category => category.CategoryID == id);
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
            return dataContext.Categories.SingleOrDefault(category => category.CategoryName == name);
        }

        public void Add(Category category)
        {
            dataContext.Categories.InsertOnSubmit(category);
        }

        public void Remove(Category category)
        {
            dataContext.Categories.DeleteOnSubmit(category);
        }

        public void Save()
        {
            dataContext.SubmitChanges();
        }
    }
}
