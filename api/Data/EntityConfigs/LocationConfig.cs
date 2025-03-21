
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.LocationID)
                .ValueGeneratedOnAdd();
        }
    }
}