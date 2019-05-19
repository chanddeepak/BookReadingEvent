using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesFacade : IFacade
    {
        OperationResult<List<IEventDTO>> GetInvites(IInvitesDTO invitesDTO);
        OperationResult<IInvitesDTO> CreateInvites(List<IInvitesDTO> listOfInviteDetail);
    }
}
