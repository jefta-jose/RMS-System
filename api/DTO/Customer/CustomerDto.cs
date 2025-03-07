using api.DTO.Project;
using api.DTO.ProjectResource;
using System;
using System.Collections.Generic;

namespace api.DTO.Customer;

public class CustomerDto
{
    public long ID { get; set; }
    public Guid CustomerID { get; set; }
    public string CustomerName { get; set; }
    public long? SolutionDeliveryLeaderID { get; set; }
    public string Name { get; set; }
    public int TotalResources { get; set; }
    public int CompletedProjects { get; set; }
    public int NumberOfProjects { get; set; }
    public bool IsActive { get; set; }
    public List<string> ProjectList { get; set; }
    public List<GetProjectDto> Projects { get; set; }
    public List<ProjectResourceResponseDto> ProjectResources { get; set; }
}