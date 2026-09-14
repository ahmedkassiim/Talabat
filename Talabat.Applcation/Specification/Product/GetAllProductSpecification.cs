using Microsoft.Extensions.Configuration;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Product
{
    public class GetAllProductSpecification : Specification<Domain.Entities.Products.Product, ProductResponseDto>
    {
        private readonly IConfiguration _configuration;
        public GetAllProductSpecification(IConfiguration configuration, ProductSpecParams specParams) : base()
        {

            _configuration = configuration;
            var baseUrl = _configuration.GetSection("appSettings:BaseUrl").Value;

            AddCriteria(P =>
            (string.IsNullOrEmpty(specParams.Search)) || (P.NormalizedName.Contains(specParams.Search) &&
            (!specParams.CategoryId.HasValue || P.CategoryId == specParams.CategoryId)
            && (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId)));

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

            switch (specParams.Sorting)
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


            ApplyPagination((specParams.PageSize * (specParams.PageIndex - 1)), specParams.PageSize);
            ApplyDisableTracking();
        }
    }
}
