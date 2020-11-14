using Ninject.Modules;
using Planifier.BusinessLogicLayer.Interface.User;
using Planifier.BusinessLogicLayer.User;
using Planifier.Data.Contracts;
using Planifier.DataAccess.User;

namespace Planifier.Web.Controllers.Ninject
{
    public class NinjectBindModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUserManager>().To<UserManager>().InSingletonScope();
            Kernel.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
        }
    }
}