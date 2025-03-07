using System;

namespace api.DTO.ProjectHealth
{
    public class ReportHistoryDto
    {
        public DateTime ReportDate { get; set; }
        public string ReportName { get; set; } = string.Empty;
    }
}
