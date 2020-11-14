using Planifier.Core.Contracts.RequestMessages;
using Planifier.Core.Contracts.ResponseMessages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planifier.BusinessLogicLayer.Interface.User
{
    public interface IUserManager
    {
        Task<UserResponse> UserSearch(UserRequest request);
    }
}
