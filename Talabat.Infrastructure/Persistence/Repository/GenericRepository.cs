using Microsoft.EntityFrameworkCore;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Specification;

namespace Talabat.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplcationDbContext _dbContext;


        public GenericRepository(ApplcationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<TResult>> GetAllWithSpec<TResult>(ISpecification<T, TResult> spec)
        {
            var query = await ApplySpecification(spec).ToListAsync();
            return query;

        }

        public async Task<TResult?> GetWithSpec<TResult>(ISpecification<T, TResult> spec)
        {
            var entity = await ApplySpecification(spec).FirstOrDefaultAsync();
            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> spec)
        {

            return SpecificationEvaluator<T, TResult>.GetQuery(_dbContext.Set<T>(), spec);
        }

    }
}
