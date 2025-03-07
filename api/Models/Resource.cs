using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Resource
    {
        public long ID { get; set; }
        public Guid ResourceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? ResourceTypeId { get; set; }
        public int? EmployeeTypeID { get; set; }
        public int? EarningTypeID { get; set; }
        public byte? ResourceLevelId { get; set; }
        public int? ResourceLocationID { get; set; }
        public long? SolutionDeliveryLeaderID { get; set; }
        public DateTime? StartDTM { get; set; }
        public DateTime? EndDTM { get; set; }
        public string? AccountingID { get; set; }
        public bool IsOnPto { get; set; }
        public DateTime? CreatedDTM { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        [Timestamp] public virtual byte[] RowVersion { get; set; }
        public ResourceType ResourceType { get; set; }
        public ResourceLevel ResourceLevel { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EarningType EarningType { get; set; }
        public ResourceLocation ResourceLocation { get; set; }
        public SolutionDeliveryLeader SolutionDeliveryLeader { get; set; }
        public List<ProjectResource> ProjectResources { get; set; }
        public List<Allocation> Allocations { get; set; }

        public User User { get; set; }

        public Resource()
        {
        }
    }
}