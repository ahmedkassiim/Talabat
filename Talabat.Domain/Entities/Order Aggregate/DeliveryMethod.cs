namespace Talabat.Domain.Entities.Order_Aggregate
{
    public class DeliveryMethod : BaseEntity
    {

        public string ShortName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string DeliveryTime { get; set; } = default!;
        public decimal Cost { get; set; }

    }
}
