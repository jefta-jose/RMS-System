using System.Collections.Generic;

namespace api.DTO.Dashboard
{
    public class DashboardResource
    {
        public string Name { get; set; }
        public string LocationName { get; set; }
        public string SDLName { get; set; }
        public string ResourceType { get; set; }
        public string ResourceLevel { get; set; }
        public string AccountingID { get; set; }
        public List<DProjectResourceDto> Projects { get; set; }
        public List<DashboardAllocationDto> Allocations { get; set; }
    }
}
