using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared.Functional.BusinessFacades
{
    public interface IInvitesFacade : IFacade
    {
        OperationResult<IInvitesDTO> GetInvites(ICommentsDTO commentsDTO);
        OperationResult<IInvitesDTO> CreateInvites(List<ICommentsDTO> listOfUsers);
    }
}
