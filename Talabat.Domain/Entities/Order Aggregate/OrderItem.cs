namespace Talabat.Domain.Entities.Order_Aggregate
{
    public class OrderItem : BaseEntity
    {
        public ProductOrdredItem Product { get; set; } = default!;

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
