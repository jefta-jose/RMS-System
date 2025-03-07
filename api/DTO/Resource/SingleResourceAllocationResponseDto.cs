using System;
using System.Collections.Generic;
using api.DTO.Allocation;
using api.DTO.Project;

namespace api.DTO.Resource;

public class SingleResourceAllocationResponseDto
{
    public string FullName { get; set; }
    public string AccountingId { get; set; }
    public string Role { get; set; }
    public string ResourceLevel { get; set; }
    public string Status { get; set; }
    public bool IsOnPto { get; set; }
    public string ResourceSDL { get; set; }
    public string Email { get; set; }
    public Guid ResourceId { get; set; }
    public decimal TotalAllocatedHours { get; set; }
    public decimal TotalBillableHours { get; set; }
    public decimal TotalNonBillableHours { get; set; }
    public IEnumerable<ProjectsResponseDto> Projects { get; set; }
    public IEnumerable<AllocationDto> Allocations { get; set; }
}