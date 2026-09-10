using System.ComponentModel.DataAnnotations;

namespace Talabat.Applcation.Dtos.Account
{
    public class UserRegisterDto
    {
        [Required]
        public string FristName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        public string PhoneNumber { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
