using Business.Abstract;
using MailSync;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Providers
{
    public interface IEmailProvider
    {
        List<EmailAddress> toAddress { get; set; }
        string Subject { get; set; }
        string Content { get; set; }
        void SendMail();
    }
}
