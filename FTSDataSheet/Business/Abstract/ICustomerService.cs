using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerUser> GetCustomerUsers(int customerid);
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
        List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> filter = null,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderby = null, int skip = 0, int take = 10);
        int CustomerCount(Expression<Func<Customer, bool>> filter = null);
        Customer GetById(int customerid);
        string GetCustomerNameById(int customerid);
    }
}
