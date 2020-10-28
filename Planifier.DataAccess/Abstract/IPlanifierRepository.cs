using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess.Abstract
{
    public interface IPlanifierRepository<T>
    {
        void Add(T obj);
        int Insert(T obj);
        int Delete(T obj);
        int Update(T obj);
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
        Task<T> FindOne(Expression<Func<T, bool>> where);
        Task<T> GetById(object id);
    }
}
