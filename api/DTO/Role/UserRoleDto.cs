namespace api.DTO.Role;

public class UserRoleDto
{
    public int RoleId { get; set; }
    public long UserId { get; set; }
    public RoleDto Role { get; set; }
    public CreatorDto User { get; set; }
}