using api.Models.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs.Role;

public class PermissionConfig : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasIndex(a => a.Name).IsUnique();
        builder.HasIndex(a => a.Slug).IsUnique();
        // Configure many-to-many relationship
        builder.HasMany(a => a.Roles)
            .WithMany(b => b.Permissions)
            .UsingEntity<RolePermission>(
                j => j
                    .HasOne(rp => rp.Role)
                    .WithMany(r => r.RolePermissions)
                    .HasForeignKey(rp => rp.RoleId),
                j => j
                    .HasOne(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionId),
                j =>
                {
                    j.HasKey(t => new { t.RoleId, t.PermissionId });
                    j.ToTable("RolePermissions");
                });
    }
}