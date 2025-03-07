using System;
using System.Collections.Generic;

namespace api.DTO.Allocation;
public class UpdateResourceAllAllocationDto
{
    public Guid AllocationId { get; set; }
    public long ResourceID { get; set; }
    public decimal Hours { get; set; }
    public bool RemoveAllocationsAfterEndDate { get; set; }
    public long ProjectResourceID { get; set; }
    public long BillTypeId { get; set; }
    public long ProjectId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsOnPto { get; set; }
    public decimal TotalBillableHours { get; set; }
    public decimal TotalNonBillableHours { get; set; }
    public bool IsDeleted { get; set; }
    public string ProjectName { get; set; }
    public string CustomerName { get; set; }
    public IEnumerable<DistributedAllocationsDto> DistributedAllocation { get; set; }
}