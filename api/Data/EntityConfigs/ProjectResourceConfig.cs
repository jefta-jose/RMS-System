using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class ProjectResourceConfig : IEntityTypeConfiguration<ProjectResource>
    {
        public void Configure(EntityTypeBuilder<ProjectResource> builder)
        {
            builder.ToTable("ProjectResources");
            builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
            builder.Property(p => p.ProjectResourceId)
                .ValueGeneratedOnAdd();
            builder.HasOne<Project>(pr => pr.Project)
                .WithMany(p => p.ProjectResources)
                .HasForeignKey(pr => pr.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne<Resource>(pr => pr.Resource)
                .WithMany(r => r.ProjectResources)
                .HasForeignKey(pr => pr.ResourceId);
            builder.HasOne<Status>(s => s.Status)
                .WithMany(r => r.ProjectResources)
                .HasForeignKey(pr => pr.BillType);
            builder.Property(pr => pr.HoursPerWeek)
            .HasColumnType("decimal(4,2)");
        }
    }
}
