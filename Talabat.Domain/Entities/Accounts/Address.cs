namespace Talabat.Domain.Entities.Accounts
{
    public class Address :BaseEntity
    {

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;

        public string ApplcationUserId { get; set; } = default!;
        public ApplcationUser User { get; set; } = default!;



    }
}