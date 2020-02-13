using Business.Abstract;
using MailSync;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Providers
{
    public class EmailProvider : IEmailProvider
    {
        private readonly ISettingsService _settingsService;
        public EmailProvider(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public List<EmailAddress> toAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public void SendMail()
        {
            var configuration = _settingsService.GetMailSetting();
            EmailService emailService = new EmailService(new EmailConfiguration
            {
                EmailAddress = configuration.SendingEmail,
                Password = configuration.Password,
                Port = configuration.Port,
                Smtp = configuration.Smtp,
                SSL = configuration.SSL,
                DisplayName = configuration.DisplayName
            });

            emailService.Send(new EmailMessage
            {
                FromAddress = new EmailAddress { Address = configuration.SendingEmail },
                ToAddresses = toAddress,
                Subject = Subject,
                Content = Content
            });
        }
    }
}
