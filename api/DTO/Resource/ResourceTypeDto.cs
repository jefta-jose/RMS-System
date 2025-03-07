using System;

namespace api.DTO.Resource
{
    public class ResourceTypeDto
    {
        public Guid ResourceTypeId { get; set; }
        public string ResourceTypeName { get; set; }
        public int LinkedResources { get; set; }
        public int LinkedProjects { get; set; }
        public string[] ProjectNames { get; set; }
        public string[] ResourceNames { get; set; }
    }
}
