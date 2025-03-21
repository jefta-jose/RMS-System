using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
            builder.Property(p => p.ProjectID)
                .ValueGeneratedOnAdd();
            builder.HasOne<Customer>(p => p.Customer)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CustomerID);
            builder.HasOne<Status>(p => p.Status)
                .WithMany(st => st.Projects)
                .HasForeignKey(p => p.StatusId);
            builder.HasOne<SolutionDeliveryLeader>(p => p.SolutionDeliveryLeader)
                .WithMany(lc => lc.Projects)
                .HasForeignKey(p => p.SolutionDeliveryLeaderID)
                // Set the delete behavior to set null so that when a project is deleted, the column is set to NULL.
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}