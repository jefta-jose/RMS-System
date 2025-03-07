using System.Collections.Generic;

namespace api.DTO.Dashboard;

public class DashboardDto
{
    public List<DashboardResourceDto> Resources { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
}