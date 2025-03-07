using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.User;

public class InviteDto
{
    [Required(ErrorMessage = "Role is required")]
    public Guid UserRole { get; set; }

    [Required(ErrorMessage = "Firstname is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Lastname is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "IsSDL is required")]
    public bool IsSDL { get; set; }

    [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Provide a valid email address")]
    public string Email { get; set; }

    public long? ResourceID { get; set; }
    public int RoleId { get; set; }
    
    public long UserId { get; set; }


#nullable enable
    public List<Guid>? SolutionDeliveryLeaders { get; set; }
}