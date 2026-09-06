using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{

    public class BrandsController : BaseApiController
    {
        private readonly IBrandServices<Brand, BrandResponseDto> _servies;

        public BrandsController(IBrandServices<Brand,BrandResponseDto> servies)
        {
            _servies = servies;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandResponseDto>>> GetAllBrands()
        {
            var brands = await _servies.GetAllBrands();
            return Ok(brands);
        }
    }
}
