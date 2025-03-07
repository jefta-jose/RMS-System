using api.DTO.Allocation;
using System;
using System.Collections.Generic;

namespace api.DTO.Dashboard;

public class DashboardResourceDto
{
    public long ID { get; set; }
    public Guid? ResourceId { get; set; }
    public string Name { get; set; }
    public string LocationName { get; set; }
    public string SDLName { get; set; }
    public string ResourceType { get; set; }
    public string ResourceLevel { get; set; }
    public string Status { get; set; }
    public bool IsOnPto { get; set; }
    public Guid? ProjectResourceId { get; set; }
    public long PResourceId { get; set; }
    public long ProjectId { get; set; }
    public string AccountingID { get; set; }
    public string BillType { get; set; }
    public List<DashboardProjectResourceDto> Project { get; set; }
    public List<AllocationDto> Allocations { get; set; }
}