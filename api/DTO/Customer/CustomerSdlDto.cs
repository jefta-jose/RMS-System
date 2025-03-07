using System;
using api.DTO.Sdls;
using api.DTO.User;
using SolutionDeliveryLeaderDto = api.DTO.Sdls.SolutionDeliveryLeaderDto;

namespace api.DTO.Customer
{
    public class CustomerSdlDto
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
        public SolutionDeliveryLeaderDto SolutionDeliveryLeader { get; set; }
        public CustomerDto Customer { get; set; }
        public UserDto Creator { get; set; }
    }
}