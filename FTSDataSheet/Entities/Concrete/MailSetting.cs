using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MailSetting : IEntity
    {
        public int Id { get; set; }
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string SendingEmail { get; set; }
        public string Password { get; set; }
        public bool SSL { get; set; }
        public string DisplayName { get; set; }
    }
}
