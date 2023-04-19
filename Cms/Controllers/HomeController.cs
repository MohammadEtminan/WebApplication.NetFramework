﻿using DataLayer;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class HomeController : Controller
    {
        CmsContext db = new CmsContext();
        private IPageRepository pageRepository;

        public HomeController()
        {
            pageRepository = new PageRepository(db);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(pageRepository.PagesInSlider());
        }
    }
}