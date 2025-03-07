using System;

namespace api.DTO
{
    public class ExpiringProjectEmailDto
    {
        public string Email { get; set; }
        public string ProjectLeaderEmail { get; set; }
        public bool ReceiveProjectUpdates { get; set; }
        public string ProjectName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly ProjectEndDate { get; set; }
        public string ProjectRemainingDays { get; set; }

        public string ProjectUrl { get; set; }
        public string AutoRenew { get; set; }
        public DateOnly NewEndDate { get; set; }
    }
}