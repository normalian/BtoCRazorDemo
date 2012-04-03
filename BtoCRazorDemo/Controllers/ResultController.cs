using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BtoCRazorDemo.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Sorry()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}
