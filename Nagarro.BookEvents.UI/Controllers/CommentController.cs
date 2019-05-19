﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.DTOModel;
using System.Web.Security;

namespace Nagarro.BookEvents.UI
{
    [Authorize]
    public class CommentController : Controller
    {
        /// <summary>
        ///  Function to get user id from cookie
        /// </summary>
        /// <returns></returns>
        private string GetUserDetail()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string user = ticket.Name;

            return user;
        }

        public ActionResult CreateComment()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult CreateComment(CommentModel model)
        {
            if(ModelState.IsValid && model.Id != 0)
            {
                string user = GetUserDetail();
                model.UserName = user.Split('|')[0];
                model.UserId = Convert.ToInt32(user.Split('|')[1]);
                model.EventId = model.Id;
                model.Date = DateTime.Now;
                ICommentsDTO commentsDTO = (ICommentsDTO)DTOFactory.Instance.Create(DTOType.CommentsDTO);
                EntityConverter.FillDTOFromEntity(model, commentsDTO);

                ICommentsFacade commentsFacade = (ICommentsFacade)FacadeFactory.Instance.Create(FacadeType.CommentsFacade);
                OperationResult<ICommentsDTO> result = commentsFacade.CreateComments(commentsDTO);

                if(result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [AllowAnonymous]
        public ActionResult GetComments(CommentModel model)
        {
            ICommentsDTO commentDetail = (ICommentsDTO)DTOFactory.Instance.Create(DTOType.CommentsDTO);
            commentDetail.EventId = model.Id;

            ICommentsFacade eventFacade = (ICommentsFacade)FacadeFactory.Instance.Create(FacadeType.CommentsFacade);
            OperationResult<List<ICommentsDTO>> result = eventFacade.GetComments(commentDetail);


            if (result.ResultType == OperationResultType.Failure)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }


            if (result.IsValid() && result.Data.Count != 0)
            {
                List<ICommentsDTO> commentsDTO = result.Data;
                List<CommentModel> commentsModel = new List<CommentModel>();

                foreach (ICommentsDTO commentDTO in commentsDTO)
                {
                    CommentModel commentModel = new CommentModel();
                    EntityConverter.FillEntityFromDTO(commentDTO, commentModel);
                    commentsModel.Add(commentModel);
                }

                ModelState.Clear();
                return View(commentsModel);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>

        public ActionResult DeleteComment(CommentModel comment)
        {
            CommentsDTO commentDetail = new CommentsDTO();
            EntityConverter.FillDTOFromEntity(comment, commentDetail);

            ICommentsFacade commentsFacade = (ICommentsFacade)FacadeFactory.Instance.Create(FacadeType.CommentsFacade);
            OperationResult<bool> result = commentsFacade.DeleteComment(commentDetail);

            if (result.ResultType == OperationResultType.Failure)
            {
                ModelState.AddModelError("", result.Message);
                return RedirectToAction("EventDetail", "User", new { id = comment.EventId });
            }

            ModelState.Clear();
            return RedirectToAction("EventDetail", "User", new { id = comment.EventId});
        }
    }
}                                          