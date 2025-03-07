using System;

namespace api.DTO.ProjectHealth
{
    public class GetProjectHealthDto : AddProjectHealthDto
    {
        public string ProjectName { get; set; }
        public string ProjectLeaderName { get; set; }
        public string CustomerName { get; set; }
        public string SolutionDeliveryLeader { get; set; }
        public string IntacctID { get; set; }
        public DateTime? CTRLastTakenDTM { get; set; }
    }
}
