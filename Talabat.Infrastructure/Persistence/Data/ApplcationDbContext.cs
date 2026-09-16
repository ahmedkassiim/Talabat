using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Talabat.Domain.Entities.Brands;
using Talabat.Domain.Entities.Categorys;
using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Entities.Products;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class ApplcationDbContext : IdentityDbContext<Domain.Entities.Accounts.ApplcationUser>
    {

        public ApplcationDbContext(DbContextOptions<ApplcationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Domain.Entities.Accounts.Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryMethod> Deliveries { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
