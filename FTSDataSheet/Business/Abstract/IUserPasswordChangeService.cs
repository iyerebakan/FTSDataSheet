using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserPasswordChangeService
    {
        void Add(UserPasswordChange instance, string email);
        void Update(UserPasswordChange instance);
        UserPasswordChange GetById(int Id);
        void AddByUser(User user);
    }
}
