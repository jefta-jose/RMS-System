using System;
using System.Security.AccessControl;
using api.DTO.Customer;
using api.DTO.Project;

namespace api.DTO.Staff
{
    public class StaffNeedDto
    {
        public CustomerDto Customer { get; set; }
        public ProjectDto Project { get; set; }
        public StaffRoleDto role { get; set; }
        public StaffAssigneeDto Assignee { get; set; }
        public string StartDate { get; set; }

        public int count { get; set; }
    }
}