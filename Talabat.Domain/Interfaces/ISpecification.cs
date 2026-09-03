using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface ISpecification<TEntity> where TEntity : BaseEntity
    {
 
        public Expression<Func<TEntity, bool>>? Criteria { get;}
        public Collection<Expression<Func<TEntity, object>>> Includes { get; }

        public Expression<Func<TEntity, object>> OrdeBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }
        public bool DisableTracking { get;  }

    }
}
