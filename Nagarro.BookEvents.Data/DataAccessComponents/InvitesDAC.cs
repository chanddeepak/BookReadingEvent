using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class InvitesDAC : DACBase, IInvitesDAC
    {
        public InvitesDAC()
            : base(DACType.InvitesDAC)
        { }

        public IInvitesDTO CreateInvites(List<IInvitesDTO> listOfInviteDetail)
        {

            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                foreach (IInvitesDTO inviteDetail in listOfInviteDetail)
                {
                    Invite newInvite = new Invite();
                    EntityConverter.FillEntityFromDTO(inviteDetail, newInvite);
                    context.Invite.Add(newInvite);
                } 
                context.SaveChanges();
                return listOfInviteDetail[0];

            }
        }

        public List<IEventDTO> GetInvites(IInvitesDTO invitesDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;
                List<IEventDTO> listOfInvites = null;
                Event eventModel = new Event();
                Invite inviteModel = new Invite();
                var invitesEntityList = context.Invite.Where(i => i.UserId == invitesDTO.UserId).
                    GroupJoin(context.Event,
                    i => i.EventId, e => e.Id, (i, eve) => new
                    {
                        eventDetail = eve
                    });

                if (invitesEntityList != null)
                {
                    listOfInvites = new List<IEventDTO>();

                    foreach (var invite in invitesEntityList)
                    {
                        if (invite.eventDetail.ElementAt(0).Type != "Private")
                        {
                            IEventDTO eventDTO = (IEventDTO)DTOFactory.Instance.Create(DTOType.EventDTO);
                            EntityConverter.FillDTOFromEntity(invite.eventDetail.ElementAt(0), eventDTO);
                            listOfInvites.Add(eventDTO);
                        }
                    }

                }

                return listOfInvites;
            }
        }

    }
}
