using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace api.Data.EntityConfigs.Intacct
{
    public class IntacctTimesheetConfig : IEntityTypeConfiguration<IntacctTimesheet>
    {
        public void Configure(EntityTypeBuilder<IntacctTimesheet> builder)
        {
            builder.ToTable("IntacctTimesheets");
            builder.HasKey(timesheet => timesheet.ID);
            builder.Property(timesheet => timesheet.EmployeeID).IsRequired();
            builder.Property(timesheet => timesheet.TimeSheetBeginDate).HasColumnType("datetime2");
            builder.Property(timesheet => timesheet.EntryDate).HasColumnType("datetime2");
            builder.HasIndex(x => new { x.EmployeeID, x.ProjectID, x.CustomerID, x.EntryDate, x.TimeSheetBeginDate, x.Hours, x.Task, x.Notes })
                .IsUnique();
        }
    }
}