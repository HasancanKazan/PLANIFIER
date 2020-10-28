using Planifier.DataAccess;
using Planifier.DataAccess.Abstract;
using Planifier.DataAccess.Object.Model;
using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Planifier.BusinessLogicLayer.Helper;
using Planifier.BusinessLogicLayer.Interface.User;

namespace Planifier.BusinessLogicLayer.User
{
    public class UserManager : IUserManager
    {
        private static IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext());
        private readonly IPlanifierRepository<USER> userRep = uow.GetRepository<USER>();

        public List<USER> UserSearch(UserRequest request)
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

                var list = userRep.Find(query)
                                  .OrderByDescending(f => f.FirstName)
                                  .ToList();
                return list;
            }
        }
    }
}
