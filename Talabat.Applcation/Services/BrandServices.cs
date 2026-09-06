using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Specification.Brand;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    public class BrandServices<T, TResult> : IBrandServices<Brand, BrandResponseDto>
    {
        private readonly IGenericRepository<Brand, BrandResponseDto> _repo;

        public BrandServices(IGenericRepository<Brand,BrandResponseDto> repo)
        {
            _repo = repo;
        }
        public async Task<IReadOnlyList<BrandResponseDto>> GetAllBrands()
        {

          var brands = await _repo.GetAllWithSpec(new GetAllBrandSpecification());

           return brands; 
        }
    }
}
