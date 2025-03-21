using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class UserLocationConfig : IEntityTypeConfiguration<UserLocation>
    {
        public void Configure(EntityTypeBuilder<UserLocation> builder)
        {
            builder.ToTable("UsersLocations");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserLocationId)
                .ValueGeneratedOnAdd();
        }
    }
}
