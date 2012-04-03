using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Tests.Models
{
    using BtoCRazorDemo.Models;

    public class TestOrderRepository : IOrderRepository<Order>
    {
        IList<Order> pool = new List<Order>();

        public TestOrderRepository()
        {
            ////一つ目
            var order = new Order()
            {
                OrderDate = DateTime.Now,
                Purchaser = "TestUser",
                TxID = "1",
                Valid = false,
            };
            var orderDetail = new OrderDetail()
            {
                ID = 1,
                Price = 100,
                Qty = 10,
                TxID = "1"
            };
            order.OrderDetails.Add(orderDetail);
            pool.Add(order);

            //二つ目
            var order2 = new Order()
            {
                OrderDate = DateTime.Now,
                Purchaser = "TestUser",
                TxID = "2",
                Valid = false,
            };
            var orderDetail2 = new OrderDetail()
            {
                ID = 2,
                Price = 100,
                Qty = 10,
                TxID = "2"
            };
            order2.OrderDetails.Add(orderDetail2);
            pool.Add(order2);
        }

        public IQueryable<Order> GetAll()
        {
            return pool.AsQueryable();
        }

        public Order GetByTxID(string txid)
        {
            return pool.SingleOrDefault(order => order.TxID == txid);
        }

        public IQueryable<Order> GetByUsername(string username)
        {
            return pool.Where(order => order.Purchaser == username && order.Valid).AsQueryable();
        }

        public void Add(Order order)
        {
            pool.Add(order);
        }

        public void Remove(Order order)
        {
            pool.Remove(order);
        }

        public void Save()
        {
        }
    }
}
