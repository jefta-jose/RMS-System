using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace api.Models;

public class StatusGroup
{
    public long ID { get; set; }
    public Guid StatusGroupID { get; set; }
    public string StatusGroupName { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public List<Status> Statuses { get; set; }
    public StatusGroup() { }
}