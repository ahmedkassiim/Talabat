namespace Talabat.Domain.Entities.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string PictrueUrl { get; set; } = default!;
        public decimal Price { get; set; }
        public string Category { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public int Quantity { get; set; }
    }
}