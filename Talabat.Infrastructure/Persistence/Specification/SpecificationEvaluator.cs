using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.Infrastructure.Persistence.Specification
{
    internal class SpecificationEvaluator<TEntity,TResult> where TEntity : BaseEntity
    {
        public static IQueryable<TResult> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity,TResult> spec)
        {
            var query = inputQuery.AsQueryable(); // _dbContext.Set<TEntity>().AsNoTracking().Where(E => E.Id == 1)
            IQueryable<TResult> result;

            if (spec.DisableTracking)
            {
                query = query.AsNoTracking();
            }

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); 
            }
            // _dbContext.Set<Product>().AsNoTracking().Where(E => E.Id == 1).Include(P => P.Brand).Include(P => P.Category)
            query = spec.Includes.Aggregate(query, (current, includeexperssion) => current.Include(includeexperssion));
            if (spec.OrdeBy != null)
            {
                query = query.OrderBy(spec.OrdeBy);
            }
            else if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.SelectPredicate != null)
            {
                result = query.Select(spec.SelectPredicate);
            }
            else
            {
                result = query.Cast<TResult>();
            }
            return result;

        }
   
    }
}
