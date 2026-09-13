using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public partial interface ISpecification<TEntity, TResult> where TEntity : BaseEntity
    {

        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public Collection<Expression<Func<TEntity, object>>> Includes { get; }
        public Expression<Func<TEntity, TResult>> SelectPredicate { get; }

        public Expression<Func<TEntity, object>> OrdeBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }
        public bool DisableTracking { get; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public int TotalCount { get; set; }

    }
}
