using System;
using System.Collections.Generic;

namespace api.DTO.Project
{
    public class GetProjectsResponseDTO
    {
        public List<GetProjectDto> Projects { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}