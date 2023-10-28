using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using HarvestHub.Modules.Notifications.Api.Options;
using Microsoft.Extensions.Options;

namespace HarvestHub.Modules.Notifications.Api.Services
{
    internal class SmtpService : ISmtpService
    {
        private readonly SmtpOptions _smtpOptions;

        public SmtpService(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions.Value;
        }
        public async Task SendConfirmationEmail(string receiverEmailAddress, Guid verificationToken)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpOptions.From));
            email.To.Add(MailboxAddress.Parse(receiverEmailAddress));
            email.Subject = "Zweryfikuj konto w serwisie HarvestHub";
            email.Body = new TextPart(TextFormat.Html) { Text = GetConfirmationEmailTemplate() };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpOptions.UserName, _smtpOptions.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        private string GetConfirmationEmailTemplate()
        {
            return string.Empty;
        }
    }
}
