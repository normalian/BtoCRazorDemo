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
        readonly protected B2CDbEntities dbEntities;

        public OrderRepository()
        {
            dbEntities = new B2CDbEntities();
        }

        public IQueryable<Order> GetAll()
        {
            return dbEntities.Orders.AsQueryable();
        }

        public Order GetByTxID(string txid)
        {
            return dbEntities.Orders.SingleOrDefault(order => order.TxID == txid);
        }

        public IQueryable<Order> GetByUsername(string username)
        {
            return dbEntities.Orders.Where(order => order.Purchaser == username && order.Valid);
        }

        public void Add(Order order)
        {
            dbEntities.Orders.AddObject(order);
        }

        public void Remove(Order order)
        {
            dbEntities.Orders.DeleteObject(order);
        }

        public void Save()
        {
            dbEntities.SaveChanges();
        }
    }
}
