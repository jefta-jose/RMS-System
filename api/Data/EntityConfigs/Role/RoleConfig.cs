using api.Models.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs.Role;

public class RoleConfig: IEntityTypeConfiguration<Models.Roles.Role>
{
    public void Configure(EntityTypeBuilder<Models.Roles.Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasIndex(a => a.Name).IsUnique();
        builder.HasIndex(a => a.Slug).IsUnique();
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        // Configure many-to-many relationship
        builder.HasMany(a => a.Permissions)
            .WithMany(b => b.Roles)
            .UsingEntity<RolePermission>(
                j => j
                    .HasOne(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionId),
                j => j
                    .HasOne(rp => rp.Role)
                    .WithMany(r => r.RolePermissions)
                    .HasForeignKey(rp => rp.RoleId),
                j =>
                {
                    j.HasKey(t => new { t.RoleId, t.PermissionId });
                    j.ToTable("RolePermissions");
                });
    }
}