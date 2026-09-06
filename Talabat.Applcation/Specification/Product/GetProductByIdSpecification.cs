using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Product
{
    public class GetProductByIdSpecification : Specification<Domain.Entities.Product,ProductResponseDto>
    {
        private readonly IConfiguration _configuration;

        public GetProductByIdSpecification(int Id, IConfiguration configuration)       
        {

            _configuration = configuration;
            var baseUrl = _configuration.GetSection("appSettings:BaseUrl").Value;
            AddCriteria(p => p.Id == Id);
            AddSelect(P => new ProductResponseDto
            {
                Id = P.Id,
                Name = P.Name,
                Description = P.Description,
                Price = P.Price,
                PictureUrl = $"{baseUrl}/{P.PictureUrl}",
                ProductBrand = P.ProductBrand.Name,
                BrandId = P.BrandId,
                ProductCategory = P.ProductCategory.Name,
                CategoryId = P.CategoryId   
            });
            ApplyDisableTracking();
           
        }
    }
}
