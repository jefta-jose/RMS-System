using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class StatusGroupConfig : IEntityTypeConfiguration<StatusGroup>
    {
        public void Configure(EntityTypeBuilder<StatusGroup> builder)
        {
            builder.ToTable("StatusGroups");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.StatusGroupID)
                .ValueGeneratedOnAdd();
            builder.HasMany(s => s.Statuses)
                .WithOne(s => s.StatusGroup)
                .HasForeignKey(s => s.StatusGroupID)
                .HasPrincipalKey(s => s.ID);
        }
    }
}
