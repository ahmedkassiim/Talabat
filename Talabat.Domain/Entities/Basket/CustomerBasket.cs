namespace Talabat.Domain.Entities.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; } = default!;
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }

        public decimal? ShippingPrice { get; set; }
        public int? DeliveryMethodId { get; set; }
        public CustomerBasket(string id)
        {
            Id = id;
        }
    }
}
