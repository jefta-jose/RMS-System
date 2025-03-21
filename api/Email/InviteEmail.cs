using api.DTO;

namespace api.Email;

public class InviteEmail : BaseEmail<InviteEmailDto>
{
    public override string Subject { get; set; } = "You have been invited to RMS!";
    protected override string TemplateFile => "invite-email-template.html";

    public InviteEmail(string to, InviteEmailDto data)
    {
        this.To = to;
        GenerateTemplate(data);
    }
}