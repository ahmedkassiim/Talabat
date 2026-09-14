using System.ComponentModel.DataAnnotations;

namespace Talabat.Applcation.Dtos.Basket
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = default!;
        [Required]
        public string PictrueUrl { get; set; } = default!;
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; } = default!;
        [Required]
        public string Brand { get; set; } = default!;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
}