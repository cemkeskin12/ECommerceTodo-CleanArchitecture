using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = true, CancellationToken cancellationToken = default);
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<List<T>> TestAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int currentPage = 0, int pageSize = 10, bool isAscending = true,
           bool enableTracking = true, CancellationToken cancellationToken = default);
    }
}
