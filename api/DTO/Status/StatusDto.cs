using System;

namespace api.DTO.Status;

public class StatusDto
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
}