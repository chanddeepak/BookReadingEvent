using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.BookEvents.UI.Models
{
    public class InvitesModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}