using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Tests.Models
{
    using BtoCRazorDemo.Models;


    public class TestProductRepository : IProductRepository<Product>
    {
        IList<Product> pool = new List<Product>();

        public TestProductRepository()
        {
            pool.Add(new Product()
            {
                CategoryID = 1,
                Description = "Test01",
                ImageFileUrl = "Test01.png",
                Price = 1000,
                ProductID = 1,
                ProductName = "Test01"
            });
            pool.Add(new Product()
            {
                CategoryID = 1,
                Description = "Test02",
                ImageFileUrl = "Test02.png",
                Price = 1000,
                ProductID = 2,
                ProductName = "Test02"
            });

            pool.Add(new Product()
            {
                CategoryID = 2,
                Description = "Test11",
                ImageFileUrl = "Test11.png",
                Price = 1000,
                ProductID = 11,
                ProductName = "Test011"
            });
            pool.Add(new Product()
            {
                CategoryID = 2,
                Description = "Test12",
                ImageFileUrl = "Test12.png",
                Price = 1000,
                ProductID = 12,
                ProductName = "Test012"
            });
        }

        public IQueryable<Product> GetAll()
        {
            return pool.AsQueryable();
        }

        public Product GetByID(int id)
        {
            return pool.SingleOrDefault(product => product.ProductID == id);
        }

        public Product GetByName(string name)
        {
            return pool.SingleOrDefault(product => product.ProductName == name);
        }

        public void Add(Product order)
        {
            pool.Add(order);
        }

        public void Remove(Product order)
        {
            pool.Remove(order);
        }

        public void Save()
        {
        }
    }
}
