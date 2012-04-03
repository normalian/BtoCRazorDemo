using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System;
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

namespace BtoCDemo.Tests.Controllers
{


    /// <summary>
    ///This is a test class for BuyHistoryControllerTest and is intended
    ///to contain all BuyHistoryControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BuyHistoryControllerTest
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
        public void IndexTest01()
        {
            BuyHistoryController target = new BuyHistoryController(new TestOrderRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            target.ControllerContext = context;
            Type expected = typeof(RedirectToRouteResult);
            ActionResult actual;
            actual = target.Index();
            Assert.AreEqual(expected.FullName, actual.GetType().FullName);
        }


        /// <summary>
        ///A test for Index
        ///</summary>
        //[TestMethod()]
        public void IndexPostTest01()
        {
            BuyHistoryController target = new BuyHistoryController(new TestOrderRepository());
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            target.ControllerContext = context;
            Type expected = typeof(ViewResult);
            ActionResult actual;
            actual = target.Index() as ViewResult;
            Assert.AreEqual(expected.FullName, actual.GetType().FullName);
            Assert.AreEqual(typeof(IQueryable<BtoCRazorDemo.Models.Order>), target.ViewData.Model.GetType());
        }


        /// <summary>
        ///A test for Empty
        ///</summary>
        [TestMethod()]
        public void EmptyTest()
        {
            BuyHistoryController target = new BuyHistoryController(new TestOrderRepository());
            Type expected = typeof(ViewResult);
            Type actual;
            actual = target.Empty().GetType();
            Assert.AreEqual(expected, actual);
        }
    }
}
