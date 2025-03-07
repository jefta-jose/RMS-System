using System;
using System.Collections.Generic;
using api.Models;

namespace api.DTO.Project;

public class ProjectsResponseDto
{
    public string Customer { get; set; }
    public string ProjectName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? EstimatedEndWeek { get; set; }
    public string Billable { get; set; }
    public long StatusId { get; set; }
    public Guid ProjectResourceId { get; set; }
    public decimal HoursPerWeek { get; set; }
}