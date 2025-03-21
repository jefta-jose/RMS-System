using SendGrid;

namespace api.Email
{
    public class SendGridEmailService(ISendGridClient sendGridClient) : ISendGridEmailService
    {
        private readonly ISendGridClient _sendGridClient = sendGridClient;
    }
}
