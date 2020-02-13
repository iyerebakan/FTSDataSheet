using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailSync
{
    public class EmailService
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void Send(EmailMessage email)
        {
            var emailClient = new SmtpClient();
            var basicCredential = new NetworkCredential(_emailConfiguration.EmailAddress, _emailConfiguration.Password);


            MailMessage message = new MailMessage();

            message.From = new MailAddress(_emailConfiguration.EmailAddress,_emailConfiguration.DisplayName);

            emailClient.Host = _emailConfiguration.Smtp;
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = basicCredential;
            emailClient.Port = _emailConfiguration.Port;
            emailClient.EnableSsl = _emailConfiguration.SSL;

            foreach (EmailAddress emailAddress in email.ToAddresses)
            {
                message.To.Add(emailAddress.Address);
            }

            message.IsBodyHtml = true;
            message.Subject = email.Subject;
            message.Body = email.Content;
            emailClient.SendCompleted += EmailClient_SendCompleted;

            string myToken = "Deneme";

            emailClient.SendAsync(message, myToken);

        }

        private void EmailClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Debug.WriteLine("[{0}] Send canceled.", token);
            }
            else if (e.Error != null)
            {
                Debug.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Debug.WriteLine("Message sent.");
            }
        }

        //public void Send(EmailMessage email)
        //{
        //    using (var emailClient = new SmtpClient())
        //    {
        //        var basicCredential = new NetworkCredential(_emailConfiguration.EmailAddress,_emailConfiguration.Password);

        //        using (MailMessage message = new MailMessage())
        //        {
        //            message.From = new MailAddress(_emailConfiguration.EmailAddress);

        //            emailClient.Host = _emailConfiguration.Smtp;
        //            emailClient.UseDefaultCredentials = false;
        //            emailClient.Credentials = basicCredential;
        //            emailClient.Port = _emailConfiguration.Port;
        //            emailClient.EnableSsl = _emailConfiguration.SSL;

        //            foreach (EmailAddress emailAddress in email.ToAddresses)
        //            {
        //                message.To.Add(emailAddress.Address);
        //            }

        //            message.IsBodyHtml = true;
        //            message.Subject = email.Subject;
        //            message.Body = email.Content;
        //            emailClient.SendCompleted += EmailClient_SendCompleted;

        //            string myToken = "Deneme";

        //            emailClient.SendAsync(message,myToken);
        //        }
        //    }

        //}
    }
}
