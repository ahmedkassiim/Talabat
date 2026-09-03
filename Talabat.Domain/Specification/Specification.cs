using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.Domain.Specification
{
    public abstract class Specification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; private set; }
        public Collection<Expression<Func<T, object>>> Includes { get; set; } = new Collection<Expression<Func<T, object>>>();
        public bool DisableTracking { get; set; }
        public Expression<Func<T, object>> OrdeBy { get; private set; } = default!;
        public Expression<Func<T, object>> OrderByDescending { get; private set; } = default!;  

        protected Specification()
        {
        }
        protected void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrdeBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByExpression)
        {
            OrderByDescending = orderByExpression;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyDisableTracking()
        {
            DisableTracking = true;

        }
    }
}
