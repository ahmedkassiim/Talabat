using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Specification.Category;
using Talabat.Domain.Entities.Categorys;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    public class CategoryServices<T, TResult> : ICategoryServices<Category, CategoryResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<IReadOnlyList<CategoryResponseDto>> GetAllCategories()
        {
            var categories = _unitOfWork.Repository<Category>().GetAllWithSpec(new GetAllCategorySpecification());
            return categories;
        }
    }
}
