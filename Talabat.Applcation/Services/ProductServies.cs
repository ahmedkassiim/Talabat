using Microsoft.Extensions.Configuration;
using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Specification.Product;
using Talabat.Domain.Entities.Products;
using Talabat.Domain.Interfaces;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Services
{
    public class ProductServies<TResult> : IProductServies<ProductResponseDto>
    {
        private readonly IGenericRepository<Product, ProductResponseDto> _repo;
        private readonly IConfiguration _configuration;
        public ProductServies(IGenericRepository<Product, ProductResponseDto> repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public async Task<ProductResponseDto?> GetProductById(int Id)
        {
            var product = await _repo.GetWithSpec(new GetProductByIdSpecification(Id, _configuration));
            return product;
        }

        public async Task<(IReadOnlyList<ProductResponseDto> Products, int TotalCount)> GetProducts(ProductSpecParams specParams)
        {
            var spec = new GetAllProductSpecification(_configuration, specParams);
            var products = await _repo.GetAllWithSpec(spec);
            var count = spec.TotalCount;
            return (products, count);
        }
    }

}



