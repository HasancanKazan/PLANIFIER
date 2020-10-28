using Planifier.DataAccess;
using Planifier.DataAccess.Abstract;
using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.BusinessLogicLayer.User
{
    public class UserManager
    {
        private IPlanifierRepository<USER> userRepo;

        //public void Test()
        //{
        //    using (IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext()))
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



        public void UserExist(USER request)
        {
            using (IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext()))
            {
                userRepo = uow.GetRepository<USER>();

                var user = userRepo.FindOne(u => u.UserName == request.UserName);

                uow.SaveChanges();
            }

        }
    }
}
