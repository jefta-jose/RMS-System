using System;

namespace api.Models
{
    public class ProjectHealth
    {
        public long ID { get; set; }
        public Guid ProjectHealthID { get; set; }
        public long ProjectID { get; set; }
        public long? ProjectLeaderID { get; set; }
        public long? SolutionDeliveryLeaderID { get; set; }
        public Project Project { get; set; }
        public Resource ProjectLeader { get; set; }
        public SolutionDeliveryLeader SolutionDeliveryLeader { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string OnTime { get; set; }
        public string MeetsExpectations { get; set; }
        public string TeamPerformance { get; set; }
        public DateTime ReportDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDTM { get; set; }
    }
}
