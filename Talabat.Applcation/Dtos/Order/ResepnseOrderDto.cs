using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Applcation.Dtos.Order
{
    public class ResepnseOrderDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; } = default!;
        public string? DeliveryName { get; set; }
        public decimal? DeliveryCost { get; set; }
        public string Status { get; set; } = default!;
        public string OrderDate { get; set; } = default!;
        public Address ShippingAddress { get; set; } = default!;
        public IEnumerable<OrderItemDto> Items { get; set; } = default!;
        public decimal Subtotal { get; set; } = default!;
        public decimal Total { get; set; } = default!;
    }
}
