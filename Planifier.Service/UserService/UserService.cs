using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using Planifier.DataAccess.Object.Model;
using Planifier.BusinessLogicLayer.User;
using System.Threading.Tasks;

namespace Planifier.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserManager userManager;

        public UserService(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public List<USER> UserSearch(UserRequest request)
        {
            return userManager.UserSearch(request);
        }
    }
}
