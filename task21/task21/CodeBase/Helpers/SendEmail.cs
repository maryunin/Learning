using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CodeBase.Helpers
{
    public class SendEmail
    {
        public bool Send(string email = "alexey_m@ukr.net", string message = @"http://task21/en/profile/") 
        {
            bool result;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("alexey.maryunin@gmail.com");
                //mail.To.Add("alexey_m@ukr.net");
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                //mail.Body = "This is for testing SMTP mail from GMAIL";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("alexey.maryunin@gmail.com", "Lexa2407");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;           
        }
    }
}
