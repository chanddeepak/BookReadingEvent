using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class SampleFacade : FacadeBase, ISampleFacade
    {
        public SampleFacade()
            : base(FacadeType.SampleFacade)
        {

        }
        public OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO)
        {
            ISampleBDC sampleBDC = (ISampleBDC)BDCFactory.Instance.Create(BDCType.SampleBDC);
            return sampleBDC.SampleMethod(sampleDTO);
        }
    }
}
