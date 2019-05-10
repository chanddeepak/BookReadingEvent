using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesBDC : IBusinessDomainComponent
    {
        OperationResult<IInvitesDTO> GetInvites(ICommentsDTO commentsDTO);
        OperationResult<IInvitesDTO> CreateInvites(List<ICommentsDTO> listOfUsers);
    }
}
