using Planifier.DataAccess;
using Planifier.DataAccess.Abstract;
using Planifier.DataAccess.Object.Model;
using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Planifier.DataAccess.Object.Extensions;
using System.Threading.Tasks;

namespace Planifier.BusinessLogicLayer.User
{
    public class UserManager : IUserManager
    {
        // neden static
        private static IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext());
        private readonly IPlanifierRepository<USER> userRep = uow.GetRepository<USER>();

        public UserManager(IPlanifierRepository<USER> userRep)
        {
            this.userRep = userRep;
        }
        //public void Test()
        //{
        //    using(uow)
        //    {
        //        accountRepo = uow.GetRepository<ACCOUNT_TYPES>();

        //        accountRepo.Add(new ACCOUNT_TYPES()
        //        {
        //            AccountName = "Test",
        //            Description = "Test",
        //        });
        //        accountRepo.Add(new ACCOUNT_TYPES()
        //        {
        //            AccountName = "Admin",
        //            Description = "Tüm Yetkilere Sahip Kullanıcı",
        //        });

        //        uow.SaveChanges();
        //    }
        //}

        #region UserSearch
        public List<USER> UserSearch(UserRequest request)
        {
            Expression<Func<USER, bool>> query = p => !p.IsDeleted.HasValue;

            if (!string.IsNullOrEmpty(request.FirstName))
            {
                query.And(p => p.FirstName == request.FirstName);
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                query.And(p => p.LastName == request.LastName);
            }

            if (request.UserId.HasValue)
            {
                query.And(p => p.UserId == request.UserId);
            }

            if (request.AccountTypeId.HasValue)
            {
                query.And(p => p.AccountTypeId == request.AccountTypeId);
            }

            if (request.IsActive.HasValue)
            {
                query.And(p => p.IsActive == request.IsActive);
            }

            var list = userRep.Find(query)
                              .OrderByDescending(f => f.FirstName)
                              .ToList();

            return list;
        }
        #endregion
    }
}
