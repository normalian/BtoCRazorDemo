using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Tests.Models
{
    using BtoCRazorDemo.Models;

    public class TestCategoryRepository : ICategoryRepository<Category>
    {
        IList<Category> pool = new List<Category>();

        public TestCategoryRepository()
        {
            //var category1Pool = new EntitySet<Product>();
            //var category2Pool = new EntitySet<Product>();
            //pool.Add(new Category() { CategoryID = 1, CategoryName = "Test01", Products = category1Pool });
            //pool.Add(new Category() { CategoryID = 2, CategoryName = "Test02", Products = category2Pool });

            //category1Pool.Add(new Product()
            //{
            //    CategoryID = 1,
            //    Description = "Test01",
            //    ImageFileUrl = "Test01.png",
            //    Price = 1000,
            //    ProductID = 1,
            //    ProductName = "Test01"
            //});
            //category1Pool.Add(new Product()
            //{
            //    CategoryID = 1,
            //    Description = "Test02",
            //    ImageFileUrl = "Test02.png",
            //    Price = 1000,
            //    ProductID = 2,
            //    ProductName = "Test02"
            //});

            //category2Pool.Add(new Product()
            //{
            //    CategoryID = 2,
            //    Description = "Test11",
            //    ImageFileUrl = "Test11.png",
            //    Price = 1000,
            //    ProductID = 11,
            //    ProductName = "Test011"
            //});
            //category2Pool.Add(new Product()
            //{
            //    CategoryID = 2,
            //    Description = "Test12",
            //    ImageFileUrl = "Test12.png",
            //    Price = 1000,
            //    ProductID = 12,
            //    ProductName = "Test012"
            //});

        }

        public IQueryable<Category> GetAll()
        {
            return pool.AsQueryable();
        }

        public Category GetByID(int id)
        {
            var inst = pool.SingleOrDefault(category => category.CategoryID == id);
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
            return pool.SingleOrDefault(category => category.CategoryName == name);
        }

        public void Add(Category category)
        {
            pool.Add(category);
        }

        public void Remove(Category category)
        {
            pool.Remove(category);
        }

        public void Save()
        {
        }
    }
}
