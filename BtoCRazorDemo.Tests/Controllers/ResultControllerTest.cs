using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System;
using System.Web.Routing;


namespace BtoCRazorDemo.Tests.Controllers
{
    using BtoCRazorDemo.Controllers;
    using BtoCRazorDemo.Tests.Utils;

    /// <summary>
    ///This is a test class for ResultControllerTest and is intended
    ///to contain all ResultControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ResultControllerTest
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
        ///A test for Thanks
        ///</summary>
        [TestMethod()]
        public void ThanksTest01()
        {
            ResultController target = new ResultController();
            Type expected = typeof(ViewResult);
            ActionResult actual;
            actual = target.Thanks();
            Assert.AreEqual(expected.FullName, actual.GetType().FullName);
        }

        /// <summary>
        ///A test for Sorry
        ///</summary>
        [TestMethod()]
        public void SorryTest01()
        {
            ResultController target = new ResultController();
            ControllerContext context = new ControllerContext(new MockHttpContext(), new RouteData(), target);
            Type expected = typeof(ViewResult);
            ActionResult actual;
            actual = target.Sorry();
            Assert.AreEqual(expected.FullName, actual.GetType().FullName);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest01()
        {
            ResultController target = new ResultController();
            Type expected = typeof(RedirectToRouteResult);
            ActionResult actual;
            actual = target.Index();
            Assert.AreEqual(expected.FullName, actual.GetType().FullName);
            Assert.AreNotEqual("ResultController", actual.GetType().Name);
        }
    }
}
