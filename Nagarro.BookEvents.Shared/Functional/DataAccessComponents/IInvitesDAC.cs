using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesDAC : IDataAccessComponent
    {
        List<IInvitesDTO> GetInvites(IInvitesDTO inviteDTO);
        IInvitesDTO CreateInvites(List<IInvitesDTO> listOfInviteDetail);
    }
}
