using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class EventFacade : FacadeBase, IEventFacade
    {
        public EventFacade()
            : base(FacadeType.EventFacade)
        {

        }
        public OperationResult<IEventDTO> CreateEvent(IEventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.CreateEvent(eventDTO);
        }

        public OperationResult<bool> DeleteEvent(IEventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.DeleteEvent(eventDTO);
        }

        public OperationResult<IEventDTO> EditEvent(IEventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.EditEvent(eventDTO);
        }

        public OperationResult<IEventDTO> GetEventDetails(IEventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEventDetails(eventDTO);
        }

        public OperationResult<List<IEventDTO>> GetEvents(IEventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEvents(eventDTO);
        }
    }
}
