using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Roles;

namespace api.Models;

public class UserRole
{
    public long ID { get; set; }
    public Guid UserRoleID { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; }
    public long UserId { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? CreatedDTM { get; set; }
    public long UpdatedBy { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public long IsDeleted { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public Role Role { get; set; }
    public User User { get; set; }
}