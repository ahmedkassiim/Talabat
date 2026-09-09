using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities.Accounts;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class ApplcationIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(UserManager<ApplcationUser> userManager)
        {

            if(userManager.Users.Count() <= 0)
            {
            var user = new ApplcationUser()
            {
                DisplayName = "Ahmed Kassim",
                Email = "ahmeedkassimm@gmail.com",
                UserName = "Ahmed.Kassim",
                PhoneNumber = "01026387356"
            };
            await userManager.CreateAsync(user, "123456789P@$$wOrd");
            }
        }
    } 
}
