using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.EntityConfigs
{
    public class UserRoleSolutionDeliveryLeaderConfig : IEntityTypeConfiguration<UserRoleSolutionDeliveryLeader>
    {
        public void Configure(EntityTypeBuilder<UserRoleSolutionDeliveryLeader> builder)
        {
            builder.ToTable("UserRoleSolutionDeliveryLeaders");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserRoleSolutionDeliveryLeaderID)
                .ValueGeneratedOnAdd();
            builder.HasOne(x => x.UserRole)
                .WithMany()
                .HasForeignKey(x => x.UserRoleID);
            builder.HasOne(x => x.SolutionDeliveryLeader)
                .WithMany()
                .HasForeignKey(x => x.SolutionDeliveryLeaderID);
        }
    }
}
