using System;
using System.Collections.Generic;
using System.Text;

namespace Talabat.Applcation.Dtos.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string ProductBrand { get; set; }
        public int BrandId { get; set; }
        public string ProductCategory { get; set; }
        public int CategoryId { get; set; }


    }
}
