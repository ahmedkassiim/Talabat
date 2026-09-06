using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Specification.Category;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    public class CategoryServices<T,TResult> : ICategoryServices<Category, CategoryResponseDto>
    {
        private readonly IGenericRepository<Category, CategoryResponseDto> _repo;

        public CategoryServices(IGenericRepository<Category, CategoryResponseDto> repo)
        {
            _repo = repo;
        }
        public Task<IReadOnlyList<CategoryResponseDto>> GetAllCategories()
        {
            var categories = _repo.GetAllWithSpec(new GetAllCategorySpecification());
            return categories;
        }
    }
}
