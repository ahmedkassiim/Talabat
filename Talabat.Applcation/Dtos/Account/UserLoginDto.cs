using System.ComponentModel.DataAnnotations;

namespace Talabat.Applcation.Dtos.Account
{
    public record UserLoginDto([Required] string userEmail
        , [Required] string password);
}
