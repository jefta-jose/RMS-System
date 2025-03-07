using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Allocation
{
    public class DeleteProjectAllocationsDto
    {
        [Required(ErrorMessage = "Project Resource IDs Are Required")]
        public List<long> ProjectResourceIds { get; set; }
    }

    public class DeleteProjectAllocationsonProjectStatusChangeDto
    {
        [Required(ErrorMessage = "Project Resource IDs Are Required")]
        public List<long> ProjectResourceIds { get; set; }
    }
}
