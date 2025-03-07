using System;

namespace api.DTO.ProjectResource;

public class ProjectResourceDto
{
    public long? Status { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public DateTime? StartDate { get; set; }
    #nullable enable
    public Models.Status? StatusObject { get; set; }
}
