using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

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
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts([FromQuery] string? sorting ,int? categoryId,int? brandId)
        {
            var products = await _servies.GetProducts(sorting, categoryId, brandId);
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _servies.GetProductById(id);    
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        //[HttpGet("Id/{id}")]
        //public async Task<ActionResult<Product>> GetById(int id)
        //{
        //    var product = await _servies.GetByIdProduct(id);    
        //    if (product == null)
        //        return NotFound();
        //    return Ok(product);
        //}

    }
}
