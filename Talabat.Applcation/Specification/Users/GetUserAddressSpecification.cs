using Talabat.Applcation.Dtos.Account;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Users
{
    public class GetUserAddressSpecification : Specification<Address, UserAddressDto>
    {
        public GetUserAddressSpecification(ApplcationUser user)
        {
            AddCriteria(A => A.ApplcationUserId == user.Id);
            AddSelect(address => new UserAddressDto
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                Street = address.Street,
                City = address.City,
                Country = address.Country

            });
            ApplyDisableTracking();
        }
    }
}
