using Planifier.DataAccess.Object;
using Planifier.DataAccess.Object.Model;
using System.Collections.Generic;

namespace Planifier.BusinessLogicLayer.Interface.User
{
    public interface IUserManager
    {
        List<USER> UserSearch(UserRequest request);
    }
}
