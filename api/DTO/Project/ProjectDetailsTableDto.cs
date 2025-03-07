using System;
using System.Net;

namespace api.DTO.Project;

public class ProjectDetailsTableDto
{
    public string ResourceName { get; set; }
    public long ProjectResourceId { get; set; }
    public DateTime? StartDate { get; set; }
    public string ResourceType { get; set; }
    public DateTime? EndDate { get; set; }
}