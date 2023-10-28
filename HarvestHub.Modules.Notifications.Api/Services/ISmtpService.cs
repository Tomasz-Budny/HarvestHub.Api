namespace HarvestHub.Modules.Notifications.Api.Services
{
    internal interface ISmtpService
    {
        Task SendConfirmationEmail(string receiverEmailAddress, Guid verificationToken);
    }
}
