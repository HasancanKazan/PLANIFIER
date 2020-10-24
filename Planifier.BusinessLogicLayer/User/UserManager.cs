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
        public void Test()
        {
            using (IPlanifierUnitOfWork uow = new PlanifierUnitOfWork(PlanifierRepositoryBase.CreateContext()))
            {
                IPlanifierRepository<ACCOUNT_TYPES> accountRepo = uow.GetRepository<ACCOUNT_TYPES>();

                accountRepo.Add(new ACCOUNT_TYPES()
                {
                    AccountName = "Test",
                    Description = "Test",
                });
                accountRepo.Add(new ACCOUNT_TYPES()
                {
                    AccountName = "Admin",
                    Description = "Tüm Yetkilere Sahip Kullanıcı",
                });

                uow.SaveChanges();
            }

        }
    }
}
