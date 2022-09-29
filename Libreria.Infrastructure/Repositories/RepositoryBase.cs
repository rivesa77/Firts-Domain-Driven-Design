using Libreria.Application.Contracts.Persistence;
using Libreria.Domain.Common;
using Libreria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Libreria.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly LibreriaDbContext context;

        public RepositoryBase(LibreriaDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }



        public async Task DeleteAsync(T Entity)
        {
            context.Set<T>().Remove(Entity);
            await context.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string includeString = null, bool disbledTracking = true)
        {
            IQueryable<T> query = context.Set<T>();
            if (disbledTracking)
                query = query.AsNoTracking();

            if (string.IsNullOrEmpty(includeString))
                query = query.Include(includeString);

            if (predicate != null)
                query = query.Where(predicate);

            if (OrderBy != null)
                return await OrderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            List<Expression<Func<T, object>>> includes = null, bool disbledTracking = true)
        {

            IQueryable<T> query = context.Set<T>();
            if (disbledTracking)
                query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, includes) => current.Include(includes));

            if (predicate != null)
                query = query.Where(predicate);

            if (OrderBy != null)
                return await OrderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        //public async Task<T> GetByIdAsyn(int id) => await context.Set<T>().FindAsync(id); esto es lo mismo que lo de abajo
        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        // Solo en memoria
        public void AddEntity(T entity)
        {
            context.Set<T>().Add(entity);

        }

        // Solo en memoria
        public void UpdateEntity(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        // Solo en memoria
        public void DeleteEntity(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
