using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetCommentByNewsId(int pageId);
        bool AddComment(PageComment comment);
    }
}