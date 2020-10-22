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
        int Insert(T obj);
        int Delete(T obj);
        int Update(T obj);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Select(Expression<Func<T, bool>> where);
        Task<T> GetById(object id);
    }
}
