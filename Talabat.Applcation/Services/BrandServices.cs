using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Specification.Brand;
using Talabat.Domain.Entities.Brands;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    public class BrandServices<T, TResult> : IBrandServices<Brand, BrandResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<BrandResponseDto>> GetAllBrands()
        {

            var brands = await _unitOfWork.Repository<Brand>().GetAllWithSpec(new GetAllBrandSpecification());

            return brands;
        }
    }
}
