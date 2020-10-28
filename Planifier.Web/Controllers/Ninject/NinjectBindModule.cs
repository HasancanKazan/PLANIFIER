using Ninject.Modules;
using Planifier.BusinessLogicLayer.Interface.User;
using Planifier.BusinessLogicLayer.User;

namespace Planifier.Web.Controllers.Ninject
{
    public class NinjectBindModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUserManager>().To<UserManager>().InSingletonScope();
        }
    }
}