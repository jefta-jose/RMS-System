using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs.NavbarMenu;

public class NavbarMenuConfig: IEntityTypeConfiguration<Models.Navbar.NavbarMenu>
{
    public void Configure(EntityTypeBuilder<Models.Navbar.NavbarMenu> builder)
    {
        builder.ToTable("NavbarMenus");
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Url)
            .IsUnique();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.RowVersion)
            .ValueGeneratedOnAddOrUpdate()
            .IsRowVersion();
    }
}