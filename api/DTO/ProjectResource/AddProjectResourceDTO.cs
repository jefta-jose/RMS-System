using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.ProjectResource;

public class AddProjectResourceDto
{
    [Required(ErrorMessage = "Hours per Week is required")]
    public decimal HoursPerWeek { get; set; }

    [Required(ErrorMessage = "Bill Type is required")]
    public Guid BillType { get; set; }

    [Required(ErrorMessage = "Start Date is required")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Estimated End Week is required")]
    public DateTime EstimateEndWeek { get; set; }

    [Required(ErrorMessage = "Project id is required")]
    public Guid ProjectId { get; set; }

    [Required(ErrorMessage = "Resource id is required")]
    public Guid ResourceId { get; set; }
}