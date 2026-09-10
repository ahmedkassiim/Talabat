using System;
using System.Collections.Generic;
using System.Text;

namespace Talabat.Applcation.Dtos.Account
{
    public class LoginDetailsDto
    {

        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;


    }
}
