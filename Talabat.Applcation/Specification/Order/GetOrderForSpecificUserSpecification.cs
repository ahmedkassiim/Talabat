using Talabat.Applcation.Dtos.Order;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Order
{
    public class GetOrderForSpecificUserSpecification :
        Specification<Domain.Entities.Order_Aggregate.Order,
            ResepnseOrderDto>
    {

        public GetOrderForSpecificUserSpecification(int orderId, string buyerEmail)
        {
            AddCriteria(O => O.Id == orderId && O.BuyerEmail == buyerEmail);
            AddSelect(o => new ResepnseOrderDto
            {
                Id = o.Id,
                BuyerEmail = o.BuyerEmail,
                ShippingAddress = o.ShippingAddress,
                DeliveryName = o.Delivery.ShortName,
                DeliveryCost = o.Delivery.Cost,
                OrderDate = o.OrderDate.ToString(),
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
            ApplyDisableTracking();

        }
    }
}
