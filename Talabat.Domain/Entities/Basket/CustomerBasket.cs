namespace Talabat.Domain.Entities.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; } = default!;
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public CustomerBasket(string id)
        {
            Id = id;
        }
    }
}
