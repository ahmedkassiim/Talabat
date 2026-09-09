using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Brand
{
    public class GetAllBrandSpecification : Specification<Domain.Entities.Brands.Brand,BrandResponseDto>
    {

        public GetAllBrandSpecification()
        {
            AddSelect(B => new BrandResponseDto
            {
                Id = B.Id,
                Name = B.Name,
            });


            ApplyDisableTracking();
            
        }
    }
}
