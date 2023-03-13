using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Common;
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Globalization;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext dbContext;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            if(Table is null)
                throw new NullReferenceException("Database Exception. Table is null");

            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToListAsync(cancellationToken: cancellationToken);

            return await queryable.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int currentPage = 1, int pageSize = 5, bool isAscending = true,
            bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);
        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }


        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }



        public async Task<List<T>> TestAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }
    }
}
