using System.Collections.Generic;
using System;

namespace api.DTO.Status;

public class StatusGroupDto
{
    public long ID { get; set; }
    public Guid StatusGroupID { get; set; }
    public string StatusGroupName { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    public IEnumerable<StatusDto> Statuses { get; set; }
}