using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IEventDTO : IDTO
    {
        int Id { get; set; }
        string Title { get; set; }
        DateTime Date { get; set; }
        string Location { get; set; }
        TimeSpan StartTime { get; set; }
        int DurationInHours { get; set; }
        string Description { get; set; }
        string OtherDetails { get; set; }
        int UserId { get; set; }
        int TotalInvites { get; set; }
        string Type { get; set; }
    }
}
