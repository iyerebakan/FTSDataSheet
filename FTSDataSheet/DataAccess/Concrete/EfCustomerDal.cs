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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, FTSDataSheetContext>, ICustomerDal
    {
        public List<CustomerUser> CustomerUsers(int customerid)
        {
            using (var context = new FTSDataSheetContext())
            {
                return context.CustomerUsers.Where(k => k.CustomerId == customerid).Select(CustomerExpressions.CustomerUsers).ToList();
            }
        }
    }
}
