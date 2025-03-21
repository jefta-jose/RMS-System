
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserRoleID)
                .ValueGeneratedOnAdd();
        }
    }
}