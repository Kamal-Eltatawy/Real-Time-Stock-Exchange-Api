using Infrastructure.Context;
using DomainServices.Repository;
using DomainServices.Services.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RealTimeContext _context;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;

        public UnitOfWork(RealTimeContext context, IServiceProvider serviceProvider)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _serviceProvider.GetService(typeof(IRepository<TEntity>)) as IRepository<TEntity>;
        }

        public async Task<int> SaveChangesAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }

            try
            {
                var result = await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await DisposeAsync();
            }
        }

        private async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            _context.Dispose();
        }

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }
    }
}
