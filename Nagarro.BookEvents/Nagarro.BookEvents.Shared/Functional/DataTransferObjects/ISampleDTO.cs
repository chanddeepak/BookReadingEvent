using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ISampleDTO : IDTO
    {
        int SampleProperty1 { get; set; }
        string SampleProperty2 { get; set; }
    }
}
