using System;
using System.Collections.Generic;

namespace api.DTO.Dashboard
{
    public class DProjectResourceDto
    {
        public long? ResourceID { get; set; }

        public long? ProjectID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public DateTime? EstimatedEndWeek { get; set; }
        public DateTime? StartDate { get; set; }
        public List<DashboardAllocationDto> Allocations { get; set; }
        public Guid? BusinessUnitID { get; set; }
        public string BusinessUnitName { get; set; }
        public string Status { get; set; }
    }
}
