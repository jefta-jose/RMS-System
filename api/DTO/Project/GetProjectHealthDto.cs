using System;

namespace api.DTO.Project;

public class GetProjectHealthDto
{
    public string status { get; set; }
    public DateTime reportDate { get; set; }
}