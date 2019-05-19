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

        /// <summary>
        /// Admin Events DAC
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public List<IEventDTO> Events(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                List<IEventDTO> listOfEvents = null;
                var eventsEntityList = context.Event.OrderByDescending(e => e.Date).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<IEventDTO>();
                    foreach (Event levent in eventsEntityList)
                    {
                        IEventDTO eveDTO = (IEventDTO)DTOFactory.Instance.Create(DTOType.EventDTO);
                        EntityConverter.FillDTOFromEntity(levent, eveDTO);
                        listOfEvents.Add(eveDTO);
                    }

                }

                return listOfEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public IEventDTO GetEventDetails(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                var eventDetail = context.Event.Where(e => e.Id == eventDTO.Id).SingleOrDefault();

                if (eventDetail != null)
                {
                    EntityConverter.FillDTOFromEntity(eventDetail, eventDTO);
                }

                return eventDTO;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>

        public List<IEventDTO> GetFutureEvents()
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                List<IEventDTO> listOfEvents = null;
                var eventsEntityList = context.Event.OrderByDescending(e => e.Date).Where(e => e.Date > DateTime.Now).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<IEventDTO>();
                    foreach (Event levent in eventsEntityList)
                    {
                        if (levent.Type != "Private")
                        {
                            IEventDTO eveDTO = (IEventDTO)DTOFactory.Instance.Create(DTOType.EventDTO);
                            EntityConverter.FillDTOFromEntity(levent, eveDTO);
                            listOfEvents.Add(eveDTO);
                        }
                    }

                }

                return listOfEvents;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IEventDTO> GetPastEvents()
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                List<IEventDTO> listOfEvents = null;
                var eventsEntityList = context.Event.OrderByDescending(e => e.Date).Where(e => e.Date < DateTime.Now).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<IEventDTO>();
                    foreach (Event levent in eventsEntityList)
                    {
                        if (levent.Type != "Private")
                        {
                            IEventDTO eveDTO = (IEventDTO)DTOFactory.Instance.Create(DTOType.EventDTO);
                            EntityConverter.FillDTOFromEntity(levent, eveDTO);
                            listOfEvents.Add(eveDTO);
                        }
                    }

                }

                return listOfEvents;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public List<IEventDTO> GetEvents(IEventDTO eventDTO)
        {
           using(var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                List<IEventDTO> listOfEvents = null;
                var eventsEntityList = context.Event.OrderByDescending(e => e.Date).Where(e => e.UserId == eventDTO.UserId).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<IEventDTO>();
                    foreach (Event levent in eventsEntityList)
                    {
                        IEventDTO eveDTO = (IEventDTO)DTOFactory.Instance.Create(DTOType.EventDTO);
                        EntityConverter.FillDTOFromEntity(levent, eveDTO);
                        listOfEvents.Add(eveDTO);
                    }

                }

                return listOfEvents;
            }
        }

        private List<string> ConvertInviteEmails(IEventDTO eventDTO)
        {
            List<string> emails = null;
            if (eventDTO.InviteEmails != null)
            {
                string[] result = eventDTO.InviteEmails.Split(',');
                emails = new List<string>();
                foreach (string res in result)
                {
                    emails.Add(res.Trim());
                }
            }
            
            return emails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public IEventDTO CreateEvent(IEventDTO eventDTO)
        {
            List<string> inviteEmails = ConvertInviteEmails(eventDTO);

            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                Event newEvent = new Event();
                EntityConverter.FillEntityFromDTO(eventDTO, newEvent);

                var eventModel = context.Event.Add(newEvent);
                context.SaveChanges();

                int countOfInvites = 0;
                if (inviteEmails != null && newEvent.Type != "Private")
                {
                    foreach (string email in inviteEmails)
                    {
                        var user = context.User.Where(u => u.Email == email).SingleOrDefault();
                        if (user != null)
                        {
                            Invite inviteDetail = new Invite();
                            inviteDetail.EventId = newEvent.Id;
                            inviteDetail.UserId = user.Id;
                            context.Invite.Add(inviteDetail);
                            context.SaveChanges();
                            countOfInvites++;
                        }
                    }
                }

                eventModel.TotalInvites = countOfInvites;
                context.SaveChanges();
                EntityConverter.FillDTOFromEntity(eventModel, eventDTO);
                return eventDTO;

            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public IEventDTO EditEvent(IEventDTO eventDTO)
        {
            List<string> inviteEmails = ConvertInviteEmails(eventDTO);

            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                Event editEvent = context.Event.SingleOrDefault(e => e.Id == eventDTO.Id);
                EntityConverter.FillEntityFromDTO(eventDTO, editEvent);
                context.SaveChanges();

                int countOfInvites = 0;
                if (inviteEmails != null && editEvent.Type != "Private")
                {
                    foreach (string email in inviteEmails)
                    {
                        var user = context.User.Where(u => u.Email == email).SingleOrDefault();
                        
                        if (user != null)
                        {
                            var invite = context.Invite
                            .SingleOrDefault(i => i.EventId == editEvent.Id && i.UserId == user.Id);

                            if (invite == null)
                            {
                                Invite inviteDetail = new Invite();
                                inviteDetail.EventId = editEvent.Id;
                                inviteDetail.UserId = user.Id;
                                context.Invite.Add(inviteDetail);
                                context.SaveChanges();
                            }

                            countOfInvites++;
                        }
                    }
                }

                editEvent.TotalInvites = countOfInvites;
                context.SaveChanges();
                EntityConverter.FillDTOFromEntity(editEvent, eventDTO);
                return eventDTO;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public bool DeleteEvent(IEventDTO eventDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                var deleteEvent = context.Event
                    .SingleOrDefault(e => e.Id == eventDTO.Id);
                bool result = false;
                if (deleteEvent != null)
                {
                    // Deleting Invites
                    var deleteInvites = context.Invite.Where(i => i.EventId == eventDTO.Id).ToList();
                    foreach (var invite in deleteInvites)
                    {
                        context.Invite.Remove(invite);
                        context.SaveChanges();
                    }

                    // Deleting Comments
                    var deleteComments = context.Comments.Where(c => c.EventId == eventDTO.Id).ToList();
                    foreach (var comment in deleteComments)
                    {
                        context.Comments.Remove(comment);
                        context.SaveChanges();
                    }

                    // Deleting Event
                    context.Event.Remove(deleteEvent);
                    context.SaveChanges();
                    result = true;
                }
                return result;

            }
        }
    }
}
