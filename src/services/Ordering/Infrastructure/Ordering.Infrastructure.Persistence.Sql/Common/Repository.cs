using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Infrastructure.Persistence.Sql.Contexts;

namespace Ordering.Infrastructure.Persistence.Sql.Common
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly OrderDbContext context;
        private readonly DbSet<T> _query;

        public Repository(OrderDbContext context)
        {
            this.context = context;
            _query = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _query.ToListAsync();
        }
        public virtual async Task<T> GetById(object id)
        {
            return await _query.FindAsync(id);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> @where)
        {
            return await _query.AnyAsync(where);
        }

        public async Task Create(T entity)
        {
            await _query.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(T entity)
        {
            _query.Remove(entity);
        }
        public async Task Delete(IEnumerable<T> entities)
        {
            _query.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> where)
        {
            return await _query.FirstOrDefaultAsync(where);
        }
    }
}
