using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class InvitesBDC : BDCBase, IInvitesBDC
    {
        public InvitesBDC()
            : base(BDCType.InvitesBDC)
        {

        }

        public OperationResult<IInvitesDTO> CreateInvites(List<IInvitesDTO> listOfInviteDetail)
        {
            OperationResult<IInvitesDTO> retVal = null;
            try
            {
                IInvitesDAC invitesDAC = (IInvitesDAC)DACFactory.Instance.Create(DACType.InvitesDAC);
                IInvitesDTO resultDTO = invitesDAC.CreateInvites(listOfInviteDetail);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IInvitesDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IInvitesDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IInvitesDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IInvitesDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<List<IEventDTO>> GetInvites(IInvitesDTO invitesDTO)
        {
            OperationResult<List<IEventDTO>> retVal = null;
            try
            {
                IInvitesDAC invitesDAC = (IInvitesDAC)DACFactory.Instance.Create(DACType.InvitesDAC);
                List<IEventDTO> resultDTO = invitesDAC.GetInvites(invitesDTO);
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
