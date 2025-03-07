using System;

namespace api.Models
{
    public class CustomerSdl
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public long SolutionDeliveryLeaderID { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDTM { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        public SolutionDeliveryLeader SolutionDeliveryLeader { get; set; }
    }
}