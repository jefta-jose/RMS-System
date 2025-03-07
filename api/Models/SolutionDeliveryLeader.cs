using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class SolutionDeliveryLeader
    {
        public long ID { get; set; }
        public Guid SolutionDeliveryLeaderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CreatedBy { get; set; }
        public long? UserID { get; set; }
        public string AccountingID { get; set; }
        public DateTime? CreatedDTM { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public bool IsDeleted { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public User User { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Project> Projects { get; set; }
        public List<UserSolutionDeliveryLeader> UserSolutionDeliveryLeaders { get; set; }
        public List<Resource> Resources { get; set; }

        public SolutionDeliveryLeader() { }
    }
}