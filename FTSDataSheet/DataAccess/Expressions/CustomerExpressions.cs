using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Expressions
{
    public static class CustomerExpressions
    {
        public static Expression<Func<CustomerUser, CustomerUser>> CustomerUsers
        {
            get
            {
                return c => new CustomerUser()
                {
                    Id = c.Id,
                    CustomerId = c.CustomerId,
                    UserId = c.UserId
                };
            }
        }
    }
}
