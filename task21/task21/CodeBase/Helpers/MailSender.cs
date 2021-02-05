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
    public class MailSender : IEmailSender
    {
        public void Send(string email, string message) 
        {            
            try
            {
                //var settings = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as ConfigurationSection;
                
                MailMessage mail = new MailMessage();
                //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                var smtpClient = new SmtpClient();

                //mail.From = new MailAddress("alexey.maryunin@gmail.com");                
                mail.To.Add(email);
                mail.Subject = "Email verification";                
                mail.Body = message;

                //smtpClient.Port = 587;
                //smtpClient.Credentials = new System.Net.NetworkCredential("alexey.maryunin@gmail.com", "Lexa2407");
                //smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Task21.AddLog<Task21>("An exception was thrown while sending a message to check email.", ex, 1);                
            }        
        }
    }
}
