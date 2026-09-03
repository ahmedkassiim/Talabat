using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Domain.Interfaces
{
    public interface IProductServies
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product?> GetProductById(int Id);
    }
}
