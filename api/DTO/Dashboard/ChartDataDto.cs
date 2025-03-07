namespace api.DTO.Dashboard;

public class ChartDataDto
{
    public decimal AvailableResources { get; set; }
    public decimal AllocatedResources { get; set; }
    public decimal PartialAllocations { get; set; }
    public decimal BillableResources { get; set; }
    public decimal NonbillableResources { get; set; }
    public int Billables { get; set; }
    public int Projects { get; set; }
    public decimal TotalHoursSummation { get; set; }
}