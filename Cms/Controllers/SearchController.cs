using DataLayer;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        CmsContext db = new CmsContext();

        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }

        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}