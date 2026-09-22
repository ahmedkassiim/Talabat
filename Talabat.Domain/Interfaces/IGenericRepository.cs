using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<IReadOnlyList<TResult>> GetAllWithSpec<TResult>(ISpecification<T, TResult> spec);
        Task<TResult?> GetWithSpec<TResult>(ISpecification<T, TResult> spec);

        Task AddAsync(T entity);

        void Update(T entity);
        void Delete(T entity);
    }
}
