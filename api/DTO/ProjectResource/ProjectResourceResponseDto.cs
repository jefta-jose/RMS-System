using System;
using System.Collections.Generic;
using api.DTO.Allocation;

namespace api.DTO.ProjectResource;

public class ProjectResourceResponseDto
{
    public Guid ID { get; set; }
    public long ResourceId { get; set; }
    public string ResourceName { get; set; }
    public long ProjectResourceId { get; set; }
    public long ProjectId { get; set; }
    public string ProjectIdStr { get; set; }
    public decimal HoursPerWeek { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EstimatedEndWeek { get; set; }
    public DateTime? CreatedDate { get; set; }
    public long Billable { get; set; }
    public string BillType { get; set; }
    public long BillTypeId { get; set; }
    public string ProjectName { get; set; }
    public DateTime? CreatedDTM { get; set; }
    public string Customer { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<AllocationDto> Allocations { get; set; }
}