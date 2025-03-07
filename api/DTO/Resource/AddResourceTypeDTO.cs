using System.ComponentModel.DataAnnotations;

namespace api.DTO.Resource;

public class AddResourceTypeDto
{
    [Required(ErrorMessage = "Resource type name is required")]
    public string ResourceTypeName { get; set; }
}