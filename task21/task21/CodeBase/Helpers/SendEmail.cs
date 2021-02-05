using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Configuration;
using System.Collections.Specialized;

namespace CodeBase.Helpers
{
    public class SendEmail : ISendEmail
    {
        public bool Send(string email, string message) 
        {
            bool result;
            try
            {
                var settings = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as ConfigurationSection;
                // ????? what is next ?????

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("alexey.maryunin@gmail.com");                
                mail.To.Add(email);
                mail.Subject = "Email verification";                
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
