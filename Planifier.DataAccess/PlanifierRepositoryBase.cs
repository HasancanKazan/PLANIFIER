using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess
{
    public class PlanifierRepositoryBase
    {
        //private static PlanifierDatabaseContext _db;
        private static object _lock = new object();
        
        public PlanifierRepositoryBase()
        {

        }

        public static PlanifierDatabaseContext CreateContext(PlanifierDatabaseContext dbContext)
        {
            if (dbContext == null)
            {
                lock (_lock)
                {
                    dbContext = new PlanifierDatabaseContext();
                }
            }
            return dbContext;
        }
    }
}
