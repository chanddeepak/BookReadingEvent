using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class CommentsDAC : DACBase, ICommentsDAC
    {
        public CommentsDAC()
            : base(DACType.CommentsDAC)
        {

        }

        public ICommentsDTO CreateComments(ICommentsDTO commentsDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                Comments newComment = new Comments();
                EntityConverter.FillEntityFromDTO(commentsDTO, newComment);

                context.Comments.Add(newComment);
                context.SaveChanges();
                return commentsDTO;

            }
        }

        public bool DeleteComment(ICommentsDTO commentsDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                var deleteComment = context.Comments
                    .SingleOrDefault(c => c.Id == commentsDTO.Id);
                bool result = false;
                if (deleteComment != null)
                {
                    context.Comments.Remove(deleteComment);
                    context.SaveChanges();
                    result = true;
                }
                return result;

            }
        }

        public List<ICommentsDTO> GetComments(ICommentsDTO commentsDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                List<ICommentsDTO> listOfComments = null;
                var commentsEntityList = context.Comments.Where(c => c.EventId == commentsDTO.EventId).ToList();

                if (commentsEntityList != null)
                {
                    listOfComments = new List<ICommentsDTO>();

                    foreach (var comment in commentsEntityList)
                    {
                        ICommentsDTO commentDTO = (ICommentsDTO)DTOFactory.Instance.Create(DTOType.CommentsDTO);
                        EntityConverter.FillDTOFromEntity(comment, commentDTO);
                        listOfComments.Add(commentDTO);
                    }

                }

                return listOfComments;
            }
        }

    }
}
