using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaWeek6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaWeek6.Core.EF.Configuration
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ClientCode)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(c => c.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(c => c.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Client);
        }
    }
}
