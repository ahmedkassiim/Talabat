using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Infrastructure.Persistence.Configuration.Order
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.OwnsOne(item => item.Product, product => product.WithOwner());
            builder.Property(item => item.Price)
                   .HasColumnType("decimal(12,2)");

        }
    }
}
