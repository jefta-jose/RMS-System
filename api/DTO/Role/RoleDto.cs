using System.Collections.Generic;

namespace api.DTO.Role;

public class RoleDto: BaseRoleDto
{
    public int Id { get; set; }
    public ICollection<PermissionDto> Permissions { get; set; }
    public ICollection<RolePermissionDto> RolePermissions { get; set; }
}