using System.ComponentModel.DataAnnotations;

namespace api.DTO.ProjectResource;

public class UpdateProjectResourceDto
{
    [Required(ErrorMessage = "Please provide hours per week")]
    public decimal HoursPerWeek { get; set; }
}