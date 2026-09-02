using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Domain.Entities;

namespace Talabat.Infrastructure.Persistence.Configuration
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(B => B.Id);  
            builder.Property(B =>  B.Name).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
        }
    }
}
