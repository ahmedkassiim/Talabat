using Talabat.Applcation.Dtos.Order;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Order
{
    public class GetAllOrdersForSpecificUserSpecification
        : Specification<Domain.Entities.Order_Aggregate.Order, ResepnseOrderDto>
    {

        public GetAllOrdersForSpecificUserSpecification(string buyerEmail)
        {
            AddCriteria(O => O.BuyerEmail == buyerEmail);
            AddSelect(o => new ResepnseOrderDto
            {
                BuyerEmail = o.BuyerEmail,
                ShippingAddress = o.ShippingAddress,
                DeliveryName = o.Delivery.ShortName,
                DeliveryCost = o.Delivery.Cost,
                Items = o.Items.Select(item => new OrderItemDto
                {
                    Id = item.Id,
                    ProductName = item.Product.ProductName,
                    PictureUrl = item.Product.PictureUrl,
                    Price = item.Price,
                    Quantity = item.Quantity


                }),
                Status = o.Status.ToString(),
                Subtotal = o.Subtotal,
                Total = o.Subtotal + o.Delivery.Cost
            });
            AddOrderByDescending(o => o.OrderDate);
            ApplyDisableTracking();
        }

    }
}
