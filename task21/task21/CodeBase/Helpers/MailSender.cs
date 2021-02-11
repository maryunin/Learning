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
        public void Send(string email, string message, string subject = "Email verification") 
        {            
            try
            {                
                MailMessage mail = new MailMessage();                
                var smtpClient = new SmtpClient();                             
                mail.To.Add(email);
                mail.Subject = subject;                
                mail.Body = message;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Task21.AddLog<Task21>("An exception was thrown while sending a message to check email.", ex, 1);                
            }        
        }
    }
}
