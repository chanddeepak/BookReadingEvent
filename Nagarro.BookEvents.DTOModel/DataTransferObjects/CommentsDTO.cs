using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.DTOModel
{
    [EntityMapping("Comments", MappingType.TotalExplicit)]
    public class CommentsDTO : DTOBase, ICommentsDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int EventId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Comment")]
        public string Comment { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Date")]
        public DateTime Date { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserName")]
        public string UserName { get; set; }

    }
}
