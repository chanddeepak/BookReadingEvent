using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nagarro.BookEvents.DTOModel;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.UI.Models;
using System.Web.Mvc;

namespace Nagarro.BookEvents.UI.Controllers
{   
    [Authorize]
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

        public ActionResult CreateEvent()
        {
            return View();
        }

        private List<string> ConvertInviteEmails(string inviteEmails)
        {
            string [] result = inviteEmails.Split(',');
            List<string> emails = new List<string>();
            foreach(string res in result)
            {
                emails.Add(res.Trim());
            }
            return emails;
        }

        [HttpPost]
        public ActionResult CreateEvent(EventModel model) 
        {
            if(ModelState.IsValid)
            {
                List<string> inviteEmails = ConvertInviteEmails(model.InviteEmails);

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
            }
            return View();
        }

        public ActionResult EventsInviteTo()
        {
            return View();
        }
    }
}