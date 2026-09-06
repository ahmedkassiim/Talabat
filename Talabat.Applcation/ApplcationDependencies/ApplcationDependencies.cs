using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Helper;
using Talabat.Applcation.Mapper;
using Talabat.Applcation.Services;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.ApplcationDependencies
{
    public static class ApplcationDependencies
    {
        public static IServiceCollection ApplyApplcationDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductServies<>), typeof(ProductServies<>));
            services.AddScoped(typeof(IBrandServices<,>), typeof(BrandServices<,>));
            services.AddScoped(typeof(ICategoryServices<,>), typeof(CategoryServices<,>));
            services.AddScoped<PicUrlResolver>();
            services.AddAutoMapper(P => P.AddProfile<MappingProfile>());
            return services;
        }

    }
}
