using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ISampleFacade : IFacade
    {
        OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO);
    }
}
