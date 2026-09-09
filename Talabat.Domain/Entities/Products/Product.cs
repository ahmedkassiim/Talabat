using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities.Brands;
using Talabat.Domain.Entities.Categorys;

namespace Talabat.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public Brand ProductBrand { get; set; } = default!;
        public Category ProductCategory { get; set; } = default!;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
