using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.ResourceId)
                .ValueGeneratedOnAdd();
            builder.HasOne(x => x.ResourceLevel)
                .WithMany(rl => rl.Resources)
                .HasForeignKey(x => x.ResourceLevelId);
            builder.HasOne(x => x.ResourceType)
                .WithMany(rt => rt.Resources)
                .HasForeignKey(x => x.ResourceTypeId);
            builder.HasOne(p => p.ResourceLocation)
                .WithMany(rt => rt.Resources)
                .HasForeignKey(x => x.ResourceLocationID);
            builder.HasOne(x => x.SolutionDeliveryLeader)
                .WithMany(l => l.Resources)
                .HasForeignKey(x => x.SolutionDeliveryLeaderID)
                // Set the delete behavior to set null so that when a SolutionDeliveryLeader is deleted, the resources are also deleted.
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}