using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.Data.Contracts
{
    public interface IPlanifierUnitOfWork : IDisposable
    {
        int SaveChanges();
        IPlanifierRepository<T> GetRepository<T>() where T : class;
    }
}
