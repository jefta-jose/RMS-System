using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Allocation;

public class DeleteAllocationDto
{
    public Guid? AllocationId { get; set; }
    public long ProjectResourceId { get; set; }
    public long ProjectId { get; set; }
    public Guid ResourceId { get; set; }
    public decimal Hours { get; set; }
    public long[] ProjectResourceIds { get; set; }
    public bool DeleteAllAllocations { get; set; }

}