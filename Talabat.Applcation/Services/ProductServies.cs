using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Specification.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Applcation.Services
{
    public class ProductServies : IProductServies
    {
        private readonly IGenericRepository<Product> _repo;
     
        public ProductServies(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _repo.GetAllWithSpec(new GetAllProductSpecification());
            return products;
        }
        public Task<Product?> GetProductById(int Id)
        {
           var product  = _repo.GetWithSpec(new GetProductByIdSpecification(Id));
            return product; 
        }

    }
}
