using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.Validations;

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

                var result = Validator<UserValidation, IUserDTO>.Validate(userDTO);

                if (!result.IsValid)
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult(result.Errors[0].ErrorMessage);
                    return retVal;
                }

                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO resultDTO = userDAC.CreateUser(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IUserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult(Constant.UserFailureResult);
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
                    retVal = OperationResult<IUserDTO>.CreateFailureResult(Constant.LoginFailureresult);
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
