using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace api.Models;

public class ProjectResource
{
    public long ID { get; set; }
    public Guid ProjectResourceId { get; set; }
    public decimal HoursPerWeek { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EstimatedEndWeek { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }

    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public long? UpdatedBy { get; set; }
    public long ProjectId { get; set; }
    public long ResourceId { get; set; }
    public bool IsDeleted { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime? DeletedDTM { get; set; }
    public long BillType { get; set; }
    public Status Status { get; set; }
    public Resource Resource { get; set; }
    public Project Project { get; set; }
    public List<Allocation> Allocations { get; set; }
}