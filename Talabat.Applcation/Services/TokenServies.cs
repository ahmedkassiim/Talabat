using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    internal class TokenServies(IConfiguration configuration) : ITokenServies
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> GenerateTokenAsync(ApplcationUser user, UserManager<ApplcationUser> userManager)
        {
            if (user is not null)
            {

                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Name, user.DisplayName));
                userClaims.Add(new Claim(ClaimTypes.Email, user.Email!));
                var userRoles = await userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var secretKey = _configuration["JWT:secretkey"];
                if (secretKey != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                    var token = new JwtSecurityToken(
                        claims: userClaims,
                        audience: _configuration["JWT:ValidAudience"],
                        issuer: _configuration["JWT:ValidIssuer"],
                        expires: DateTime.UtcNow.AddDays(double.Parse(_configuration["JWT:DurationTime"] ?? "0")),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                        );
                    var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return stringToken;
                }

            }
            return string.Empty;
        }
    }
}
