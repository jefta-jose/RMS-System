
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class ResourceLocationConfig : IEntityTypeConfiguration<ResourceLocation>
    {
        public void Configure(EntityTypeBuilder<ResourceLocation> builder)
        {
            builder.ToTable("ResourceLocations");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID)
                    .ValueGeneratedOnAdd();
            builder.Property(p => p.ResourceLocationID)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
        }
    }
}