
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class UserPreferenceConfig : IEntityTypeConfiguration<UserPreference>
    {
        public void Configure(EntityTypeBuilder<UserPreference> builder)
        {
            builder.ToTable("UserPreferences");
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(p => p.UserPreferenceID)
                .ValueGeneratedOnAdd();
            builder.HasOne(p => p.User)
                .WithOne(u => u.UserPreference)
                .HasForeignKey<UserPreference>(p => p.UserID);
        }
    }
}