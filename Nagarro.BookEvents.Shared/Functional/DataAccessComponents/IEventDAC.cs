using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IEventDAC : IDataAccessComponent
    {
        IEventDTO GetEventDetails(IEventDTO eventDTO);
        List<IEventDTO> GetEvents(IEventDTO eventDTO);
        List<IEventDTO> GetPastEvents();
        List<IEventDTO> GetFutureEvents();
        IEventDTO CreateEvent(IEventDTO eventDTO);
        IEventDTO EditEvent(IEventDTO eventDTO);
        bool DeleteEvent(IEventDTO eventDTO);
        List<IEventDTO> Events(IEventDTO eventDTO);
    }
}
