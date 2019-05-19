using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.BookEvents.UI.Controllers;
using Nagarro.BookEvents.UI;
using System.Web.Mvc;


namespace BookReadingEventsUnitTesting
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void UpcomingEventTest()
        {
            var Controller = new HomeController();
            var Result = Controller.UpcomingEvent() as ViewResult;
            Assert.AreEqual("", Result.ViewName);
        }

        [TestMethod]
        public void PastEventTest()
        {
            var Controller = new HomeController();
            var Result = Controller.PastEvent() as ViewResult;
            Assert.AreEqual("", Result.ViewName);
        }

        [TestMethod]
        public void DetailsTest()
        {
            var Controller = new HomeController();
            EventModel model = new EventModel();
            var Result = Controller.Details(model) as ViewResult;
            Assert.AreEqual("", Result.ViewName);
        }

        [TestMethod]
        public void IndexTest()
        {
            var Controller = new HomeController();
            var Result = Controller.PastEvent() as ViewResult;
            Assert.AreEqual(null, Result.View);
        }
    }

}
