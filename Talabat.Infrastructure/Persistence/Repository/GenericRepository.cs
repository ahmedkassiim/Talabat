using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplcationDbContext _dbContext;

        public GenericRepository(ApplcationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            if(typeof(T) == typeof(Product))
                return (IEnumerable<T>) await _dbContext.Set<Product>().Include(P => P.ProductBrand).Include(P => P.ProductCategory).AsNoTracking().ToListAsync();
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();


        }

        public async Task<T?> GetById(int Id)   
        {
            if(typeof(T) == typeof(Product))
                    return await _dbContext.Set<Product>().Where(P => P.Id == Id).Include(P => P.ProductBrand).Include(P => P.ProductCategory).AsNoTracking().FirstAsync(e => e.Id == Id) as T;
            var entity = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == Id);
            return entity;
        }
    }
}
