using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Category
{
    internal class GetAllCategorySpecification :Specification<Domain.Entities.Category ,CategoryResponseDto>
    {
        public GetAllCategorySpecification()
        {

            AddSelect(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name
            });

            ApplyDisableTracking();
        }
    }
}
