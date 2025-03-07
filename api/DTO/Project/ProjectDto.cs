using api.DTO.ProjectResource;
using System;
using System.Collections.Generic;

namespace api.DTO.Project
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid SolutionDeliveryLeaderID { get; set; }
        public Guid CompanyID { get; set; }
        public string CustomerName { get; set; }
        public Guid CustomerID { get; set; }
        public Guid StatusID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public Guid ProjectID { get; set; }
        public string AccountingID { get; set; }
        public string Status { get; set; }
        public long? ProjectLeaderID { get; set; }
        public bool ReceiveProjectUpdates { get; set; }
        public long? BusinessUnitID { get; set; }
        public bool IncludeInCTR { get; set; }
        public bool AutoRenew { get; set; }
        public long? TotalResources { get; set; }
        public IEnumerable<ProjectResourceTypesDto> ProjectResourceTypes { get; set; }

        public IEnumerable<ProjectResourceResponseDto> ProjectResources { get; set; }

    }
}
