using System;

namespace api.DTO.User;

public class AddUserRoleDto
{
    public string Name { get; set; }
    public DateTime CreatedDTM { get; set; }
    public long CreatedBy { get; set; }
    public long UpdatedBy { get; set; }
    public DateTime UpdatedDTM { get; set; }
}
