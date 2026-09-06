using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Entities;

namespace Talabat.Applcation.Helper
{
    internal class PicUrlResolver : IValueResolver<Product, ProductResponseDto, string>
    {
        private readonly IConfiguration _configuration;

       
        public PicUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {      
                var baseUrl = _configuration.GetSection("ApiSettings:BaseUrl").Value;
                return $"{baseUrl}/{source.PictureUrl}";
            }
            return null!;
        }
    }
}
