namespace HarvestHub.Modules.Notifications.Api.Services
{
    internal interface ISmtpService
    {
        Task SendConfirmationEmail(string receiverEmailAddress, string name, Guid verificationToken);
        Task SendForgetPasswordEmail(string receiverEmailAddress, string name, Guid resetPasswordToken);
    }
}
