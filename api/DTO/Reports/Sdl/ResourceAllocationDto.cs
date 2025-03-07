using System;

namespace api.DTO.Reports.Sdl
{
    public class ResourceAllocationDto
    {
        public decimal Hours { get; set; }
        public DateTime Date { get; set; }
        public long ResourceId { get; set; }

        public int BillType { get; set; }
        public bool IsDeleted { get; set; }
    }
}