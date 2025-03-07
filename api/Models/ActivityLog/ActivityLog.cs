using System;

namespace api.Models.ActivityLog
{
    public class ActivityLog
    {
        public long Id { get; set; }
        public string ActivityType { get; set; }
        public string Description { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string Referrer { get; set; }
        public string Url { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public bool IsArchived { get; set; } = false;
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual User Creator { get; set; }
    }
}