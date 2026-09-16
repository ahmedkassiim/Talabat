using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Infrastructure.Persistence.Configuration.Order
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Order_Aggregate.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order_Aggregate.Order> builder)
        {

            builder.OwnsOne(order => order.ShippingAddress,
                            shippingAddress => shippingAddress.WithOwner());

            builder.Property(order => order.Status)
                .HasConversion(
                 (OStatus) => OStatus.ToString(),
                 (OStatus) => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                 );
            builder.HasOne(order => order.Delivery)
                   .WithMany().
                   OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex("DeliveryMethodId")
                .IsUnique(true);
            builder.Property(order => order.Subtotal)
                   .HasColumnType("decimal(12,2)");

            builder.HasMany(order => order.Items)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
