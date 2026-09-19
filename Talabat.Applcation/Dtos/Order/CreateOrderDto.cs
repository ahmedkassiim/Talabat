using System.ComponentModel.DataAnnotations;

namespace Talabat.Applcation.Dtos.Order
{
    public class CreateOrderDto
    {
        [Required]
        public string BasketId { get; set; } = default!;
        [Required]
        [DeniedValues(0, ErrorMessage = "The DeliveryMethodId Value not equles Zero :(")]
        public int DeliveryMethodId { get; set; } = default!;
        [Required]
        public AddressDto ShippingAddress { get; set; } = default!;
    }
}
