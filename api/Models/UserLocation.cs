using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class UserLocation
{
    public long ID { get; set; }
    public Guid UserLocationId { get; set; }
    public long UserId { get; set; }
    public long LocationId { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public Location Location { get; set; }
    public User User { get; set; }
    public UserLocation() { }
}