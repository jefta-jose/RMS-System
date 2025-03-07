using api.DTO.ProjectResource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Project
{
    public class AddProjectDto : AddProjectResourceTypeDto
    {
        public string Name { get; set; }

        public Guid StatusID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public Guid? SolutionDeliveryLeaderID { get; set; }
        public String CustomerName { get; set; }
        public long CreatedBy { get; set; }
        public bool ExtendHours { get; set; } = false;
        public List<ProjectResourceTypeDto> ProjectResourceTypes { get; set; }

        public String AccountingID { get; set; }
        public long? ProjectLeaderID { get; set; }
        public long? BusinessUnitID { get; set; }
        public bool? ReceiveProjectUpdates { get; set; }
        [JsonProperty(Required = Required.Always)]
        public bool IncludeInCTR { get; set; }
        public bool? AutoRenew { get; set; }

    }

    public class ProjectResourceTypeDto
    {
        [Required(ErrorMessage = "Resource amount is required")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Resource type id is required")]
        public Guid ResourceTypeId { get; set; }

        public Guid? ProjectResourceTypeId { get; set; }
        public string StartBy { get; set; } = string.Empty;
    }
}