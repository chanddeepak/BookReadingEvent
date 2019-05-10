using Nagarro.BookEvents.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nagarro.BookEvents.UI.Models;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.UI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {

            return View("LoginUser");
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO();
                //ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.Password = model.Password;
                user.Role = "normal";

                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<IUserDTO> result = userFacade.CreateUser(user);
                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }
            ModelState.Clear();
            return View("LoginUser");
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO();
                //ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
                user.Email = model.Email;
                user.Password = model.Password;
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<IUserDTO> result = userFacade.LoginUser(user);
                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }
            FormsAuthentication.SetAuthCookie(model.FullName, false);
            return RedirectToAction("Index", "User");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");
        }
    }
}