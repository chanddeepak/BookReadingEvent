using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.BookEvents.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
            sampleDTO.SampleProperty1 = 22;
            sampleDTO.SampleProperty2 = "Robert";

            ISampleFacade sampleFacade = (ISampleFacade)FacadeFactory.Instance.Create(FacadeType.SampleFacade);
            OperationResult<ISampleDTO> result = sampleFacade.SampleMethod(sampleDTO);
            if (result.IsValid())
            {
                 ViewBag.resultData = result.Data;
                
            }
            return View();
        }

      

     
    }
}