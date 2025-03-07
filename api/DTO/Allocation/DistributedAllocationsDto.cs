using System;

namespace api.DTO.Allocation;

public class DistributedAllocationsDto
{
    public Guid AllocationId { get; set; }
    public long ResourceID { get; set; }
    public long ProjectResourceID { get; set; }
    public long ProjectID { get; set; }
    public decimal AllocatedWeekHours { get; set; }
    public DateTime Date { get; set; }
    public string ProjectName { get; set; }
    public string CustomerName { get; set; }
    public string Billable { get; set; }
    public DateTime ProjectEndDate { get; set; }
    public bool IsDeleted { get; set; }
}