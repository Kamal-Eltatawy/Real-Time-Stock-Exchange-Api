using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainServices.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> GetAllIncludingAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include);
        Task DeleteAsync(int id);
    }
}
