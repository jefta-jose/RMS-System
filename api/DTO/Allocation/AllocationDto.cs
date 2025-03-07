using System;
using System.Security.Cryptography.X509Certificates;

namespace api.DTO.Allocation;

public class AllocationDto
{
    public Guid AllocationId { get; set; }
    public long ResourceID { get; set; }
    public string ResourceName { get; set; }
    public long ProjectResourceID { get; set; }
    public long ProjectID { get; set; }
    public DateTime Date { get; set; }
    public decimal Hours { get; set; }
    public bool IsOnPto { get; set; }
    public string ProjectName { get; set; }
    public string CustomerName { get; set; }
    public string ResourceType { get; set; }
    public string Tooltip { get; set; }
    public long? BillType { get; set; }
    #nullable enable
    public string? BillTypeName { get; set; }
}