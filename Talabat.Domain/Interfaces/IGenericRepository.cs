using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T?> GetById(int Id);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
        Task<T?> GetWithSpec(ISpecification<T> spec);


    }
}
