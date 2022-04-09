using DrivingSchoolSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Controllers
{
    public class EmailSenderController : Controller
    {
        IEmailSender _emailSender;
        public EmailSenderController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost, Route("SendEmail")]
        public async Task<IActionResult> SendEmailAsync(string recipientEmail, string recipientFirstName)
        {
            try
            {
                string messageStatus = await _emailSender.SendEmailAsync(recipientEmail, recipientFirstName);
                return Ok(messageStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
