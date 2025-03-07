using System.ComponentModel.DataAnnotations;

namespace api.DTO.User;

public class GenerateTokenDto
{
    [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Provide a valid email address")]
    public string Email { get; set; }

}