using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesDTO : IDTO
    {
        int Id { get; set; }
        int EventId { get; set; }
        int UserId { get; set; }
    }
}
