using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Applcation.Specification.Order
{
    public class GetSelectedItemOnBasketSpecification
        : Domain.Specification.Specification<Domain.Entities.Products.Product, ProductOrdredItem>

    {

        public GetSelectedItemOnBasketSpecification(IEnumerable<int> basketItemsIds)
        {
            var ids = basketItemsIds.ToList();
            AddCriteria(p => ids.Contains(p.Id));
            AddSelect(P => new ProductOrdredItem
            {
                ProductId = P.Id,
                ProductName = P.Name,
                PictureUrl = P.PictureUrl,
            });
            ApplyDisableTracking();
        }
    }
}
