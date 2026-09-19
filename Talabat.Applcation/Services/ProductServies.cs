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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public ProductServies(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ProductResponseDto?> GetProductById(int Id)
        {
            var product = await _unitOfWork.Repository<Product>().GetWithSpec(new GetProductByIdSpecification(Id, _configuration));
            return product;
        }

        public async Task<(IReadOnlyList<ProductResponseDto> Products, int TotalCount)> GetProducts(ProductSpecParams specParams)
        {
            var spec = new GetAllProductSpecification(_configuration, specParams);
            var products = await _unitOfWork.Repository<Product>().GetAllWithSpec(spec);
            var count = spec.TotalCount;
            return (products, count);
        }
    }

}



