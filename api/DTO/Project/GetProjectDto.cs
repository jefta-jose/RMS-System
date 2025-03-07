using api.DTO.ProjectResource;
using System;
using System.Collections.Generic;
using api.DTO.BusinessUnit;

namespace api.DTO.Project
{
    public class GetProjectDto
    {
        public long Id { get; set; }
        public Guid ProjectID { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public int ResourcesRequired { get; set; }
        public string IntacctID { get; set; }
        public string BusinessUnitName { get; set; }
        public long? SolutionDeliveryLeaderID { get; set; }
        public string SolutionDeliveryLeader { get; set; }
        public long? BusinessUnitID { get; set; }
        public BusinessUnitDto BusinessUnit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public string Status { get; set; }
        public string ProjectLink { get; set; }
        public bool AutoRenew { get; set; }
        public List<ProjectResourceDto> ProjectResources { get; set; }
        public List<string> ProjectResourcesList { get; set; }
        public List<GetProjectHealthDto> ProjectHealthList { get; set; }
        public int TotalResources { get; set; }
    }
}