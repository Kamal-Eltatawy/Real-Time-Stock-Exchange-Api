using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using DomainServices.Repository;
using Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RealTimeContext _context;

        public Repository(RealTimeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsQueryable().ToListAsync();
        }
        public async Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().AnyAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

      

        public async Task<List<TEntity>> GetAllIncludingAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include)
        {
            return await _context.Set<TEntity>()
                                 .AsNoTracking()
                                 .Where(predicate)
                                 .Include(include)
                                 .ToListAsync();
        }

        public async Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);

            }
        }

    }
}


