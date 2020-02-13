using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Expressions;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, FTSDataSheetContext>, IUserDal
    {
        public List<Role> GetRoles(User user)
        {
            using (var context = new FTSDataSheetContext())
            {
                return context.Users.Where(k => k.Id == user.Id).Select(k => k.Role).ToList();
            }
        }
    }
}
