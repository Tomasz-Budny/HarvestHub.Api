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
        public async Task SendConfirmationEmail(string receiverEmailAddress, string name, Guid verificationToken)
        {
            var subject = "Zweryfikuj konto w serwisie HarvestHub";
            var template = $"<h1>Witaj, {name}</h1><p>Aby zweryfikować swoje konto wejdź w poniższy link: </p> <a href='verify/{verificationToken}'>link</a><p>Pozdrawiamy, <br>zespół HarvestHub</p>";

            await SendEmail(subject, template, receiverEmailAddress);
        }

        public async Task SendForgetPasswordEmail(string receiverEmailAddress, string name, Guid resetPasswordToken)
        {
            var subject = "Zresetuj swoje hasło w serwisie HarvestHub";
            var template = $"<h3>Witaj, {name}</h3><p>Aby Zresetować swoje hasło w serwisie HarvestHub wejdź w poniższy link: </p> <a href='verify/{resetPasswordToken}'>link</a><p>Pozdrawiamy, <br>zespół HarvestHub</p>";

            await SendEmail(subject, template, receiverEmailAddress);
        }

        private async Task SendEmail(string subject, string template, string receiver)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpOptions.From));
            email.To.Add(MailboxAddress.Parse(receiver));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = template };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpOptions.UserName, _smtpOptions.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
