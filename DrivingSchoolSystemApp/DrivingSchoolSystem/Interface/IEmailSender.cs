namespace DrivingSchoolSystem.Interface
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName);
    }
}
