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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplcationDbContext _dbContext;

        public GenericRepository(ApplcationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
           //if(typeof(T) == typeof(Product))
           //    return (IEnumerable<T>) await _dbContext.Set<Product>().Include(P => P.ProductBrand).Include(P => P.ProductCategory).AsNoTracking().ToListAsync();
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();


        }

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
        {
           var query = await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec).ToListAsync();
           return query;
        
        }

        public async Task<T?> GetById(int Id)   
        {
           // if(typeof(T) == typeof(Product))
           //         return await _dbContext.Set<Product>().Where(P => P.Id == Id).Include(P => P.ProductBrand).Include(P => P.ProductCategory).AsNoTracking().FirstAsync(e => e.Id == Id) as T;
            var entity = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == Id);
            return entity;
        }

        public async Task<T?> GetWithSpec(ISpecification<T> spec)
        {
           var entity = await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec).FirstOrDefaultAsync();
           return entity;
        }
    }
}
