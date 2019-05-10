using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }
        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO resultDTO = userDAC.CreateUser(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IUserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult("Email id already exist");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IUserDTO> LoginUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO resultDTO = userDAC.LoginUser(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IUserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult("Invalid email or password");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
