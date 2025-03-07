using api.DTO.ProjectResource;
using System;
using System.Collections.Generic;

namespace api.DTO.Resource;

public class ResourceResponseDto
{
    public Guid ID { get; set; }
    public long OtherID { get; set; }
    public string IntacctID { get; set; }
    public decimal TotalAllocatedHours { get; set; }
    public decimal TotalBillableHours { get; set; }
    public decimal TotalNonBillableHours { get; set; }
    public string ResourceLocation { get; set; }
    public string ResourceSDL { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public Guid? RoleId { get; set; }
    public Guid? ResourceSDLID { get; set; }
    public string Level { get; set; }
    public Guid? EmployeeTypeID { get; set; }
    public Guid? EarningTypeID { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool IsOnPto { get; set; }

    public IEnumerable<ProjectResourceResponseDto> Projects { get; set; }
}
