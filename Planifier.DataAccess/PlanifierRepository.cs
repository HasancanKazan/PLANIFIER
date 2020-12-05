using Planifier.Data.Contracts;
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
        private readonly PlanifierDatabaseContext _dbContext;
        private readonly DbSet<T> _dbSet;


        public PlanifierRepository(PlanifierDatabaseContext databaseContext)
        {
            _dbContext = databaseContext; //PlanifierRepositoryBase.CreateContext();
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public IQueryable<T> GetAll(int skip, int take)
        {
           return _dbSet.Skip(skip).Take(take);
        }

        public IQueryable<T> GetAll(int skip, int take, Expression<Func<T, bool>> expression)
        {
            return GetAll(skip, take).Where(expression);
        }

        public Task<T> GetAsync(T id)
        {
            return _dbSet.FindAsync(id);
        }
    }
}
