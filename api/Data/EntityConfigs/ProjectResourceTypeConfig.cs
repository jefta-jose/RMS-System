using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace api.EF.EntityConfigs
{
    public class ProjectResourceTypeConfig : IEntityTypeConfiguration<ProjectResourceType>
    {
        public void Configure(EntityTypeBuilder<ProjectResourceType> builder)
        {
            builder.ToTable("ProjectResourceTypes");
            builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
            builder.Property(p => p.projectResourceTypeId)
                .ValueGeneratedOnAdd();
            builder.HasOne<ResourceType>(rs => rs.ResourceType)
            .WithMany(prs => prs.ProjectResourceTypes)
            .HasForeignKey(rs => rs.ResourceTypeId);

            builder.HasOne<Project>(pr => pr.Project)
            .WithMany(p => p.ProjectResourceTypes)
            .HasForeignKey(pr => pr.ProjectId);
        }
    }
}