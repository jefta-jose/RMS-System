using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace api.Models
{
    public class Customer
    {
        public long ID { get; set; }
        public Guid CustomerID { get; set; }

        public string Name { get; set; }
        public long? SolutionDeliveryLeaderID { get; set; } = null;
        public bool IsDeleted { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public DateTime? DeletedDTM { get; set; }
        public DateTime CreatedDTM { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public long? DeletedBy { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public List<Project> Projects { get; set; }
        public SolutionDeliveryLeader SolutionDeliveryLeader { get; set; }
        public List<CustomerSdl> CustomerSdls { get; set; }
    }
}