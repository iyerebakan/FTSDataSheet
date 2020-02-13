using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.ExcelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class DataSheetManager : IDataSheetService
    {
        private readonly IDataSheetDal _dataSheetDal;
        private readonly ICustomerService _customerService;
        public DataSheetManager(IDataSheetDal dataSheetDal,ICustomerService customerService)
        {
            _dataSheetDal = dataSheetDal;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(DataSheetValidator), Priority = 1)]
        public void Add(DataSheet dataSheet)
        {
            if (dataSheet.CustomerId != 0)
            {
                dataSheet.DataSheetNumber = GetLastDataSheetNumberForCustomer(dataSheet.CustomerId);
            }
            else
                dataSheet.DataSheetNumber = "";

            _dataSheetDal.Add(dataSheet);
        }

        public int DataSheetCount(Expression<Func<DataSheetDto, bool>> filter = null)
        {
            return _dataSheetDal.GetDataSheetDtosCount(filter);
        }

        public List<DataSheetMonthlyDto> DataSheetCountMonty()
        {
            return _dataSheetDal.GetDataSheetMonthlyDtos();
        }

        public List<DataSheetYearlyDto> DataSheetCountYearly()
        {
            return _dataSheetDal.GetDataSheetYearlyDtos();
        }

        public int DataSheetElapsedTime()
        {
            throw new NotImplementedException();
        }

        public void Delete(DataSheet dataSheet)
        {
            _dataSheetDal.Delete(dataSheet);
        }

        public List<DataSheetDto> GetAllDataSheets(Expression<Func<DataSheetDto, bool>> filter = null,
            Func<IQueryable<DataSheetDto>, IOrderedQueryable<DataSheetDto>> orderby = null, int skip = 0, int take = 10)
        {
            return _dataSheetDal.GetDataSheetDtos(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public DataSheet GetById(int Id)
        {
            return _dataSheetDal.Get(k => k.Id == Id);
        }

        public List<DataSheetCities> GetDataSheetCities()
        {
            return _dataSheetDal.GetDataSheetCities();
        }

        public List<DataSheetWaitingForAdminDto> GetDataSheetWaitingForAdminDtos(Expression<Func<DataSheet, bool>> filter = null)
        {
            return _dataSheetDal.GetDataSheetWaitingForAdminDtos(filter);
        }

        public string GetLastDataSheetNumberForCustomer(int customerid)
        {
            var datasheet = _dataSheetDal.GetAll(k => k.DataSheetNumber.StartsWith("00"));
            if (datasheet.Count == 0)
            {
                return "00000001";
            }

            int number = Convert.ToInt32(datasheet.Max(k => k.DataSheetNumber.Substring(k.DataSheetNumber.Length - 8, 8)));
            if (number == 0)
            {
                return "00000001";
            }

            var lastnumber = "00000000" + (number + 1).ToString();
            return lastnumber.Substring(lastnumber.Length - 8, 8);
        }

        public string GetLastDataSheetNumberForCustomerOLD(int customerid)
        {
            var custName = _customerService.GetCustomerNameById(customerid).Substring(0,3);
            var datasheet = _dataSheetDal.GetAll(k => k.DataSheetNumber.StartsWith(custName) && k.CustomerId == customerid);
            if (datasheet.Count == 0)
            {
                return custName + "000001";
            }

            int number = Convert.ToInt32(datasheet.Max(k => k.DataSheetNumber.Substring(k.DataSheetNumber.Length - 6, 6)));
            if (number == 0)
            {
                return custName + "000001";
            }

            var lastnumber = "000000" + (number + 1).ToString();
            return custName + lastnumber.Substring(lastnumber.Length - 6, 6);
        }

        [ValidationAspect(typeof(DataSheetValidator), Priority = 1)]
        public void Update(DataSheet dataSheet)
        {
            _dataSheetDal.Update(dataSheet);
        }
    }
}
