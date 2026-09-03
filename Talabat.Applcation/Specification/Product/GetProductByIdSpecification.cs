using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Product
{
    public class GetProductByIdSpecification : Specification<Domain.Entities.Product>
    {
        public GetProductByIdSpecification(int Id)
            
        {

            AddCriteria(p => p.Id == Id);
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductBrand);
            ApplyDisableTracking();
        }
    }
}
