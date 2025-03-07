using System;
using System.Collections.Generic;
using api.DTO.Resource;

namespace api.DTO.Reports.Sdl
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public List<KeyValuePair<DateTime, decimal>> Hours { get; set; }
        public List<ResourceDto> Resources { get; set; }
    }
}