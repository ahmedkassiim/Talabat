using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Product
{
    public class GetProductsCountSpecification : Specification<Domain.Entities.Products.Product, int>
    {

        public GetProductsCountSpecification(ProductSpecParams specParams)
        {

            AddCriteria(P => (!specParams.CategoryId.HasValue || P.CategoryId == specParams.CategoryId)
             && (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId));

            ApplyDisableTracking();

        }
    }
}
