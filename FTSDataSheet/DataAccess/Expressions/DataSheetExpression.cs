using Core.Utilities.Extensions;
using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.ExcelDto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Expressions
{
    public static class DataSheetExpression
    {
        public static Expression<Func<DataSheet, DataSheetDto>> DataSheets
        {
            get
            {
                return c => new DataSheetDto()
                {
                    Id = c.Id,
                    CreateDate = c.CreateDate,
                    CreateUserName = c.User.FirstName + " " + c.User.LastName,
                    Department = c.Department == 1 ? "Bay" : c.Department == 2 ? "Bayan" : "Çocuk",
                    MainCustomer = c.MainCustomer,
                    MainCustomerSampleNumber = c.MainCustomerSampleNumber,
                    SampleNumber = c.SampleNumber,
                    Status = c.Status == 0 ? "Gönderilmedi" : c.Status == 1 ? "Cevap Bekliyor" : "Tamamlandı",
                    TestResult = c.TestResult == null ? "" : c.TestResult == 1 ? "Good" : "No Good"
                };
            }
        }

        public static Expression<Func<DataSheet, DataSheetWaitingForAdminDto>> DataSheetWaitingForAdminDto
        {
            get {
                return c => new DataSheetWaitingForAdminDto()
                {
                    CreateDate = c.CreateDate.DateStringWithTime(),
                    CreateUserName = c.User.FirstName + " " + c.User.LastName,
                    Department = c.Department == 1 ? "Bay" : c.Department == 2 ? "Bayan" : "Çocuk",
                    MainCustomer = c.MainCustomer,
                    MainCustomerSampleNumber = c.MainCustomerSampleNumber,
                    SampleNumber = c.SampleNumber,
                    Status = c.Status == 0 ? "Gönderilmedi" : c.Status == 1 ? "Cevap Bekliyor" : "Tamamlandı",
                    CustomerName = c.Customer.DisplayName,
                    DataSheetNumber = c.DataSheetNumber
                };
            }
        }

        public static Expression<Func<DataSheet, DataSheetListForExportDto>> DataSheetListForExportDto
        {
            get
            {
                return c => new DataSheetListForExportDto()
                {
                    CreateDate = c.CreateDate.DateStringWithTime(),
                    CreateUserName = c.User.FirstName + " " + c.User.LastName,
                    Department = c.Department == 1 ? "Bay" : c.Department == 2 ? "Bayan" : "Çocuk",
                    MainCustomer = c.MainCustomer,
                    MainCustomerSampleNumber = c.MainCustomerSampleNumber,
                    SampleNumber = c.SampleNumber,
                    Status = c.Status == 0 ? "Gönderilmedi" : c.Status == 1 ? "Cevap Bekliyor" : "Tamamlandı", 
                };
            }
        }

        public static Expression<Func<DataSheet, DataSheetCities>> DataSheetCities
        {
            get
            {
                return c => new DataSheetCities()
                {
                    Id = c.Id,
                    CityId = (int)c.Customer.CityId,
                    Customer = c.Customer.DisplayName
                };
            }
        }

    }
}
