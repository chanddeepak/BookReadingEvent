using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISampleDTO sampleDTO = (ISampleDTO)DTOFactory.Instance.Create(DTOType.SampleDTO);
            sampleDTO.SampleProperty1 = 22;
            sampleDTO.SampleProperty2 = "Robert";

            ISampleFacade sampleFacade = (ISampleFacade)FacadeFactory.Instance.Create(FacadeType.SampleFacade);
            OperationResult<ISampleDTO> result = sampleFacade.SampleMethod(sampleDTO);
            if (result.IsValid())
            {
                var resultData = result.Data;
                System.Console.WriteLine(resultData);
            }
            System.Console.ReadLine();
        }
    }
}
