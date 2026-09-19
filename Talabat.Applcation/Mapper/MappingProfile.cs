using AutoMapper;
using Talabat.Applcation.Dtos.Account;
using Talabat.Applcation.Dtos.Basket;
using Talabat.Applcation.Dtos.Order;
using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Helper;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Entities.Basket;
using Talabat.Domain.Entities.Products;

namespace Talabat.Applcation.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Apply mapping configurations here
            CreateMap<Product, ProductResponseDto>()
                .ForMember(D => D.ProductBrand, O => O.MapFrom(S => S.ProductBrand.Name))
                .ForMember(D => D.ProductCategory, O => O.MapFrom(S => S.ProductCategory.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<PicUrlResolver>());


            CreateMap<Address, UserAddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<AddressDto, Domain.Entities.Order_Aggregate.Address>();

        }
    }
}
