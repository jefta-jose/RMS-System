using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using api.DTO.Role;
using api.Models.Roles;

namespace api.Models.Navbar;

public class NavbarMenu
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public long PermissionId { get; set; }
    public int? ParentId { get; set; }
    public int Order { get; set; }
    public bool IsParent { get; set; }
   // public bool IsActive { get; set; }
    public bool IgnoreCase { get; set; }
    public bool IsDeleted { get; set; }
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public virtual ICollection<NavbarMenu> Children { get; set; }

    [ForeignKey("CreatedBy")]
    public virtual User Creator { get; set; }

    [ForeignKey("UpdatedBy")]
    public virtual User Updater { get; set; }

    [ForeignKey("DeletedBy")]
    public virtual User Deleter { get; set; }

    public virtual Permission Permission { get; set; }
    public byte[] RowVersion { get; set; }
    
}