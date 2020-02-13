using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISettingsService
    {
        MailSetting GetMailSetting();
        void AddMailSetting(MailSetting mailSetting);
        void UpdateMailSetting(MailSetting mailSetting);
    }
}
