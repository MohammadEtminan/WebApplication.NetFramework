using System;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private CmsContext db;

        public PageCommentRepository(CmsContext context)
        {
            db = context;
        }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
            return db.PageComments.Where(c => c.PageID == pageId);
        }

        public bool AddComment(PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}