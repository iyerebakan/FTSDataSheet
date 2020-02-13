using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SettingsManager : ISettingsService
    {
        private readonly IMailSettingDal _mailSettingDal;
        public SettingsManager(IMailSettingDal mailSettingDal)
        {
            _mailSettingDal = mailSettingDal;
        }
        public void AddMailSetting(MailSetting mailSetting)
        {
            _mailSettingDal.Add(mailSetting);
        }

        public MailSetting GetMailSetting()
        {
            return _mailSettingDal.Get(k => true) ?? new MailSetting();
        }

        public void UpdateMailSetting(MailSetting mailSetting)
        {
            _mailSettingDal.Update(mailSetting);
        }
    }
}
