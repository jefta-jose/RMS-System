using System.Linq;
using api.Data;
using api.DTO.Resource;

namespace api.Email;

public class HrNotification : BaseEmail<HrResourceNotificationDto>
{
    public override string Subject { get; set; }
    protected override string TemplateFile => "project-update-notification-template.html";
    public HrNotification(HrResourceNotificationDto data, RmsDbContext dbContext)
    {
        var emailConfiguration = dbContext.EmailConfigurations.FirstOrDefault(x => x.Type.ToLower() == "hr_notification");
        To = emailConfiguration?.Recipient;
        Cc = emailConfiguration?.Cc;
        Bcc = emailConfiguration?.Bcc;
        Subject = data.Subject;
        GenerateTemplate(data);
    }
}