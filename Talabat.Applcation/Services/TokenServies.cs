using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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

        public string GenerateToken(ApplcationUser user)
        {
            if (user is not null)
            {

                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim("Name", user.UserName!));
                userClaims.Add(new Claim(ClaimTypes.Email, user.Email!));
                userClaims.Add(new Claim("UserId", user.Id));
                // userClaims.Add(new Claim(ClaimTypes.Role ,user.Rol)

                var secretKey = _configuration["ApiSettings:secretkey"];
                if(secretKey != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                    var token = new JwtSecurityToken(
                        claims: userClaims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

                        );
                    var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return stringToken;
                   }
               
                }
            return string.Empty;
        }
    }
}
