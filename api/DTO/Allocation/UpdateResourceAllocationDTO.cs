using System;
using System.Collections.Generic;

namespace api.DTO.Allocation;

public class UpdateResourceAllocationDto
{
    public Guid AllocationId { get; set; }
    public decimal Hours { get; set; }
    public long ResourceID { get; set; }
    public DateTime Date { get; set; }
    public long ProjectResourceID { get; set; }
    public bool IsOnPto { get; set; }
    public decimal TotalBillableHours { get; set; }
    public decimal TotalNonBillableHours { get; set; }
    public bool IsDeleted { get; set; }
    public string ProjectName { get; set; }
    public string CustomerName { get; set; }
    public IEnumerable<DistributedAllocationsDto> DistributedAllocation { get; set; }
}