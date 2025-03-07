using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Resource;

public class UpsertResourceDto
{
    public Guid ResourceId { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }

    [Required, EmailAddress(ErrorMessage = "Provide a valid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Resource Type is required")]
    public Guid ResourceTypeId { get; set; }

    [Required(ErrorMessage = "Resource Level is required")]
    public Guid ResourceLevelId { get; set; }
    [Required(ErrorMessage = "Resource location is required")]
    public Guid ResourceLocationID { get; set; }

    [Required(ErrorMessage = "Resource SDl is required")]
    public Guid SolutionDeliveryLeaderID { get; set; }

    [Required(ErrorMessage = "Start Date is required")]
    public DateTime StartDTM { get; set; }

    public DateTime? EndDTM { get; set; }
}