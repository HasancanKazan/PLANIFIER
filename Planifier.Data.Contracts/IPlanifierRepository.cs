using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.Data.Contracts
{
    public interface IPlanifierRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task<T> GetAsync(T id);
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll(int skip, int take);
        IQueryable<T> GetAll(int skip, int take, Expression<Func<T, bool>> expression);
    }
}
