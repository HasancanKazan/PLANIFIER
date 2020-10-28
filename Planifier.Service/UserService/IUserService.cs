using Planifier.DataAccess.Object;
using System.Collections.Generic;
using Planifier.DataAccess.Object.Model;
using System.Threading.Tasks;

namespace Planifier.Service.UserService
{
    public interface IUserService
    {
        #region User
        List<USER> UserSearch(UserRequest request);

        #endregion
    }
}
