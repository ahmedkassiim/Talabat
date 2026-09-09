using System;
using System.Collections.Generic;
using System.Text;

namespace Talabat.Applcation.Dtos.Account
{
    public class UserRegisterDto
    {
        public string FristName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
