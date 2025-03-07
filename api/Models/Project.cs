using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Project
    {
        public long ID { get; set; }
        public Guid ProjectID { get; set; }
        public string Name { get; set; }
        public long StatusId { get; set; }
        public string AccountingID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public long CustomerID { get; set; }
        public long? SolutionDeliveryLeaderID { get; set; } = null;
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDTM { get; set; }
        public Boolean IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        public DateTime? CTRLastTakenDTM { get; set; }
        public long? ProjectLeaderID { get; set; }
        public Resource ProjectLeader { get; set; }
        public bool ReceiveProjectUpdates { get; set; }
        public bool IncludeInCTR { get; set; }
        public bool AutoRenew { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public Customer Customer { get; set; }
        public List<ProjectResourceType> ProjectResourceTypes { get; set; }
        public List<ProjectResource> ProjectResources { get; set; }
        public SolutionDeliveryLeader SolutionDeliveryLeader { get; set; }

        public Status Status { get; set; }
        public List<Allocation> Allocations { get; set; }
        public List<ProjectHealth> ProjectHealth { get; set; }
        public long? BusinessUnitID { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
    }
}