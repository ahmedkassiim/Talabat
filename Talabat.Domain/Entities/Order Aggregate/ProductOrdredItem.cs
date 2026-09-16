namespace Talabat.Domain.Entities.Order_Aggregate
{
    public class ProductOrdredItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
    }
}
