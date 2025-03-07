namespace api.DTO.Resource;

public class HrResourceNotificationDto
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public string ProjectLink { get; set; }
    public string HideProjectLink { get; set; } = "hidden";
    public string Message { get; set; }
}