using System.Collections.Generic;

namespace api.DTO.Reports.Sdl
{
    public class SdlProjectReportDto
    {
        public string Name { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}