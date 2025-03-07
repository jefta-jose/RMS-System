using System;
using System.Collections.Generic;
using api.DTO.Allocation;

namespace api.DTO.Reports.Sdl
{
    public class ResourceDto
    {
        public string Name { get; set; }
        public string BillType { get; set; }
        public List<KeyValuePair<DateTime, decimal>> Hours { get; set; }
        public List<ResourceAllocationDto> Allocations { get; set; }
    }
}