using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Nagarro.BookEvents.UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult UpcomingEvent()
        {
            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<List<IEventDTO>> result = eventFacade.GetFutureEvents();

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

        public ActionResult PastEvent()
        {
            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<List<IEventDTO>> result = eventFacade.GetPastEvents();

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

        public ActionResult Details(EventModel model)
        {
            if (model.Id != 0)
            {
                IEventDTO eventDetail = (IEventDTO)DTOFactory.Instance.Create(DTOType.EventDTO);
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

    }
}