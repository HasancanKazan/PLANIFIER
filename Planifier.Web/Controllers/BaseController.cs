using Planifier.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planifier.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public IUserService userService { get; set; }
        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }
    }
}