using Talabat.Domain.Specification;

namespace Talabat.Domain.Interfaces
{
    public interface IProductServies<TResult>
    {
        public Task<(IReadOnlyList<TResult> Products, int TotalCount)> GetProducts(ProductSpecParams specParams);

        public Task<TResult?> GetProductById(int Id);


    }
}
