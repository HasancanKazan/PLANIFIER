using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using Planifier.DataAccess.Object.Model;
using Planifier.BusinessLogicLayer.User;
using System.Threading.Tasks;
using Planifier.DataAccess;
using Planifier.DataAccess.Abstract;

namespace Planifier.Service.UserService
{
    public class UserService : IUserService
    {
        private static IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext());
        private static readonly IPlanifierRepository<USER> userRep = uow.GetRepository<USER>();
        UserManager manager = new UserManager(userRep);

        public List<USER> UserSearch(UserRequest request)
        {
            return manager.UserSearch(request);
        }
    }
}
