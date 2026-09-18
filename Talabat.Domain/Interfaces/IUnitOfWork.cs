using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task<int> ComplateAsync();

    }
}
