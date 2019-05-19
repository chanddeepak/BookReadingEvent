using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ICommentsFacade : IFacade
    {
        OperationResult<List<ICommentsDTO>> GetComments(ICommentsDTO commentsDTO);
        OperationResult<ICommentsDTO> CreateComments(ICommentsDTO commentsDTO);
        OperationResult<bool> DeleteComment(ICommentsDTO commentsDTO);
    }
}
