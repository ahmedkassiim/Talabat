using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Domain.Entities.Accounts;

namespace Talabat.Infrastructure.Persistence.Configuration
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street)
               .HasMaxLength(256)
               .IsRequired();
            builder.Property(a => a.City)
               .HasMaxLength(256)
               .IsRequired();
            builder.Property(a => a.Country)
               .HasMaxLength(256)
               .IsRequired();
            builder.Property(a => a.FirstName)
               .HasMaxLength(256)
               .IsRequired();
            builder.Property(a => a.LastName)
               .HasMaxLength(256)
               .IsRequired();
            builder.HasOne(a => a.User)
                   .WithOne(u => u.Address)
                   .HasForeignKey<Address>(u => u.ApplcationUserId);

        }
    }
}
