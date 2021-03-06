﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class CommentsBDC : BDCBase, ICommentsBDC
    {
        public CommentsBDC()
            : base(BDCType.CommentsBDC)
        {

        }

        public OperationResult<ICommentsDTO> CreateComments(ICommentsDTO commentsDTO)
        {
            OperationResult<ICommentsDTO> retVal = null;
            try
            {
                ICommentsDAC commentDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                ICommentsDTO resultDTO = commentDAC.CreateComments(commentsDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<ICommentsDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<ICommentsDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<ICommentsDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<ICommentsDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<bool> DeleteComment(ICommentsDTO commentsDTO)
        {
            OperationResult<bool> retVal = null;
            try
            {
                ICommentsDAC commentDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                bool resultDTO = commentDAC.DeleteComment(commentsDTO);
                if (resultDTO)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult(Constant.UserFailureResult);
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

        public OperationResult<List<ICommentsDTO>> GetComments(ICommentsDTO commentsDTO)
        {
            OperationResult<List<ICommentsDTO>> retVal = null;
            try
            {
                ICommentsDAC commentDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                List<ICommentsDTO> resultDTO = commentDAC.GetComments(commentsDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<ICommentsDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<ICommentsDTO>>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<ICommentsDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<ICommentsDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
