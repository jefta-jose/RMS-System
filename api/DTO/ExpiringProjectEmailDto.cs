using System;

namespace api.DTO
{
    public class ExpiringProjectEmailDto1
    {
        public string Email { get; set; }
        public string ProjectName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string token { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}