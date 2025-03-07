using System.ComponentModel.DataAnnotations;

namespace api.DTO.User;

public class PasswordDto
{
    [Required]
    public string Password { get; set; }

    [Required, Compare("Password")]
    public string ConfirmPassword { get; set; }
    public string CurrentPassword { get; set; }
}