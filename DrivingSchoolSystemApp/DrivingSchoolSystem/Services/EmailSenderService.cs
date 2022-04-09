using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using MailKit.Net.Smtp;
using CSharpVitamins;
using DrivingSchoolSystem.Interface;
using DrivingSchoolSystem.Models;

namespace DrivingSchoolSystem.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName)
        {
            var code = Guid.NewGuid().ToString();
            ShortGuid uniqueCode = code;
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Unique code";
            message.Body = new TextPart("plain")
            {
                Text = code
            };

            var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully" + code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
