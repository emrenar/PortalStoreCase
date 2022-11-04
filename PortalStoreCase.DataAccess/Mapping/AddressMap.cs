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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AddressLine).HasMaxLength(250);
            builder.Property(c => c.Country).HasMaxLength(30);
            builder.Property(c => c.City).HasMaxLength(30);
            builder.Property(c => c.District).HasMaxLength(30);
        }
    }
}
