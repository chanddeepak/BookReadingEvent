using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IEventBDC : IBusinessDomainComponent
    {
        OperationResult<IEventDTO> GetEventDetails(IEventDTO eventDTO);
        OperationResult<List<IEventDTO>> GetEvents(IEventDTO eventDTO);
        OperationResult<IEventDTO> CreateEvent(IEventDTO eventDTO);
        OperationResult<IEventDTO> EditEvent(IEventDTO eventDTO);
        OperationResult<bool> DeleteEvent(IEventDTO eventDTO);
    }
}
