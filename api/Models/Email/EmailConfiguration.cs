using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Email;

public class EmailConfiguration
{
    public long Id { get; set; }
    public string Recipient { get; set; }
    public string Cc { get; set; }
    public string Bcc { get; set; }
    public string Type { get; set; }
    public string Status { get; set; } = "ACTIVE";
    public bool IsDeleted { get; set; } = false;
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public byte[] RowVersion { get; set; }
    [ForeignKey("CreatedBy")]
    public User Creator { get; set; }
    [ForeignKey("UpdatedBy")]
    public User Updater { get; set; }
}