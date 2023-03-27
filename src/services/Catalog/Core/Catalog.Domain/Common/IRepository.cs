using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.Domain.Common
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Get(Expression<Func<T, bool>> where);
        Task<bool> Any(Expression<Func<T, bool>> where);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
