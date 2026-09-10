using Microsoft.AspNetCore.Identity;
using Talabat.Domain.Entities.Accounts;

namespace Talabat.Domain.Interfaces
{
    public interface ITokenServies
    {
        Task<string> GenerateTokenAsync(ApplcationUser user, UserManager<ApplcationUser> userManager);
    }
}
