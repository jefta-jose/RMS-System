using System;
using System.ComponentModel.DataAnnotations;
using api.DTO.User;

namespace api.DTO.ActivityLog
{
    public class ActivityLogDto
    {
        public long Id { get; set; }
        [Display(Name = "Activity Type")]
        public string ActivityType { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Old Value")]
        public string OldValue { get; set; }
        [Display(Name = "New Value")]
        public string NewValue { get; set; }
        [Display(Name = "IP Address")]
        public string IpAddress { get; set; }
        [Display(Name = "User Agent")]
        public string UserAgent { get; set; }
        [Display(Name = "Referrer")]
        public string Referrer { get; set; }
        [Display(Name = "URL")]
        public string Url { get; set; }
        [Display(Name = "Query String")]
        public string QueryString { get; set; }
        [Display(Name = "Request Body")]
        public string RequestBody { get; set; }
        [Display(Name = "Is Archived")]
        public bool IsArchived { get; set; } = false;
        [Display(Name = "Created By")]
        public long CreatedBy { get; set; }
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Display(Name = "Creator")]
        public UserDto Creator { get; set; }
    }
}