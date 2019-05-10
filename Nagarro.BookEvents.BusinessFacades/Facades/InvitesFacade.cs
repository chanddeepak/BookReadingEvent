using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class InvitesFacade : FacadeBase, IInvitesFacade
    {
        public InvitesFacade()
            : base(FacadeType.InvitesFacade)
        {

        }

        public OperationResult<IInvitesDTO> CreateInvites(List<IInvitesDTO> listOfInviteDetail)
        {
            IInvitesBDC eventBDC = (IInvitesBDC)BDCFactory.Instance.Create(BDCType.InvitesBDC);
            return eventBDC.CreateInvites(listOfInviteDetail);
        }

        public OperationResult<List<IInvitesDTO>> GetInvites(IInvitesDTO invitesDTO)
        {
            IInvitesBDC eventBDC = (IInvitesBDC)BDCFactory.Instance.Create(BDCType.InvitesBDC);
            return eventBDC.GetInvites(invitesDTO);
        }
    }
}
