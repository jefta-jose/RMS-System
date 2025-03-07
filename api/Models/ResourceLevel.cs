using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace api.Models;

public class ResourceLevel
{
    public byte ID { get; set; }
    public Guid ResourceLevelId { get; set; }
    public string ResourceLevelName { get; set; }

#nullable enable
    public string? ResourceLevelDescription { get; set; }
#nullable disable
    public DateTime? CreatedDTM { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }

    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public List<Resource> Resources { get; set; }
}