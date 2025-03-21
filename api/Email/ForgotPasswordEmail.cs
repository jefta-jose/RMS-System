using api.DTO;

namespace api.Email;

public class ForgotPasswordEmail : BaseEmail<ForgotPasswordEmailDto>
{
    public override string Subject { get; set; } = "RMS - Forgot Password Reset Request";
    protected override string TemplateFile => "forgot-password-email-template.html";

    public ForgotPasswordEmail(string to, ForgotPasswordEmailDto data)
    {
        this.To = to;
        GenerateTemplate(data);
    }
}