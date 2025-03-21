using System;
using api.DTO;

namespace api.Email;

public class ExpiringProjectEmail : BaseEmail<ExpiringProjectEmailDto>
{
    public override string Subject { get; set; } = "Your Project will Expire soon!";
    protected override string TemplateFile => "expiring-project-email-template.html";

    public ExpiringProjectEmail(string to, string cc, ExpiringProjectEmailDto data)
    {
        To = to;
        Cc = cc;
        GenerateTemplate(data);
    }
}