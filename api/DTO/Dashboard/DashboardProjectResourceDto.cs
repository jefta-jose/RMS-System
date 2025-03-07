using System;

namespace api.DTO.Dashboard;

public class DashboardProjectResourceDto
{
    public long ProjectResourceID { get; set; }
    public long? ResourceID { get; set; }
    public string CustomerName { get; set; }
    public string ProjectName { get; set; }
    public DateTime? EstimatedEndWeek { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal HoursPerWeek { get; set; }
    public string BillType { get; set; }    // = StatusId
}