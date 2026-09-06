using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Helper;
using Talabat.Domain.Entities;

namespace Talabat.Applcation.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Apply mapping configurations here
            CreateMap<Product, ProductResponseDto>()
                .ForMember(D => D.ProductBrand, O => O.MapFrom(S => S.ProductBrand.Name))
                .ForMember(D => D.ProductCategory, O => O.MapFrom(S => S.ProductCategory.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<PicUrlResolver>());






        }
    }
}
