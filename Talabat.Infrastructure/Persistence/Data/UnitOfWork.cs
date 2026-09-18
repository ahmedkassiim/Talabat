using System.Collections;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Repository;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplcationDbContext _dbContext;
        private readonly Hashtable _reponstories;
        public UnitOfWork(ApplcationDbContext dbContext)
        {
            _dbContext = dbContext;
            _reponstories = new Hashtable();


        }
        public Task<int> ComplateAsync() => _dbContext.SaveChangesAsync();
        public ValueTask DisposeAsync() => _dbContext.DisposeAsync();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var key = typeof(TEntity).Name;

            if (!_reponstories.ContainsKey(key))
            {
                _reponstories.Add(key, new GenericRepository<TEntity>(_dbContext));
            }
            return _reponstories[key] as IGenericRepository<TEntity>;
        }
    }
}