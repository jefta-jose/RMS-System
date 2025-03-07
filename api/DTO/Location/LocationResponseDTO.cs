using System;

namespace api.DTO.Location;

public class LocationResponseDto
{
    public string Name { get; set; }
    public Guid LocationID { get; set; }
    public int LinkedProject { get; set; }
    public int LinkedResources { get; set; }
    public long? UserId { get; set; }
    public string[] ProjectNames { get; set; }
    public string[] ResourceNames { get; set; }
}
