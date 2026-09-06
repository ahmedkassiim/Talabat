using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Applcation.Dtos.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{
 
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryServices<Category, CategoryResponseDto> _services;

        public CategoriesController(ICategoryServices<Category,CategoryResponseDto> services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryResponseDto>>> GetAllCategories()
        {
            var categories = await _services.GetAllCategories();
            return Ok(categories);
        }
    }
}
