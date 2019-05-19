using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.Validations;

namespace Nagarro.BookEvents.Business
{
    public class EventBDC : BDCBase, IEventBDC
    {
        public EventBDC()
            : base(BDCType.EventBDC)
        {

        }
        public OperationResult<IEventDTO> CreateEvent(IEventDTO eventDTO)
        {
            OperationResult<IEventDTO> retVal = null;
            try
            {

                var result = Validator<EventValidation, IEventDTO>.Validate(eventDTO);
                if (!result.IsValid)
                {
                    retVal = OperationResult<IEventDTO>.CreateFailureResult(result.Errors[0].ErrorMessage);
                    return retVal;
                }

                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                IEventDTO resultDTO = eventDAC.CreateEvent(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IEventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IEventDTO>.CreateFailureResult(Constant.UserFailureResult);
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
                if (resultDTO)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult(Constant.EventFailureResult);
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
                    retVal = OperationResult<IEventDTO>.CreateFailureResult(Constant.UserFailureResult);
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
                    retVal = OperationResult<IEventDTO>.CreateFailureResult(Constant.UserFailureResult);
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
                    retVal = OperationResult<List<IEventDTO>>.CreateFailureResult(Constant.UserFailureResult);
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

        public OperationResult<List<IEventDTO>> GetPastEvents()
        {
            OperationResult<List<IEventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<IEventDTO> resultDTO = eventDAC.GetPastEvents();
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateFailureResult(Constant.UserFailureResult);
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

        public OperationResult<List<IEventDTO>> GetFutureEvents()
        {
            OperationResult<List<IEventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<IEventDTO> resultDTO = eventDAC.GetFutureEvents();
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateFailureResult(Constant.UserFailureResult);
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

        public OperationResult<List<IEventDTO>> Events(IEventDTO eventDTO)
        {
            OperationResult<List<IEventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<IEventDTO> resultDTO = eventDAC.Events(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<IEventDTO>>.CreateFailureResult(Constant.UserFailureResult);
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
