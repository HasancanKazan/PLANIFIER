using Planifier.DataAccess;
using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Planifier.BusinessLogicLayer.Helper;
using Planifier.BusinessLogicLayer.Interface.User;
using Planifier.Data.Contracts;
using System.Threading.Tasks;
using Planifier.Core.Contracts.ResponseMessages;
using Planifier.Core.Contracts.RequestMessages;

namespace Planifier.BusinessLogicLayer.User
{
    public class UserManager : BusinessManagerBase, IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private static IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext());
        private readonly IPlanifierRepository<USER> userRep = uow.GetRepository<USER>();

        public Task<UserResponse> UserSearch(UserRequest request)
        {
            using (uow)
            {
                Expression<Func<USER, bool>> query = p => p.IsDeleted.Value == false;

                if (!string.IsNullOrEmpty(request.FirstName))
                {
                    query = query.And(p => p.FirstName == request.FirstName);
                }

                if (!string.IsNullOrEmpty(request.LastName))
                {
                    query = query.And(p => p.LastName == request.LastName);
                }

                if (request.UserId.HasValue)
                {
                    query = query.And(p => p.UserId == request.UserId);
                }

                if (request.AccountTypeId.HasValue)
                {
                    query = query.And(p => p.AccountTypeId == request.AccountTypeId);
                }

                if (request.IsActive.HasValue)
                {
                    query = query.And(p => p.IsActive == request.IsActive);
                }

                return base.ExecuteWithExeptionHandledOperation(async () =>
                {
                    var user = userRep.Find(query)
                                  .OrderByDescending(f => f.FirstName)
                                  .FirstOrDefault();
                    return Mapper.Map<UserResponse>(user);
                });

            }
        }
    }
}
