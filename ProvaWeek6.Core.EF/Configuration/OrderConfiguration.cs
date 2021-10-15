using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaWeek6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaWeek6.Core.EF.Configuration
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasIndex(o => o.OrderCode).IsUnique();
            builder.Property(o => o.OrderCode)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(o => o.OrderDate)
                   .IsRequired();
            builder.Property(o => o.ProductCode)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(o => o.Amount)
                    .IsRequired();

            builder.HasOne(o => o.Client)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.ClientId);
        }
    }
}
