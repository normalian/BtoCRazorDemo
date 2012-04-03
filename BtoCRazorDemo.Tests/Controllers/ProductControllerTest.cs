using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BtoCRazorDemo.Tests.Controllers
{

    using BtoCRazorDemo.Tests.Models;
    using BtoCRazorDemo.Models;
    using BtoCRazorDemo.Controllers;

    /// <summary>
    ///This is a test class for ProductControllerTest and is intended
    ///to contain all ProductControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ProductIndex
        ///</summary>
        [TestMethod()]
        public void ProductIndex01Test()
        {
            ProductController target = new ProductController(new TestCategoryRepository(), new TestProductRepository(), new TestOrderRepository());
            int categoryId = 1;
            ViewResult actual;
            actual = target.ProductIndex(categoryId) as ViewResult;
            Assert.IsNotNull(actual.ViewData.Model);
        }

        /// <summary>
        ///A test for ProductIndex
        ///</summary>
        [TestMethod()]
        public void ProductIndex02Test()
        {
            ProductController target = new ProductController(new TestCategoryRepository(),
                new TestProductRepository(), new TestOrderRepository());
            int categoryId = -1;
            RedirectToRouteResult actual;
            actual = target.ProductIndex(categoryId) as RedirectToRouteResult;
            Assert.AreEqual("Sorry", actual.RouteValues["action"]);
            Assert.AreEqual("Result", actual.RouteValues["controller"]);
        }

        /// <summary>
        ///A test for ExtractOrderDetail
        ///</summary>
        [TestMethod()]
        public void ExtractOrderDetail01Test()
        {
            //string txID = "1";
            //var orderRepository = new TestOrderRepository();
            //ProductController_Accessor target = new ProductController_Accessor(new TestCategoryRepository(), new TestProductRepository(), orderRepository);
            //Order order = orderRepository.GetByTxID(txID);
            //int productID = 1;
            //OrderDetail actual;
            //actual = target.ExtractOrderDetail(order, productID);
            //Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ExtractOrderDetail
        ///</summary>
        [TestMethod()]
        public void ExtractOrderDetail02Test()
        {
            //string txID = "1";
            //var orderRepository = new TestOrderRepository();
            //ProductController_Accessor target = new ProductController_Accessor(new TestCategoryRepository(),
            //    new TestProductRepository(), orderRepository);
            //Order order = orderRepository.GetByTxID(txID);
            //int productID = -1;
            //OrderDetail actual;
            //actual = target.ExtractOrderDetail(order, productID);
            //Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ExtractOrder
        ///</summary>
        [TestMethod()]
        public void ExtractOrder01Test()
        {
            //var orderRepository = new TestOrderRepository();
            //ProductController_Accessor target = new ProductController_Accessor(new TestCategoryRepository(),
            //    new TestProductRepository(), orderRepository);
            //string txID = "1";
            //Order actual;
            //actual = target.ExtractOrder(txID);
            //Assert.IsNotNull(actual);
        }

        ///// <summary>
        /////A test for ExtractOrder
        /////</summary>
        //[TestMethod()]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void ExtractOrder02Test()
        //{
        //    var orderRepository = new TestOrderRepository();
        //    ProductController_Accessor target = new ProductController_Accessor(new TestCategoryRepository(),
        //        new TestProductRepository(), orderRepository);
        //    string txID = "aaaa";
        //    Order actual;
        //    actual = target.ExtractOrder(txID);
        //    Assert.IsNull(actual);
        //}

        /// <summary>
        ///A test for Edit
        ///</summary>
        [TestMethod()]
        public void Edit01Test()
        {
            ProductController target = new ProductController(new TestCategoryRepository(),
                new TestProductRepository(), new TestOrderRepository());
            Nullable<int> number = null;
            int productID = 0;
            string txID = string.Empty;
            ViewResult actual;
            actual = target.Edit(number, productID, txID) as ViewResult;
            Assert.IsNotNull(actual.ViewData.ModelState["number"]);
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        [TestMethod()]
        public void Edit02Test()
        {
            ProductController target = new ProductController(new TestCategoryRepository(),
                new TestProductRepository(), new TestOrderRepository());
            Nullable<int> number =-1;
            int productID = 0;
            string txID = string.Empty;
            ViewResult actual;
            actual = target.Edit(number, productID, txID) as ViewResult;
            Assert.IsNotNull(actual.ViewData.ModelState["number"]);
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        [TestMethod()]
        public void Edit11Test()
        {
            ProductController target = new ProductController(new TestCategoryRepository(),
                new TestProductRepository(), new TestOrderRepository());
            int productId = 1;
            ViewResult actual;
            actual = target.Edit(productId) as ViewResult;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        [TestMethod()]
        public void Edit12Test()
        {
            ProductController target = new ProductController(new TestCategoryRepository(),
                new TestProductRepository(), new TestOrderRepository());
            int productId = -1;
            ViewResult actual;
            actual = target.Edit(productId) as ViewResult;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for CategoryIndex
        ///</summary>
        [TestMethod()]
        public void CategoryIndexTest()
        {
            ProductController target = new ProductController(new TestCategoryRepository(),
                new TestProductRepository(), new TestOrderRepository());
            ViewResult actual;
            actual = target.CategoryIndex() as ViewResult;
            Assert.IsNotNull(actual.ViewData.Model);
        }
    }
}
