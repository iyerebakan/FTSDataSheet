using Business.Abstract;
using Business.Constants;
using Business.Providers;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.LinqKits;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using MailSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private readonly IEmailProvider _emailProvider;
        public UserManager(IUserDal userDal,IEmailProvider emailProvider)
        {
            _userDal = userDal;
            _emailProvider = emailProvider;
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetByMailForCustomerUser(string email)
        {
            return _userDal.Get(k => k.Email == email && k.Role.Name == Roles.Customer && k.Status == true);
        }

        public User GetByMailForFTSUser(string email)
        {
            return _userDal.Get(k => k.Email == email && k.Role.Name != Roles.Customer && k.Status == true);
        }

        public List<Role> GetRoles(User user)
        {
            return _userDal.GetRoles(user);
        }

        public List<User> GetAllFTSUsers(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderby = null, int skip = 0, int take = 10)
        {
            filter = filter ?? (x => true);
            filter = filter.And(k => k.Role.Name != Roles.Customer);
            return _userDal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public List<User> GetAllCustomerUsers(Expression<Func<User, bool>> filter = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderby = null, int skip = 0, int take = 10, string includeProperties = "")
        {
            filter = filter ?? (x => true);
            filter = filter.And(k => k.Role.Name == Roles.Customer);
            return _userDal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take, includeProperties: "Customer");
        }

        public int UserCount(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.Count(filter);
        }

        public User GetById(int userid)
        {
            return _userDal.Get(k => k.Id == userid);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(k => k.Email == email);
        }

        public IDataResult<User> Register(User user, string password)
        {
            if (user.Id > 0)
            {
                Update(user);
            }
            else
                Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> UserExists(string email)
        {
            var user = GetByMail(email);
            if (user != null)
            {
                return new ErrorDataResult<User>(user, Messages.UserAlreadyExists);
            }
            return new SuccessDataResult<User>();
        }

        public List<User> GetUserByCustomerId(int customerId)
        {
            return _userDal.GetAll(k => k.CustomerId == customerId);
        }

        public void SendMailUser(int Id)
        {
            var user = GetById(Id);

            List<EmailAddress> toAddress = new List<EmailAddress>()
            {
                new EmailAddress{ Address = user.Email },
            };
            _emailProvider.Subject = "YKK Data Sheet Kullanıcı Bildirimi Hk.";
            _emailProvider.toAddress = toAddress;
            _emailProvider.Content = GetContent(user);
            _emailProvider.SendMail();
        }

        private string GetContent(User user)
        {
            string content = "YKK Portal giriş kullanıcınız açılmıştır. Bilginize;<br><br>";
            content = content + "<b>Kullanıcı Adı</b> : " + user.Email;
            content = content + "<b>Şifre</b> : " + user.Password;
            content = content + "<b>Giriş URL</b> : ";

            return content;
        }
    }
}
