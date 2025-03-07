using System.Collections.Generic;

namespace api.DTO.Resource;

public class AllResourcesAllocationsResponseDto
{
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
    public IEnumerable<SingleResourceAllocationResponseDto> Resources { get; set; }
}
