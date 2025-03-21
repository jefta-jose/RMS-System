using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class AllocationConfig : IEntityTypeConfiguration<Allocation>
    {
        public void Configure(EntityTypeBuilder<Allocation> builder)
        {
            builder.ToTable("Allocations");
            builder.Property(a => a.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
            builder.Property(a => a.AllocationID)
                .ValueGeneratedOnAdd();
            builder.HasOne(a => a.ProjectResource)
                .WithMany(p => p.Allocations)
                .HasForeignKey(a => a.ProjectResourceID);
            builder.HasOne(a => a.Project)
                .WithMany(p => p.Allocations)
                .HasForeignKey(a => a.ProjectID);
            builder.HasOne(a => a.Resource)
                .WithMany(r => r.Allocations)
                .HasForeignKey(a => a.ResourceID);
            builder.HasOne<Status>(s=>s.Status)
                .WithMany(a => a.Allocations)
                .HasForeignKey(a => a.BillType);
            builder.Property(a => a.Hours)
            .HasColumnType("decimal(4,2)");
        }
    }
}