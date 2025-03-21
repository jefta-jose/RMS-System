using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class UserRoleLocationConfig : IEntityTypeConfiguration<UserRoleLocation>
    {
        public void Configure(EntityTypeBuilder<UserRoleLocation> builder)
        {
            builder.ToTable("UserRolesLocations");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserRoleLocationID)
                .ValueGeneratedOnAdd();
            builder.HasOne(x => x.UserRole)
                .WithMany()
                .HasForeignKey(x => x.UserRoleID);
            builder.HasOne(x => x.Location)
                .WithMany()
                .HasForeignKey(x => x.LocationID);
        }
    }
}
