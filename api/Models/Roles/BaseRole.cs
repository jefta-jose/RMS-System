using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Roles;

public class BaseRole
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "ACTIVE";
    public bool? IsDeleted { get; set; } = false;
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    [ForeignKey("CreatedBy")]
    public User Creator { get; set; }
}