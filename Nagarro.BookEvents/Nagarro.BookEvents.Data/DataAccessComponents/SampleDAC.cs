using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class SampleDAC : DACBase, ISampleDAC
    {
        public SampleDAC()
            : base(DACType.SampleDAC)
        {

        }
        public ISampleDTO SampleMethod(ISampleDTO sampleDTO)
        {
            //It is only for illustrative purpose
            Sample s = new Sample();

            //You have to use entity converter as shown below
            EntityConverter.FillEntityFromDTO(sampleDTO, s);

            //Only illustrative
            sampleDTO.SampleProperty1 = 100;
            sampleDTO.SampleProperty2 = "sample";
            return sampleDTO;
        }
    }
}
