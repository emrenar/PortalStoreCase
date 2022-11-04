using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.DataAccess.Mapping
{
    public class SkuMap : IEntityTypeConfiguration<SKU>
    {
        public void Configure(EntityTypeBuilder<SKU> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(250);
            builder.Property(c => c.Price).HasPrecision(16,2);
            builder.Property(c => c.OldPrice).HasPrecision(16,2);           
        }
    }
}
