using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using api.Services;

namespace api.Models;

public class Status
{
    public long ID { get; set; }
    public Guid StatusID { get; set; }
    public string StatusName { get; set; }
    public string StatusDescription { get; set; }
    public long StatusGroupID { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public StatusGroup StatusGroup { get; set; }
    public List<Project> Projects { get; set; }
    public List<ProjectResource> ProjectResources { get; set; }
    public List<Allocation> Allocations { get;set; }
    public Status() { }
}