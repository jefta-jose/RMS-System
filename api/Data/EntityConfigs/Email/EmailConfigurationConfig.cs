using api.Models.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs.Email;

public class EmailConfigurationConfig: IEntityTypeConfiguration<EmailConfiguration>
{
    
    public void Configure(EntityTypeBuilder<EmailConfiguration> builder)
    {
        builder.ToTable("EmailConfigurations");
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Type)
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