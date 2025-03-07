using api.DTO.Sdls;
using System.Collections.Generic;

namespace api.DTO.User;

public class EditUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int RoleID { get; set; }

    public List<SolutionDeliveryLeaderResponseDto> SelectedSDL { get; set; }
    public bool IsSDL { get; set; }
    public long? ResourceID { get; set; }
}
