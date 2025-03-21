using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class UserSolutionDeliveryLeaderConfig : IEntityTypeConfiguration<UserSolutionDeliveryLeader>
    {
        public void Configure(EntityTypeBuilder<UserSolutionDeliveryLeader> builder)
        {
            builder.ToTable("UserSolutionDeliveryLeaders");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserSolutionDeliveryLeaderId)
                .ValueGeneratedOnAdd();
        }
    }
}
