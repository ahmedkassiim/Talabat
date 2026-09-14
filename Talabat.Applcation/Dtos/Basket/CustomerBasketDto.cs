using System.ComponentModel.DataAnnotations;

namespace Talabat.Applcation.Dtos.Basket
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; } = default!;
        [Required]
        public List<BasketItemDto> Items { get; set; } = default!;

    }
}
