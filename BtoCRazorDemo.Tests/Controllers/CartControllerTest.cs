using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Linq;
using BtoCRazorDemo;
using BtoCRazorDemo.Controllers;
using BtoCRazorDemo.Tests.Models;
using BtoCRazorDemo.Tests.Utils;

namespace BtoCRazorDemo.Tests.Controllers
{
    /// <summary>
    ///This is a test class for CartControllerTest and is intended
    ///to contain all CartControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CartControllerTest
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
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexGETTest1()
        {
            CartController target = new CartController(new TestOrderRepository(), new TestProductRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            context.HttpContext.Session["TxID"] = "dummy";
            target.ControllerContext = context;

            string expectedAction = "Empty";
            string expectedController = null;
            RedirectToRouteResult actual;
            actual = target.Index() as RedirectToRouteResult;
            Assert.AreEqual(expectedAction, actual.RouteValues["action"]);
            Assert.AreEqual(expectedController, actual.RouteValues["controller"]);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexGETTest2()
        {
            CartController target = new CartController(new TestOrderRepository(), new TestProductRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            context.HttpContext.Session["TxID"] = "1";
            target.ControllerContext = context;
            ViewResult actual;
            actual = target.Index() as ViewResult;
            Assert.IsNotNull(actual.ViewData.Model);
            Assert.IsNotNull(actual.ViewData["TotalMoney"]);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexPOST01Test()
        {
            CartController target = new CartController(new TestOrderRepository(), new TestProductRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            context.HttpContext.Session["TxID"] = "1";
            target.ControllerContext = context;

            FormCollection collection = null;
            string expectedAction = "Thanks";
            string expectedController = "Result";
            RedirectToRouteResult actual;
            actual = target.Index(collection) as RedirectToRouteResult;
            Assert.AreEqual(expectedAction, actual.RouteValues["action"]);
            Assert.AreEqual(expectedController, actual.RouteValues["controller"]);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexPOST02Test()
        {
            CartController target = new CartController(new TestOrderRepository(), new TestProductRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            context.HttpContext.Session["TxID"] = "aaaaaaaaa";
            target.ControllerContext = context;

            FormCollection collection = null;
            string expectedAction = "Sorry";
            string expectedController = "Result";
            RedirectToRouteResult actual;
            actual = target.Index(collection) as RedirectToRouteResult;
            Assert.AreEqual(expectedAction, actual.RouteValues["action"]);
            Assert.AreEqual(expectedController, actual.RouteValues["controller"]);
        }
        /// <summary>
        ///A test for Empty
        ///</summary>
        [TestMethod()]
        public void EmptyTest()
        {
            CartController target = new CartController(new TestOrderRepository(), new TestProductRepository());
            string expectedViewname = string.Empty;
            ViewResult actual;
            actual = target.Empty() as ViewResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedViewname, actual.ViewName);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void Delete01Test()
        {
            //var orderRepository = new TestOrderRepository();
            //CartController target = new CartController(orderRepository, new TestProductRepository());
            //ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            //context.HttpContext.Session["TxID"] = "1";
            //target.ControllerContext = context;

            //int beforeNum = orderRepository.GetByTxID("1").OrderDetails.Count;
            //int detailID = 1;
            //int expectedNum = beforeNum - 1;
            //RedirectToRouteResult actual = target.Delete(detailID) as RedirectToRouteResult;
            //int actualNum = orderRepository.GetByTxID("1").OrderDetails.Count;
            //Assert.AreEqual(expectedNum, actualNum);
            //Assert.IsNotNull(actual);
        }


        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void Delete02Test()
        {
            var orderRepository = new TestOrderRepository();
            CartController target = new CartController(orderRepository, new TestProductRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            context.HttpContext.Session["TxID"] = "1";
            target.ControllerContext = context;

            int beforeNum = orderRepository.GetByTxID("1").OrderDetails.Count;
            int detailID = -100;
            int expectedNum = beforeNum;
            RedirectToRouteResult actual = target.Delete(detailID) as RedirectToRouteResult;
            int actualNum = orderRepository.GetByTxID("1").OrderDetails.Count;
            Assert.AreEqual(expectedNum, actualNum);
            Assert.IsNotNull(actual);
        }
    }
}
