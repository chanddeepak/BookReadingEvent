using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.BookEvents.UI.Controllers;
using Nagarro.BookEvents.UI;
using System.Web.Mvc;

namespace BookReadingEventsUnitTesting
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var Controller = new AccountController();
            var Result = Controller.Index() as ViewResult;
            Assert.AreEqual("LoginUser", Result.ViewName);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            var Controller = new AccountController();
            var Result = Controller.CreateUser() as ViewResult;
            Assert.AreEqual(null, Result.View);

        }

        [TestMethod]
        public void LoginUserTest()
        {
            var Controller = new AccountController();
            var Result = Controller.LoginUser() as ViewResult;
            Assert.AreEqual(null, Result.View);

        }
    }
}
