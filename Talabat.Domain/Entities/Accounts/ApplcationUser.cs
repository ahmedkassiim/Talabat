using Microsoft.AspNetCore.Identity;

namespace Talabat.Domain.Entities.Accounts
{
    public class ApplcationUser : IdentityUser
    {

        public string DisplayName { get; set; } = default!;

        public virtual Address? Address { get; set; }
    }
}
