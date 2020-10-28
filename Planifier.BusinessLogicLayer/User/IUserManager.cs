using Planifier.DataAccess.Object;
using Planifier.DataAccess.Object.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planifier.BusinessLogicLayer.User
{
    public interface IUserManager
    {
        List<USER> UserSearch(UserRequest request);
    }
}
