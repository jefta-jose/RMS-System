using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs.ProjectHealthConfig
{
    public class ProjectHealthConfig : IEntityTypeConfiguration<ProjectHealth>
    {
        public void Configure(EntityTypeBuilder<ProjectHealth> builder)
        {
            builder.ToTable("ProjectHealth");
            builder.Property(p => p.ProjectHealthID)
                .ValueGeneratedOnAdd();
        }

    }
}
