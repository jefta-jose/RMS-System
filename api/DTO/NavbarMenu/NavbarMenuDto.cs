using System.Collections.Generic;
using api.DTO.Role;

namespace api.DTO.NavbarMenu;

public class NavbarMenuDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long PermissionId { get; set; }
    
    public bool IsParent { get; set; }
    // public bool IsActive { get; set; }
    public bool IgnoreCase { get; set; }
    public int? ParentId { get; set; }
    public int Order { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public bool IsDeleted { get; set; }
    public long CreatedBy { get; set; }
    public List<NavbarMenuDto> Children { get; set; }
    public CreatorDto Creator { get; set; }
    public PermissionDto Permission { get; set; }
    
}