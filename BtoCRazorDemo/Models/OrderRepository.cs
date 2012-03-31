using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Models
{
    public interface IOrderRepository<T>
    {
        IQueryable<T> GetAll();
        Order GetByTxID(string txid);
        IQueryable<T> GetByUsername(string username);
        void Add(T order);
        void Remove(T order);
        void Save();
    }


    public class OrderRepository : IOrderRepository<Order>
    {
        readonly protected BtoCDataClassesDataContext dataContext;

        public OrderRepository()
        {
            dataContext = new BtoCDataClassesDataContext();
        }

        public IQueryable<Order> GetAll()
        {
            return dataContext.Orders.AsQueryable();
        }

        public Order GetByTxID(string txid)
        {
            return dataContext.Orders.SingleOrDefault(order => order.TxID == txid);
        }

        public IQueryable<Order> GetByUsername(string username)
        {
            return dataContext.Orders.Where(order => order.Purchaser == username && order.Valid);
        }

        public void Add(Order order)
        {
            dataContext.Orders.InsertOnSubmit(order);
        }

        public void Remove(Order order)
        {
            dataContext.Orders.DeleteOnSubmit(order);
        }

        public void Save()
        {
            dataContext.SubmitChanges();
        }
    }
}
