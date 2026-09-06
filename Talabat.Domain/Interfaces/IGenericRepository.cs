using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IGenericRepository<T,TResult> where T : BaseEntity
    {
 
        Task<IReadOnlyList<TResult>> GetAllWithSpec(ISpecification<T,TResult> spec);
        Task<TResult?> GetWithSpec(ISpecification<T,TResult> spec);


    }
}
