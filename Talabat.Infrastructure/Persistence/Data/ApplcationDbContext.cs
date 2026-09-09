using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Entities.Brands;
using Talabat.Domain.Entities.Categorys;
using Talabat.Domain.Entities.Products;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class ApplcationDbContext :IdentityDbContext<ApplcationUser>
    {

        public ApplcationDbContext(DbContextOptions<ApplcationDbContext> options):base(options) 
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
        public DbSet<Address> Addresses { get; set; }
    }
}
