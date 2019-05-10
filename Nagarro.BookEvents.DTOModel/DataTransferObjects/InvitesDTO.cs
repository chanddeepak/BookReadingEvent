using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.DTOModel
{
    [EntityMapping("Invites", MappingType.TotalExplicit)]
    public class InvitesDTO : DTOBase, IInvitesDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int EventId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        
    }
}
