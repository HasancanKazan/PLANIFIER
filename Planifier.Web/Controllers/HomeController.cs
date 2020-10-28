using Planifier.BusinessLogicLayer.Interface.User;
using Planifier.DataAccess.Object.Model;
using System.Web.Mvc;

namespace Planifier.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManager _userManager;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        public ActionResult Index()
        {
            _userManager.UserSearch(new UserRequest() { UserId = 2,IsDeleted=true});
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


        public ActionResult Login()
        {
            return View();
        }
    }
}