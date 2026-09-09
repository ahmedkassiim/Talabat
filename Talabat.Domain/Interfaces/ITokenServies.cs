using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities.Accounts;

namespace Talabat.Domain.Interfaces
{
    public interface ITokenServies
    {
        string GenerateToken(ApplcationUser user);
    }
}
