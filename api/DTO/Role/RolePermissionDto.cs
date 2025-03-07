using api.Models.Roles;

namespace api.DTO.Role;

public class RolePermissionDto
{
    public int RoleId { get; set; }
    public long PermissionId { get; set; }
    public string Status { get; set; }
    public long CreatedBy { get; set; }
    public bool? IsDeleted { get; set; }
    public CreatorDto Creator { get; set; }
    public Models.Roles.Role Role { get; set; }
    public PermissionDto Permission { get; set; }
}