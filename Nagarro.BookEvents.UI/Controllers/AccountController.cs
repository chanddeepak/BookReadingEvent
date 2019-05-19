using Nagarro.BookEvents.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nagarro.BookEvents.UI;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.UI.Controllers
{
  /// <summary>
  /// 
  /// </summary>
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

       /// <summary>
       /// 
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>

        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                EntityConverter.FillDTOFromEntity(model, userDTO);
                userDTO.Role = "normal";
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<IUserDTO> result = userFacade.CreateUser(userDTO);
                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }
            ModelState.Clear();
            return RedirectToAction("LoginUser");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginUser()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult LoginUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                EntityConverter.FillDTOFromEntity(model, userDTO);
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<IUserDTO> result = userFacade.LoginUser(userDTO);
                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
                if (result.IsValid())
                {
                    FormsAuthentication.SetAuthCookie(result.Data.FullName + "|" + result.Data.Id + "|" + result.Data.Role, false);
                    return RedirectToAction("Index", "User");
                }

            }
            ModelState.AddModelError("",Constant.WrongEmailOrPassword);
            return View();
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");
        }
    }
}