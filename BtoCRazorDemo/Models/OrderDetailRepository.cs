using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Models
{
    public interface IOrderDetailRepository<T>
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        IQueryable<OrderDetail> GetByTxID(string txid);
        void Add(T orderDetail);
        void Remove(T orderDetail);
        void Save();
    }


    public class OrderDetailRepository : IOrderDetailRepository<OrderDetail>
    {
        readonly protected B2CDbEntities dbEntities;

        public OrderDetailRepository()
        {
            dbEntities = new B2CDbEntities();
        }

        public IQueryable<OrderDetail> GetAll()
        {
            return dbEntities.OrderDetails.AsQueryable();
        }

        public OrderDetail GetByID(int id)
        {
            return dbEntities.OrderDetails.SingleOrDefault(orderDetail => orderDetail.ID == id);
        }

        public IQueryable<OrderDetail> GetByTxID(string txid)
        {
            return dbEntities.OrderDetails.Where(orderDetail => orderDetail.TxID == txid);
        }

        public void Add(OrderDetail orderDetail)
        {
            dbEntities.OrderDetails.AddObject(orderDetail);
        }

        public void Remove(OrderDetail orderDetail)
        {
            dbEntities.OrderDetails.DeleteObject(orderDetail);
        }

        public void Save()
        {
            dbEntities.SaveChanges();
        }
    }
}
