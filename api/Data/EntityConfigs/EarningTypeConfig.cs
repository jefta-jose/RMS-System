using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class EarningTypeConfig : IEntityTypeConfiguration<EarningType>
    {
        public void Configure(EntityTypeBuilder<EarningType> builder)
        {
            builder.ToTable("EarningTypes");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID)
                    .ValueGeneratedOnAdd();
            builder.Property(p => p.EarningTypeID)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.HasMany(e => e.Resources)
                   .WithOne(e => e.EarningType)
                   .HasForeignKey(e => e.EarningTypeID);
        }
    }
}