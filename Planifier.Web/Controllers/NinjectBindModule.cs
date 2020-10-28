using Ninject.Modules;
using Planifier.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planifier.Web.Controllers
{
    public class NinjectBindModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUserService>().To<UserService>().InSingletonScope();

        }
    }
}