
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserID)
                .ValueGeneratedOnAdd();
            builder.HasMany(u_sdl => u_sdl.UserSolutionDeliveryLeaders)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserID)
                .HasPrincipalKey(pk => pk.ID);
            builder.HasOne(u => u.UserRole)
                .WithOne(ur => ur.User)
                .HasForeignKey<UserRole>(ur => ur.UserId);
        }
    }
}