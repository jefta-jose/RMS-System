using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace api.EF.EntityConfigs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
            builder.Property(p => p.CustomerID)
                .ValueGeneratedOnAdd();
            builder.HasMany(c => c.Projects)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerID);
            builder.HasOne<SolutionDeliveryLeader>(x => x.SolutionDeliveryLeader)
                .WithMany(l => l.Customers)
                .HasForeignKey(x => x.SolutionDeliveryLeaderID)
                // Set the delete behavior to set null so that when a SolutionDeliveryLeader is deleted, the resources are also deleted.
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}