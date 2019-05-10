using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class EventBDC : BDCBase, IEventBDC
    {
        public EventBDC()
            : base(BDCType.UserBDC)
        {

        }
        public OperationResult<IEventDTO> CreateEvent(IEventDTO eventDTO)
        {
            OperationResult<IEventDTO> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                IEventDTO resultDTO = eventDAC.CreateEvent(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IEventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IEventDTO>.CreateFailureResult("Email id already exist");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IEventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IEventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<bool> DeleteEvent(IEventDTO eventDTO)
        {
            OperationResult<bool> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                bool resultDTO = eventDAC.DeleteEvent(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult("Email id already exist");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IEventDTO> EditEvent(IEventDTO eventDTO)
        {
            OperationResult<IEventDTO> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                IEventDTO resultDTO = eventDAC.EditEvent(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IEventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IEventDTO>.CreateFailureResult("Email id already exist");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IEventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IEventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IEventDTO> GetEventDetails(IEventDTO eventDTO)
        {
            OperationResult<IEventDTO> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                IEventDTO resultDTO = eventDAC.GetEventDetails(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IEventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IEventDTO>.CreateFailureResult("Email id already exist");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IEventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IEventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<List<IEventDTO>> GetEvents(IEventDTO eventDTO)
        {
            OperationResult<List<IEventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<IEventDTO> resultDTO = eventDAC.GetEvents(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateFailureResult("Email id already exist");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<IEventDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<IEventDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        
    }
}
