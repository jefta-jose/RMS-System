using System;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Allocation
    {
        public long ID { get; set; }
        public Guid AllocationID { get; set; }
        public decimal Hours { get; set; }
        public bool IsOnPto { get; set; }
        public DateTime Date { get; set; }
        public long ProjectResourceID { get; set; }
        public long ResourceID { get; set; }
        public long ProjectID { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDTM { get; set; }
        public bool IsDeleted { get; set; }
        public long? BillType {get; set;}
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public Project Project { get; set; }
        public ProjectResource ProjectResource { get; set; }
        public Resource Resource { get; set; }
        public Status Status { get; set; }
    }
}