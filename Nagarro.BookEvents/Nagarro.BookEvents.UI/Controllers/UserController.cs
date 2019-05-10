using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.BookEvents.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyEvents()
        {
            return View();
        }

        public ActionResult CreateEvents()
        {
            return View();
        }

        public ActionResult EventsInviteTo()
        {
            return View();
        }
    }
}