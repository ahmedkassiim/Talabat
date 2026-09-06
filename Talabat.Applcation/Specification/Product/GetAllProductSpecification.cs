using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Product
{
    public class GetAllProductSpecification: Specification<Domain.Entities.Product,ProductResponseDto>
    {
        private readonly IConfiguration _configuration;
        public GetAllProductSpecification(IConfiguration configuration ,string? sorting , int? categoryId, int? brandId):base()
        {

            _configuration = configuration;
            var baseUrl = _configuration.GetSection("appSettings:BaseUrl").Value;

            AddCriteria(P => (!categoryId.HasValue || P.CategoryId == categoryId) 
            && (!brandId.HasValue || P.BrandId == brandId));

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

            switch (sorting)
            {
                case "priceAsc":
                    AddOrderBy(P => P.Price);
                    break;
                case "priceDesc":
                        AddOrderByDescending(P => P.Price);
                    break;
                case "name":
                    AddOrderBy(P => P.Name);
                    break;
                 
                default:
                    AddOrderBy(P => P.Name);
                    break;
            }
            ApplyDisableTracking();
        }
    }
}
