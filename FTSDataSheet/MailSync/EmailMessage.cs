using System;
using System.Collections.Generic;
using System.Text;

namespace MailSync
{
    public class EmailMessage
    {
        public List<EmailAddress> ToAddresses { get; set; }
        public EmailAddress FromAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
