using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class UserSolutionDeliveryLeader
{
    public long ID { get; set; }
    public Guid UserSolutionDeliveryLeaderId { get; set; }
    public long UserID { get; set; }
    public long SolutionDeliveryLeaderID { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public SolutionDeliveryLeader SolutionDeliveryLeader { get; set; }
    public User User { get; set; }
    public UserSolutionDeliveryLeader() { }
}