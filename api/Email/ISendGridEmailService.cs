using System.Threading.Tasks;

namespace api.Email
{
    public interface ISendGridEmailService
    {
        Task SendEmail(IEmail email);
    }
}
