using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Applcation.Dtos
{
    public class ResepnseOrderDto
    {
        public string BuyerEmail { get; set; } = default!;
        public string DelvieryMetod { get; set; } = default!;
        public string OrderDate { get; set; } = default!;
        public string Status { get; set; } = default!;
        public Address ShippingAddress { get; set; } = default!;
        public int? DeliveryMethodId { get; set; }
        public DeliveryMethod? Delivery { get; set; }
        public ICollection<OrderItem> Items { get; set; } = default!;
        public decimal Subtotal { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
