using System;

namespace api.DTO.Sdls;

public class SolutionDeliveryLeaderResponseDto
{
    public long SdlId { get; set; }
    public string FullName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid SolutionDeliveryLeaderID { get; set; }
    public int LinkedProject { get; set; }
    public int LinkedResources { get; set; }
    public long? UserID { get; set; }
    public string[] ProjectNames { get; set; } = Array.Empty<string>();
    public string[] ResourceNames { get; set; } = Array.Empty<string>();
}
