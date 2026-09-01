using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(p => p.Id);
           builder.Property(p => p.Id).UseIdentityColumn(1, 1);
           builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
           builder.Property(p => p.Description).IsRequired().HasColumnType("varchar(max)"); 
           builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
           builder.HasOne(P => P.ProductBrand).WithMany().HasForeignKey(P => P.BrandId).IsRequired();
           builder.HasOne(P => P.ProductCategory).WithMany().HasForeignKey(P => P.CategoryId).IsRequired();
           builder.Property(p => p.PictureUrl).IsRequired().HasMaxLength(180).HasColumnType("varchar(180)");
         


        }
    }
}
