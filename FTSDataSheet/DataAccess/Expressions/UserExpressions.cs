using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Expressions
{
    public static class UserExpressions
    {
        public static Expression<Func<UserRole, UserRole>> Roles
        {
            get
            {
                return c => new UserRole()
                {
                    Id = c.Id,
                    UserId = c.UserId
                };
            }
        }
    }
}
