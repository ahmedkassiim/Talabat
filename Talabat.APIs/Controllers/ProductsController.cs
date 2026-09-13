using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Helper;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Interfaces;
using Talabat.Domain.Specification;

namespace Talabat.APIs.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IProductServies<ProductResponseDto> _servies;

        public ProductsController(IProductServies<ProductResponseDto> servies)
        {
            _servies = servies;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<Pagenation<ProductResponseDto>>>> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var result = await _servies.GetProducts(specParams);
            return Ok(new Pagenation<ProductResponseDto>(specParams.PageSize, specParams.PageIndex, result.TotalCount, result.Products));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _servies.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }


    }
}
