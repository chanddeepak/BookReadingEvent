using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.BookEvents.UI.Controllers;
using Nagarro.BookEvents.UI;
using System.Web.Mvc;


namespace BookReadingEventsUnitTesting
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void MyEventsTest()
        {
            var Controller = new UserController();
            var Result = Controller.MyEvents() as ViewResult;
            Assert.AreEqual(null, Result.View);
        }

        [TestMethod]
        public void CreateEventTest()
        {
            var Controller = new UserController();
            EventModel model = new EventModel();
            var Result = Controller.CreateEvent(model) as ViewResult;
            Assert.AreEqual(null, Result.View);
        }


        [TestMethod]
        public void EventDetailTest()
        {

        }

        [TestMethod]
        public void EditEventTest()
        {

        }

        [TestMethod]
        public void DeleteEventTest()
        {

        }
    }

}
