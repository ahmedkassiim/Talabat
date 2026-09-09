using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talabat.Domain.Entities.Accounts
{
    public class ApplcationUser : IdentityUser
    {

        public string DisplayName { get; set; } = default!;

        public Address? Address { get; set; }
    }
}
