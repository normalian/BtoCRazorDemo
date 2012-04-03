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

    [Authorize]
    public class BuyHistoryController : Controller
    {
        readonly IOrderRepository<Order> orderRepository;

        public BuyHistoryController()
            : this(new OrderRepository())
        {
        }

        public BuyHistoryController(IOrderRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }


        //
        // GET: /BuyHistory/
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            try
            {
                var model = orderRepository.GetByUsername(username).OrderByDescending(order => order.OrderDate);
                if (model == null || model.Count() == 0)
                {
                    return RedirectToAction("Empty");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return RedirectToAction("Sorry", "Result");
            }
        }
        //
        // GET: /BuyHistory/Empty
        public ActionResult Empty()
        {
            return View();
        }
    }
}
