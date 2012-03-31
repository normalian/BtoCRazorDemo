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
        readonly protected BtoCDataClassesDataContext dataContext;

        public ProductRepository()
        {
            dataContext = new BtoCDataClassesDataContext();
        }

        public IQueryable<Product> GetAll()
        {
            return dataContext.Products.AsQueryable();
        }

        public Product GetByID(int id)
        {
            var inst = dataContext.Products.SingleOrDefault(product => product.ProductID == id);
            if (inst == null)
            {
                throw new ArgumentOutOfRangeException("productIDが不正だと思われる");
            }
            return inst;
        }

        public Product GetByName(string name)
        {
            return dataContext.Products.SingleOrDefault(product => product.ProductName == name);
        }

        public void Add(Product product)
        {
            dataContext.Products.InsertOnSubmit(product);
        }

        public void Remove(Product product)
        {
            dataContext.Products.DeleteOnSubmit(product);
        }

        public void Save()
        {
            dataContext.SubmitChanges();
        }
    }
}
