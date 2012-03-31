using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Diagnostics;

namespace BtoCRazorDemo.Controllers
{
    using BtoCRazorDemo.Models;
    //using BtoCRazorDemo.Utils;

    [Authorize]
    [HandleError]
    public class CartController : Controller
    {
        readonly IOrderRepository<Order> orderRepository;
        readonly IProductRepository<Product> productRepository;

        public CartController()
            : this(new OrderRepository(), new ProductRepository())
        {
        }

        public CartController(IOrderRepository<Order> orderRepository,IProductRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var order = orderRepository.GetByTxID(Session["TxID"] as string);
            if (order == null || order.OrderDetails.Count == 0)
            {
                return RedirectToAction("Empty");
            }
            else
            {
                ViewData["TotalMoney"] = order.OrderDetails.Select(detail => detail.Price * detail.Qty).Sum();
                //var query = order.OrderDetails.Select(detail => Utility.ConvertProduct2ViewModel(productRepository, detail)).AsQueryable();
                //return View(query);
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                orderRepository.GetByTxID(Session["TxID"] as string).Valid = true;
                orderRepository.Save();
                Session.Abandon();
                return RedirectToAction("Thanks", "Result");
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return RedirectToAction("Sorry", "Result", e);
            }
        }

        //
        // GET: /Card/Empty
        public ActionResult Empty()
        {
            return View();
        }

        //選択したアイテムをカートから削除
        public ActionResult Delete(int detailID)
        {
            try
            {
                var order = orderRepository.GetByTxID(Session["TxID"] as string);
                var detail = order.OrderDetails.SingleOrDefault(inst => inst.ID == detailID);
                order.OrderDetails.Remove(detail);
                orderRepository.Save();
                Trace.WriteLine("製品ID:" + detail.ProductID + " の削除しました");
            }
            catch (Exception e)
            {
                Trace.WriteLine("カート内データの削除に失敗しました");
                Trace.WriteLine(e);
            }
            return RedirectToAction("Index");
        }
    }
}
