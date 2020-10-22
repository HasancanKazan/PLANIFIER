using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess
{
    public class PlanifierRepositoryBase
    {
        private static PlanifierDatabaseContext _db;
        private static object _lock = new object();
        
        public PlanifierRepositoryBase()
        {

        }

        public static PlanifierDatabaseContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lock)
                {
                    _db = new PlanifierDatabaseContext();
                }
            }
            return _db;
        }
    }
}
