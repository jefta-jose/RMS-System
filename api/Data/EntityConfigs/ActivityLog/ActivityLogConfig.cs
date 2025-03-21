using Microsoft.EntityFrameworkCore;

namespace api.Models.ActivityLog
{
    public class ActivityLogConfig : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ActivityLog> builder)
        {
            builder.ToTable("ActivityLogs");
            builder.HasKey(activityLog => activityLog.Id);
            builder.Property(activityLog => activityLog.ActivityType).IsRequired();
            builder.Property(activityLog => activityLog.CreatedAt).HasColumnType("datetime2");
            builder.Property(activityLog => activityLog.Description).IsRequired();
            builder.Property(activityLog => activityLog.IpAddress).IsRequired();
            builder.Property(activityLog => activityLog.Url).IsRequired();

            builder.HasOne(activityLog => activityLog.Creator)
            .WithMany()
            .HasForeignKey(activityLog => activityLog.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}