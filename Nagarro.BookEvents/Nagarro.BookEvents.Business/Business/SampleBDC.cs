using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class SampleBDC : BDCBase, ISampleBDC
    {
        public SampleBDC()
            : base(BDCType.SampleBDC)
        {

        }
        public OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO)
        {
            OperationResult<ISampleDTO> retVal = null;
            try
            {
                ISampleDAC sampleDAC = (ISampleDAC)DACFactory.Instance.Create(DACType.SampleDAC);
                ISampleDTO resultDTO = sampleDAC.SampleMethod(sampleDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<ISampleDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<ISampleDTO>.CreateFailureResult("Failed!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<ISampleDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<ISampleDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
