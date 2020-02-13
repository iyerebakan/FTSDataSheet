using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public int CustomerCount(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.Count(filter);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> filter = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderby = null, int skip = 0, int take = 10)
        {
            return _customerDal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public Customer GetById(int customerid)
        {
            return _customerDal.Get(k => k.Id == customerid);
        }

        public string GetCustomerNameById(int customerid)
        {
            return _customerDal.Get(k => k.Id == customerid).DisplayName;
        }

        public List<CustomerUser> GetCustomerUsers(int customerid)
        {
            return _customerDal.CustomerUsers(customerid);
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
