using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.ProjectResource;

public class AddProjectResourceTypeDto
{
    [Required(ErrorMessage = "Project id is required")]
    public long ProjectId { get; set; }

    [Required(ErrorMessage = "Resource amount is required")]
    public int Amount { get; set; }

    [Required(ErrorMessage = "Resource type id is required")]
    public int ResourceTypeId { get; set; }

    public Guid? ProjectResourceTypeId { get; set; }
}
