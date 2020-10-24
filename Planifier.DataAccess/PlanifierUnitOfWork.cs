using Planifier.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess
{
    public class PlanifierUnitOfWork : IPlanifierUnitOfWork
    {
        private bool disposed = false;
        private readonly PlanifierDatabaseContext _dbContext;

        public PlanifierUnitOfWork(PlanifierDatabaseContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentException($"{nameof(dbContext)} can not be null");
            _dbContext = dbContext;
        }


        public IPlanifierRepository<T> GetRepository<T>() where T : class
        {
            return new PlanifierRepository<T>();
        }


        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        //GC ile ilgili nesneyi bellekten kaldırmış oluyoruz. Bu işi using bloğu içinde uow kullandığımız için otomatik olarak finally metodu dispose u çağırmış oluyor.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
