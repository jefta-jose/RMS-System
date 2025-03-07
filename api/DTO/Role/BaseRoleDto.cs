using System;

namespace api.DTO.Role;

public class BaseRoleDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public bool? IsDeleted { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public CreatorDto Creator { get; set; }
}