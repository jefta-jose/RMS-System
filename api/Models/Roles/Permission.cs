using System.Collections.Generic;
namespace api.Models.Roles;
public class Permission: BaseRole
{
    public long Id { get; set; }
    public string Group { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}