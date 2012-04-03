using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BtoCRazorDemo.Controllers
{
    using BtoCRazorDemo.Models;
    using System.Diagnostics;
    using System.Data.Objects.DataClasses;

    //[Authorize]
    public class ProductController : Controller
    {
        readonly ICategoryRepository<Category> categoryRepository;
        readonly IProductRepository<Product> productRepository;
        readonly IOrderRepository<Order> orderRepository;

        public ProductController(
            ICategoryRepository<Category> categoryRepository,
            IProductRepository<Product> productRepository,
            IOrderRepository<Order> orderRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public ProductController()
            : this(new CategoryRepository(), new ProductRepository(), new OrderRepository())
        {
        }

        //
        // GET: /Product/
        [ActionName("Index")]
        public ActionResult CategoryIndex()
        {
            return View(categoryRepository.GetAll());
        }

        //
        // GET: /Product/ProductIndex/?categoryId=1
        public ActionResult ProductIndex(int categoryId)
        {
            try
            {
                var category = categoryRepository.GetByID(categoryId);
                ViewData["CategoryName"] = category.CategoryName;
                return View(category.Products.AsQueryable());
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return RedirectToAction("Sorry", "Result");
            }
        }

        //
        // GET: /Product/Edit/?productId=5
        [Authorize]
        public ActionResult Edit(int productId)
        {
            try
            {
                return View(productRepository.GetByID(productId));
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return RedirectToAction("Sorry", "Result");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public ActionResult Edit(int? number, int productID, string txID)
        {
            //string txID = Session["TxID"] as string;
            Product product = productRepository.GetByID(productID);
            try
            {
                if (number == null || number <= 0)
                {
                    ModelState.AddModelError("number", "不正な値が入力されました");
                    throw new ArgumentException("不正な購入数が入力されました");
                }
                var order = ExtractOrder(txID);
                var orderDetail = ExtractOrderDetail(order, productID);
                orderDetail.Price = Convert.ToDecimal(product.Price);
                orderDetail.Qty += (int)number;
                orderDetail.TxID = txID;
                orderRepository.Save();
                return RedirectToAction("Index", "Cart");
            }
            catch (ArgumentException e)
            {
                Trace.WriteLine(e);
                return View(product);
                //return RedirectToAction("Sorry", "Cart");
            }
        }

        protected OrderDetail ExtractOrderDetail(Order order, int productID)
        {
            var orderDetail = order.OrderDetails.SingleOrDefault(inst => inst.ProductID == productID);
            if (orderDetail == null)
            {
                orderDetail = new OrderDetail()
                    {
                        Orders = order,
                        Price = 0,
                        Qty = 0,
                        //TxID = string.Empty,
                        ProductID = productID
                    };
                order.OrderDetails.Add(orderDetail);
            }
            return orderDetail;
        }

        protected Order ExtractOrder(string txID)
        {
            var order = orderRepository.GetByTxID(txID);
            if (order == null)
            {
                order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Purchaser = User.Identity.Name,
                    Valid = false,
                    TxID = txID,
                    OrderDetails = new EntityCollection<OrderDetail>()
                };
                orderRepository.Add(order);
            }
            return order;
        }
    }
}
