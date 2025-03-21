
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class SolutionDeliveryLeaderConfig : IEntityTypeConfiguration<SolutionDeliveryLeader>
    {
        public void Configure(EntityTypeBuilder<SolutionDeliveryLeader> builder)
        {
            builder.ToTable("SolutionDeliveryLeaders");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.SolutionDeliveryLeaderID)
                .ValueGeneratedOnAdd();
        }
    }
}