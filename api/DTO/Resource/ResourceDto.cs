using System;
using System.Collections.Generic;
using api.DTO.ProjectResource;

namespace api.DTO.Resource;

public class ResourceDto
{
    public long ID { get; set; }
    public Guid ResourceId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Guid? ResourceTypeId { get; set; }
    public Guid? ResourceLevelId { get; set; }
    public Guid? ResourceLocationID { get; set; }
    public Guid? SolutionDeliveryLeaderID { get; set; }
    public Guid? EmployeeTypeID { get; set; }
    public Guid? EarningTypeID { get; set; }
    public DateTime? StartDTM { get; set; }
    public DateTime? EndDTM { get; set; }
    public string AccountingID { get; set; }
    public bool IsOnPto { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDTM { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime? DeletedDTM { get; set; }
    public decimal CurrentHours { get; set; }
    public ResourceTypeDto ResourceType { get; set; }
    public List<ProjectResourceResponseDto> Projects { get; set; }
}