using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Models
{
    public interface IProductRepository<T>
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        T GetByName(string name);
        void Add(T category);
        void Remove(T category);
        void Save();
    }


    public class ProductRepository : IProductRepository<Product>
    {
        readonly protected B2CDbEntities dbEntities;

        public ProductRepository()
        {
            dbEntities = new B2CDbEntities();
        }

        public IQueryable<Product> GetAll()
        {
            return dbEntities.Products.AsQueryable();
        }

        public Product GetByID(int id)
        {
            var inst = dbEntities.Products.SingleOrDefault(product => product.ProductID == id);
            if (inst == null)
            {
                throw new ArgumentOutOfRangeException("productIDが範囲外です");
            }
            return inst;
        }

        public Product GetByName(string name)
        {
            return dbEntities.Products.SingleOrDefault(product => product.ProductName == name);
        }

        public void Add(Product product)
        {
            dbEntities.Products.AddObject(product);
        }

        public void Remove(Product product)
        {
            dbEntities.Products.DeleteObject(product);
        }

        public void Save()
        {
            dbEntities.SaveChanges();
        }
    }
}
