using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Data
{
    public class EventDAC : DACBase, IEventDAC
    {
        public EventDAC()
            : base(DACType.EventDAC)
        {}
        public IEventDTO GetEventDetails(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                var eventDetail = context.Event.Where(e => e.Id == eventDTO.Id).SingleOrDefault();

                if (eventDetail != null)
                {
                    EntityConverter.FillDTOFromEntity(eventDetail, eventDTO);
                }

                return eventDTO;
            }
        }

        public List<IEventDTO> GetEvents(IEventDTO eventDTO)
        {
           using(var context = new BookReadingEventsDBEntities())
            {
                List<IEventDTO> listOfEvents = null;
                var eventsEntityList = context.Event.Where(e => e.UserId == eventDTO.UserId).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<IEventDTO>();

                    foreach (var levent in eventsEntityList)
                    { 
                        EntityConverter.FillDTOFromEntity(levent, eventDTO);
                        listOfEvents.Add(eventDTO);
                    }

                }

                return listOfEvents;
            }
        }

        public IEventDTO CreateEvent(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                Event newEvent = new Event();
                EntityConverter.FillEntityFromDTO(eventDTO, newEvent);
         
                context.Event.Add(newEvent);
                context.SaveChanges();
                return eventDTO;

            }
        }

        public IEventDTO EditEvent(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                Event editEvent = new Event();
                EntityConverter.FillEntityFromDTO(eventDTO, editEvent);

                context.Event
                    .Where(e => e.Id == editEvent.Id)
                    .ToList()
                    .ForEach(e => e = editEvent);
                context.SaveChanges();
                return eventDTO;

            }
        }

        public bool DeleteEvent(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                var deleteEvent = context.Event
                    .Where(e => e.Id == eventDTO.Id)
                    .SingleOrDefault();
                bool result = false;
                if (deleteEvent != null)
                {
                    context.Event.Remove(deleteEvent);
                    result = true;
                }
                return result;

            }
        }
    }
}
