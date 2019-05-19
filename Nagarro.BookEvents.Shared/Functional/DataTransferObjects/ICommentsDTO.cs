using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ICommentsDTO : IDTO
    {
        int Id { get; set; }
        int UserId { get; set; }
        int EventId { get; set; }
        string Comment { get; set; }
        DateTime Date { get; set; }
        string UserName { get; set; }
    }
}
