using System.ComponentModel.DataAnnotations;

namespace api.DTO.User;

public class LoginDto
{
    [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Provide a valid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

}