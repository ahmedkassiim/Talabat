using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Product
{
    public class GetAllProductSpecification: Specification<Domain.Entities.Product>
    {


        public GetAllProductSpecification():base()
        {
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductBrand);
        }
    }
}
