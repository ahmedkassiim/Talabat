using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IProductServies<TResult>
    {
        public Task<IEnumerable<TResult>> GetProducts(string? sorting ,int? categoryId , int? brandId);

        public Task<TResult?> GetProductById(int Id);

    }
}
