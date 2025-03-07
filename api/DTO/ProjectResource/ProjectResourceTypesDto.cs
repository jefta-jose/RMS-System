using System;

namespace api.DTO.ProjectResource;

public class ProjectResourceTypesDto
{
  public float Amount { get; set; }
  public string StartBy { get; set; }
  public Guid ResourceTypeID { get; set; }
  public Guid ProjectResourceTypeID { get; set; }
}