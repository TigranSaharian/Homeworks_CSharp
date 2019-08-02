using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FantasyFootbal.Models.User
{
    /// <summary>
    /// A class that gives us the ability to recover a forgotten password by email
    /// </summary>
    public class RestorePassword
    {
        public void SendEmail(string SendTo, string URLEnd)
        {
            // Create a message and set up the recipients.
            MailMessage mailMessage = new MailMessage("ayartest@gmail.com", SendTo);

            // Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP)
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587, // Port 587 is for msa: Message submission agent
            };

            smtp.EnableSsl = true;
            mailMessage.Body = "http://localhost:57537/Home/NewPassword?password=" + URLEnd;
            smtp.Credentials = new NetworkCredential("ayartest@gmail.com", "test123456");
            smtp.Send(mailMessage);
        }
    }
}
