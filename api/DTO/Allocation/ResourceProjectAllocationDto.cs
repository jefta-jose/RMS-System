using api.DTO.Resource;

namespace api.DTO.Allocation;

public class ResourceProjectAllocationDto
{
    public long ResourceId { get; set; }
    public long ProjectId { get; set; }
    public ResourceDto Resource { get; set; }
}