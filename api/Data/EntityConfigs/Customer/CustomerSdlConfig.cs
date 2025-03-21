namespace api.Data.EntityConfigs.Customer
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using api.Models;

    public class CustomerSdlConfig : IEntityTypeConfiguration<CustomerSdl>
    {
        public void Configure(EntityTypeBuilder<CustomerSdl> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
            builder.Property(e => e.CustomerID).IsRequired();
            builder.Property(e => e.SolutionDeliveryLeaderID).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.CreatedDTM).IsRequired();
            builder.Property(e => e.UpdatedBy);
            builder.Property(e => e.UpdatedDTM);
            builder.Property(e => e.DeletedBy);
            builder.Property(e => e.DeletedDTM);
        }
    }
}