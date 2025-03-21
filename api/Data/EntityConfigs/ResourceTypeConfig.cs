
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class ResourceTypeConfig : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.ToTable("ResourceTypes");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID)
                    .ValueGeneratedOnAdd();
            builder.Property(p => p.ResourceTypeId)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
        }
    }
}