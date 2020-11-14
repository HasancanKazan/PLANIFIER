using Planifier.BusinessLogicLayer.Interface.User;
using Planifier.Core.Contracts.RequestMessages;
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
            var userRequest = new UserRequest
            {
                UserId = 1
            };
            var user = _userManager.UserSearch(userRequest);

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