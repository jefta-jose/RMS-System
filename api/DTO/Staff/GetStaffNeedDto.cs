using System;
using System.Security.AccessControl;
using api.DTO.Customer;
using api.DTO.Project;

namespace api.DTO.Staff
{
    public class GetStaffNeedDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string Role { get; set; }
        public string StartDate { get; set; }
    }
}