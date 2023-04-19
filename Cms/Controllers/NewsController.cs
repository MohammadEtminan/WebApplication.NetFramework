using System;
using DataLayer;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class NewsController : Controller
    {
        CmsContext db = new CmsContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }

        // GET: News
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupsForView());
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        public ActionResult LatestNews()
        {
            return PartialView(pageRepository.LastNews());
        }

        [Route("Archive")]
        public ActionResult NewsArchive()
        {
            return View(pageRepository.GetAllPage());
        }

        [Route("Group/{id}/{Title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();

            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment addComment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Email = email,
                Name = name
            };
            pageCommentRepository.AddComment(addComment);

            return PartialView("ShowComments", pageCommentRepository.GetCommentByNewsId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsId(id));
        }
    }
}