using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.StatusID)
                .ValueGeneratedOnAdd();
            builder.HasOne(sg => sg.StatusGroup)
                .WithMany(s => s.Statuses)
                .HasForeignKey(s => s.StatusGroupID);
        }
    }
}
