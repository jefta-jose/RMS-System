using api.DTO.Intacct;

namespace api.Email.Intacct
{
    public class IntacctEmail : BaseEmail<IntacctEmailDto>
    {
        public override string Subject { get; set; } = "Intacct Timesheet Upload";

        protected override string TemplateFile => "intacct-email-template.html"; 

        public IntacctEmail(string to, IntacctEmailDto data)
        {
            To = to;
            GenerateTemplate(data);
        }
    }
}
