using System;

namespace api.Models.Roles;

public class RolePermission
{
    public int RoleId { get; set; }
    public long PermissionId { get; set; }
    public string Status { get; set; } = "ACTIVE";
    public bool? IsDeleted { get; set; } = false;
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Role Role { get; set; }
    public Permission Permission { get; set; }
}