using System.Collections.Generic;
using api.Models.Roles;

namespace api.DTO.Role;

public class PermissionDto:BaseRoleDto
{
    public long Id { get; set; }
    public string Group { get; set; }
    public ICollection<Models.Roles.Role> Roles { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}