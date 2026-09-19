namespace Talabat.Domain.Entities.Order_Aggregate
{
    public class Order : BaseEntity
    {


        private Order()
        {

        }

        public Order(string buyerEmail, Address shippingAddress, int? deliveryMethodId, ICollection<OrderItem> items, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethodId = deliveryMethodId;
            Items = items;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; } = default!;
        public DateTimeOffset? OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShippingAddress { get; set; } = default!;
        public int? DeliveryMethodId { get; set; }
        public DeliveryMethod? Delivery { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal Subtotal { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}

