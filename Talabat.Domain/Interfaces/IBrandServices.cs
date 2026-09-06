using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IBrandServices<T,TResult> where T : BaseEntity
    {
        Task<IReadOnlyList<TResult>> GetAllBrands();
    }
}
