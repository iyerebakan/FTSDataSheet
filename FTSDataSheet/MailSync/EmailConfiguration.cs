using System;
using System.Collections.Generic;
using System.Text;

namespace MailSync
{
    public class EmailConfiguration
    {
        public string Smtp { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}
