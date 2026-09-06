using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Specification;

namespace Talabat.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T,TResult> : IGenericRepository<T,TResult> where T : BaseEntity
    {
        private readonly IQueryable<T> _dbSet;

        public GenericRepository(ApplcationDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }
        public async Task<IReadOnlyList<TResult>> GetAllWithSpec(ISpecification<T,TResult> spec)
        {
           var query = await ApplySpecification(spec).ToListAsync();
           return query;
        
        }
        public async Task<TResult?> GetWithSpec(ISpecification<T,TResult> spec)
        {
           var entity = await ApplySpecification(spec).FirstOrDefaultAsync();
           return entity;
        }

        private IQueryable<TResult> ApplySpecification(ISpecification<T,TResult> spec)
        {

            return SpecificationEvaluator<T,TResult>.GetQuery(_dbSet, spec);
        }

    }
}
