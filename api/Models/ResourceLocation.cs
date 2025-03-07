using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace api.Models;

public class ResourceLocation
{
    public int ID { get; set; }
    public Guid ResourceLocationID { get; set; }
    public string ResourceLocationName { get; set; }
    public DateTime? CreatedDTM { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }

    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public List<Resource> Resources { get; set; }
}
