using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.UI.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public int DurationInHours { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }
        public int UserId { get; set; }
        public string InviteEmails { get; set; }
        public int TotalInvites { get; set; }
        public string Type { get; set; }
    }
}
