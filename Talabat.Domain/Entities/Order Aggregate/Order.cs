namespace Talabat.Domain.Entities.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public string BuyerEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShippingAddress { get; set; } = default!;
        public int? DeliveryMethodId { get; set; }
        public DeliveryMethod? Delivery { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal Subtotal { get; set; }
        public decimal GetTotal() => Subtotal + Delivery?.Cost ?? decimal.Zero;
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}

