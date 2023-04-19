using DataLayer;
using System.Web.Mvc;
using System.Web.Security;

namespace Cms.Controllers
{
    public class AccountController : Controller
    {
        private ILoginRepository loginRepository;
        CmsContext db = new CmsContext();

        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login, string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsExistUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                }
            }

            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}