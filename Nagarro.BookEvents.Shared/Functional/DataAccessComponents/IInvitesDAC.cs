using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesDAC : IDataAccessComponent
    {
        List<IInvitesDTO> GetInvites(ICommentsDTO commentsDTO);
        IInvitesDTO CreateInvites(List<ICommentsDTO> listOfEmails);
    }
}
