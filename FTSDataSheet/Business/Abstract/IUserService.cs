using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<Role> GetRoles(User user);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetByMailForCustomerUser(string email);
        User GetByMailForFTSUser(string email);
        List<User> GetAllFTSUsers(Expression<Func<User, bool>> filter = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderby = null, int skip = 0, int take = 10);
        List<User> GetAllCustomerUsers(Expression<Func<User, bool>> filter = null,
           Func<IQueryable<User>, IOrderedQueryable<User>> orderby = null, int skip = 0, int take = 10, string includeProperties = "");
        int UserCount(Expression<Func<User, bool>> filter = null);
        User GetById(int userid);
        User GetByMail(string email);
        IDataResult<User> Register(User user, string password);
        IDataResult<User> UserExists(string email);
        List<User> GetUserByCustomerId(int customerId);
        void SendMailUser(int Id);
    }
}
