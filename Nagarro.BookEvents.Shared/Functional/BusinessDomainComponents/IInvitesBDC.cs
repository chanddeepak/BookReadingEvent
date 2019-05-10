using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesBDC : IBusinessDomainComponent
    {
        OperationResult<List<IInvitesDTO>> GetInvites(IInvitesDTO invitesDTO);
        OperationResult<IInvitesDTO> CreateInvites(List<IInvitesDTO> listOfInviteDetail);
    }
}
