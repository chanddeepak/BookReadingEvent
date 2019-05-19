using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Nagarro.BookEvents.DTOModel;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.UI;
using System.Web.Mvc;

namespace Nagarro.BookEvents.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    [Authorize]
    public class UserController : Controller
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        { 
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult MyEvents()
        {
            EventDTO eventDetail = new EventDTO();
            string user =  GetUserDetail();
            eventDetail.UserId = Convert.ToInt32(user.Split('|')[1]);

            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<List<IEventDTO>> result = eventFacade.GetEvents(eventDetail);

            if (result.IsValid() && result.Data.Count != 0)
            {
                List<IEventDTO> eventsDTO = result.Data;
                List<EventModel> eventsModel = new List<EventModel>();

                foreach (IEventDTO eventDTO in eventsDTO)
                {
                    EventModel eventModel = new EventModel();
                    EntityConverter.FillEntityFromDTO(eventDTO, eventModel);
                    eventsModel.Add(eventModel);
                }

                return View(eventsModel);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateEvent()
        {
            return View();
        }  

        [HttpPost]
        public ActionResult CreateEvent(EventModel model) 
        {
            if(ModelState.IsValid)
            {
                string user = GetUserDetail();
                model.UserId = Convert.ToInt32(user.Split('|')[1]);

                EventDTO eventDetail = new EventDTO();
                //ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
                EntityConverter.FillDTOFromEntity(model, eventDetail);

                IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
                OperationResult<IEventDTO> result = eventFacade.CreateEvent(eventDetail);

                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }

                ModelState.Clear();
                return RedirectToAction("MyEvents");
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EventsInviteTo()
        {
            InvitesDTO inviteList = new InvitesDTO();
            string user = GetUserDetail();
            inviteList.UserId = Convert.ToInt32(user.Split('|')[1]);

            IInvitesFacade inviteFacade = (IInvitesFacade)FacadeFactory.Instance.Create(FacadeType.InvitesFacade);
            OperationResult<List<IEventDTO>> result = inviteFacade.GetInvites(inviteList);

            if (result.IsValid() && result.Data.Count != 0)
            {
                List<IEventDTO> eventsDTO = result.Data;
                List<EventModel> eventsModel = new List<EventModel>();

                foreach (IEventDTO eventDTO in eventsDTO)
                {
                    EventModel eventModel = new EventModel();
                    EntityConverter.FillEntityFromDTO(eventDTO, eventModel);
                    eventsModel.Add(eventModel);
                }

                return View(eventsModel);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EventDetail(EventModel model)
        {
            if (model.Id != 0)
            {
                EventDTO eventDetail = new EventDTO();
                eventDetail.Id = model.Id;

                IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
                OperationResult<IEventDTO> result = eventFacade.GetEventDetails(eventDetail);

                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }

                if (result.IsValid())
                {
                    EntityConverter.FillEntityFromDTO(result.Data, model);
                }
                return View(model);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditEvent(EventModel model)
        {
            EventDTO eventDetail = new EventDTO();
            eventDetail.Id = model.Id;

            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<IEventDTO> result = eventFacade.GetEventDetails(eventDetail);

            if (result.ResultType == OperationResultType.Failure)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }

            if (result.IsValid())
            {
                EntityConverter.FillEntityFromDTO(result.Data, model);
            }

            ModelState.Clear();
            return View(model);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult EditEventPost(EventModel model)
        {

            if (ModelState.IsValid)
            {
                string user = GetUserDetail();
                model.UserId = Convert.ToInt32(user.Split('|')[1]);

                EventDTO eventDetail = new EventDTO();
                //ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
                EntityConverter.FillDTOFromEntity(model, eventDetail);

                IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
                OperationResult<IEventDTO> result = eventFacade.EditEvent(eventDetail);

                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }

                ModelState.Clear();
                if (user.Split('|')[2] == "normal")
                {
                    return RedirectToAction("MyEvents");
                } else
                {
                    return RedirectToAction("Events");
                }
            }
            return RedirectToAction("EditEvent", model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeleteEvent(EventModel model)
        {
            EventDTO eventDetail = new EventDTO();
            eventDetail.Id = model.Id;

            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<bool> result = eventFacade.DeleteEvent(eventDetail);

            ModelState.Clear();
            if (User.Identity.Name.Split('|')[2] == "admin")
                return RedirectToAction("Events");
            else
                return RedirectToAction("MyEvents");
        }

        /// <summary>
        /// Admin Events
        /// </summary>
        /// <returns></returns>
        public ActionResult Events()
        {
            EventDTO eventDetail = new EventDTO();
            string user = GetUserDetail();
            eventDetail.UserId = Convert.ToInt32(user.Split('|')[1]);

            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<List<IEventDTO>> result = eventFacade.Events(eventDetail);

            if (result.IsValid() && result.Data.Count != 0)
            {
                List<IEventDTO> eventsDTO = result.Data;
                List<EventModel> eventsModel = new List<EventModel>();

                foreach (IEventDTO eventDTO in eventsDTO)
                {
                    EventModel eventModel = new EventModel();
                    EntityConverter.FillEntityFromDTO(eventDTO, eventModel);
                    eventsModel.Add(eventModel);
                }

                return View(eventsModel);
            }
            return View();
        }
    }
}