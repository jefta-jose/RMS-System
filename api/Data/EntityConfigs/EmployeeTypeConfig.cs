using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EF.EntityConfigs
{
    public class EmployeeTypeConfig : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.ToTable("EmployeeTypes");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID)
                    .ValueGeneratedOnAdd();
            builder.Property(p => p.EmployeeTypeID)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.HasMany(e => e.Resources)
                   .WithOne(e => e.EmployeeType)
                   .HasForeignKey(e => e.EmployeeTypeID);
        }
    }
}