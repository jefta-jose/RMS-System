
using System;
using api.DTO.Location;
using api.DTO.Sdls;

namespace api.DTO.User;

public class UserSolutionDeliveryLeaderDto
{
    public long ID { get; set; }
    public Guid UserSolutionDeliveryLeaderID { get; set; }
    public long UserID { get; set; }
    public Guid SolutionDeliveryLeaderID { get; set; }
    public string SolutionDeliveryLeaderName { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long? UpdatedBy { get; set; }
    public SolutionDeliveryLeaderDto SolutionDeliveryLeader { get; set; }
}