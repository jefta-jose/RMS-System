using System;
using api.DTO.Role;

namespace api.DTO.Email;

public class EmailConfigurationDto
{
    public long Id { get; set; }
    public string Recipient { get; set; }
    public string Cc { get; set; } 
    public string Bcc { get; set; }
    public string Type { get; set; }
    public string Status { get; set; } = "ACTIVE";
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public CreatorDto Creator { get; set; }
    public CreatorDto Updater { get; set; }
}