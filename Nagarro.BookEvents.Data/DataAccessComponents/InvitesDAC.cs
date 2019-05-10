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
        {

        }

        public IInvitesDTO CreateInvites(List<IInvitesDTO> listOfInviteDetail)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                Invite newInvite = new Invite();

                foreach (IInvitesDTO inviteDetail in listOfInviteDetail)
                {
                    EntityConverter.FillEntityFromDTO(inviteDetail, newInvite);
                    context.Invite.Add(newInvite);
                } 
                context.SaveChanges();
                return listOfInviteDetail[0];

            }
        }

        public List<IInvitesDTO> GetInvites(IInvitesDTO invitesDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                List<IInvitesDTO> listOfInvites = null;
                var invitesEntityList = context.Invite.Where(i => i.UserId == invitesDTO.UserId).ToList();

                if (invitesEntityList != null)
                {
                    listOfInvites = new List<IInvitesDTO>();

                    foreach (var invite in invitesEntityList)
                    {
                        EntityConverter.FillDTOFromEntity(invite, invitesDTO);
                        listOfInvites.Add(invitesDTO);
                    }

                }

                return listOfInvites;
            }
        }

    }
}
