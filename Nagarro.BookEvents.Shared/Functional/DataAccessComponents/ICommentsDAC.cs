using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ICommentsDAC : IDataAccessComponent
    {
        List<ICommentsDTO> GetComments(ICommentsDTO commentsDTO);
        ICommentsDTO CreateComments(ICommentsDTO commentsDTO);
        bool DeleteComment(ICommentsDTO commentsDTO);
    }
}
