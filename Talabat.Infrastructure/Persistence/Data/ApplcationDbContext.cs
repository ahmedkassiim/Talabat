using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class ApplcationDbContext :DbContext
    {

        public ApplcationDbContext(DbContextOptions<ApplcationDbContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
