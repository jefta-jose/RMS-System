using System.Collections.Generic;

namespace api.Models.Roles;
public class Role: BaseRole
{
    public int Id { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}