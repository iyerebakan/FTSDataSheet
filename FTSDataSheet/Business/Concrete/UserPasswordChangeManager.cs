using Business.Abstract;
using Business.Providers;
using Core.Utilities.Cryptology;
using DataAccess.Abstract;
using DataAccess.Helpers;
using Entities.Concrete;
using MailSync;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserPasswordChangeManager : IUserPasswordChangeService
    {
        private readonly IUserPasswordChangeDal _changeDal;
        private readonly IEmailProvider _emailProvider;
        public AppConfigurationHelper appConfiguration;
        public UserPasswordChangeManager(IUserPasswordChangeDal changeDal, IEmailProvider emailProvider)
        {
            _changeDal = changeDal;
            _emailProvider = emailProvider;
            appConfiguration = new AppConfigurationHelper();
        }
        public void Add(UserPasswordChange instance,string email)
        {
            _changeDal.Add(instance);
            List<EmailAddress> toAddress = new List<EmailAddress>()
            {
                new EmailAddress{ Address = email },
            };
            _emailProvider.Subject = "YKK Portal Şifre Değişikliği Hk";
            _emailProvider.toAddress = toAddress;
            _emailProvider.Content = GetContent(instance);
            _emailProvider.SendMail();
        }

        private string GetContent(UserPasswordChange instance)
        {
            string content = "YKK Portal kullanıcı değişikliğini aşağıdaki adresten yapabilirsiniz. Bilginize;<br><br>";
            var url = appConfiguration.GetWebURL();
            var token = Cryptology.Encrypt(instance.Id.ToString());
            content = content + string.Format("{0}", url + "ChangePassword?passwordtoken=" + token);
            return content;
        }

        public UserPasswordChange GetById(int Id)
        {
            return _changeDal.Get(k => k.Id == Id);
        }

        public void AddByUser(User user)
        {
            var instance = new UserPasswordChange
            {
                Date = DateTime.Now,
                UserId = user.Id,
                Status = false,
                OldPassword = user.Password
            };
            Add(instance,user.Email);
        }

        public void Update(UserPasswordChange instance)
        {
            _changeDal.Update(instance);
        }


    }
}
