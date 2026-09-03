using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IProductServies _servies;

        public ProductsController(IProductServies servies)
        {
            _servies = servies;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() 
        {
            var products = await _servies.GetProducts();

            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _servies.GetProductById(id);    
            if (product == null)
                return NotFound();
            return Ok(product);
        }

    }
}
