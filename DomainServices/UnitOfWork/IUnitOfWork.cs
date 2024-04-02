
using DomainServices.Repository;

namespace DomainServices.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
