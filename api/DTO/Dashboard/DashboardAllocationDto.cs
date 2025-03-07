using System;

namespace api.DTO.Dashboard
{
    public class DashboardAllocationDto
    {
        public Guid AllocationId { get; set; }
        public long ResourceID { get; set; }
        public long ProjectID { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
    }
}
