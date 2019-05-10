using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared.Functional.BusinessFacades
{
    public interface ICommentsFacade : IFacade
    {
        OperationResult<ICommentsDTO> GetComments(ICommentsDTO commentsDTO);
        OperationResult<ICommentsDTO> CreateComments(ICommentsDTO commentsDTO);
        OperationResult<ICommentsDTO> DeleteComment(ICommentsDTO commentsDTO);
    }
}
