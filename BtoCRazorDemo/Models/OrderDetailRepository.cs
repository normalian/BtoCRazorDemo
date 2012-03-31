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
        readonly protected BtoCDataClassesDataContext dataContext;

        public OrderDetailRepository()
        {
            dataContext = new BtoCDataClassesDataContext();
        }

        public IQueryable<OrderDetail> GetAll()
        {
            return dataContext.OrderDetails.AsQueryable();
        }

        public OrderDetail GetByID(int id)
        {
            return dataContext.OrderDetails.SingleOrDefault(orderDetail => orderDetail.ID == id);
        }

        public IQueryable<OrderDetail> GetByTxID(string txid)
        {
            return dataContext.OrderDetails.Where(orderDetail => orderDetail.TxID == txid);
        }

        public void Add(OrderDetail orderDetail)
        {
            dataContext.OrderDetails.InsertOnSubmit(orderDetail);
        }

        public void Remove(OrderDetail orderDetail)
        {
            dataContext.OrderDetails.DeleteOnSubmit(orderDetail);
        }

        public void Save()
        {
            dataContext.SubmitChanges();
        }
    }
}
