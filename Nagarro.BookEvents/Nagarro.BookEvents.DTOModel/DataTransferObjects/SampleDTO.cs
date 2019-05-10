using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.DTOModel
{
    [EntityMapping("Sample", MappingType.TotalExplicit)]
    public class SampleDTO : DTOBase, ISampleDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]//There is no entity like Sample that exists
        public int SampleProperty1 { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string SampleProperty2 { get; set; }
    }
}
