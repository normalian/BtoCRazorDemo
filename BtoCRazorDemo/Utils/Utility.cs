using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace BtoCRazorDemo.Utils
{
    using BtoCRazorDemo.Models;

    public class Utility
    {
        static object lockObj = new object();

        //注文IDを生成
        public static string TxProcessing()
        {
            int nowId = 0;
            try
            {
                lock (lockObj)
                {
                    ITxSeedRepository<TxSeed> txSeedRepository = new TxSeedRepository();
                    nowId = txSeedRepository.GetTxID();
                    txSeedRepository.SetTxID(nowId + 1);
                    txSeedRepository.Save();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                nowId = -1;
            }
            return nowId.ToString();
        }

        public static ProductViewModel ConvertProduct2ViewModel(IProductRepository<Product> productRepository, OrderDetail detail)
        {
            var product = productRepository.GetByID(detail.ProductID);
            return new ProductViewModel()
            {
                OrderID = detail.ID,
                ImageFileUrl = product.ImageFileUrl,
                Price = Convert.ToDecimal(product.Price),
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Qty = detail.Qty
            };
        }
    }
}