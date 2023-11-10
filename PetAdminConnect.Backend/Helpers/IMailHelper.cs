using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Helpers
{
    public interface IMailHelper
    {
        Response<string> SendMail(string toName, string toEmail, string subject, string body);
    }
}