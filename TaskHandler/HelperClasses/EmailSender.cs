using Microsoft.AspNetCore.Identity.UI.Services;

namespace TaskHandler.HelperClasses
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //В будущем прописать логику отправления письма для подтверждения Email
            return Task.CompletedTask;
        }
    }
}
