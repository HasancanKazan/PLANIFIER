using Planifier.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess
{
    public class PlanifierRepository<T> : IPlanifierRepository<T> where T : class
    {
        private PlanifierDatabaseContext _dbContext;
        private DbSet<T> _dbSet;


        public PlanifierRepository()
        {
            _dbContext = PlanifierRepositoryBase.CreateContext();
            _dbSet = _dbContext.Set<T>();
        }


        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            return _dbContext.SaveChanges();
        }
        public int Update(T obj)
        {
            _dbSet.Add(obj);
            return _dbContext.SaveChanges();
        }
        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> Select(Expression<Func<T, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

    }
}
