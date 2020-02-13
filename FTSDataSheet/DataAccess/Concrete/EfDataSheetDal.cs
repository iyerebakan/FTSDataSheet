using Core.DataAccess.EntityFramework;
using Core.Utilities.ConstantLists;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Expressions;
using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.ExcelDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfDataSheetDal : EfEntityRepositoryBase<DataSheet, FTSDataSheetContext>, IDataSheetDal
    {
        public List<DataSheetCities> GetDataSheetCities()
        {
            using (var context = new FTSDataSheetContext())
            {
                return context.DataSheets.Select(DataSheetExpression.DataSheetCities).ToList();
            }
        }

        public List<DataSheetDto> GetDataSheetDtos(Expression<Func<DataSheetDto, bool>> filter = null,
            Func<IQueryable<DataSheetDto>, IOrderedQueryable<DataSheetDto>> orderBy = null, int skip = 0, int take = 0)
        {
            using (var context = new FTSDataSheetContext())
            {
                var listview = from ds in context.DataSheets
                               join us in context.Users
                               on ds.CreateUser equals us.Id into dps
                               from us in dps.DefaultIfEmpty()
                               join cs in context.Customers
                               on ds.CustomerId equals cs.Id into cps
                               from cs in cps.DefaultIfEmpty()
                               join fts in context.Users
                               on ds.FTSUserId equals fts.Id into fps
                               from fts in fps.DefaultIfEmpty()
                               select new DataSheetDto
                               {
                                   Id = ds.Id,
                                   CustomerId = ds.CustomerId,
                                   CreateDate = ds.CreateDate,
                                   CreateUserName = us.FirstName + " " + us.LastName,
                                   Department = ds.Department == 1 ? "Bay" : ds.Department == 2 ? "Bayan" : "Çocuk",
                                   MainCustomer = ds.MainCustomer,
                                   MainCustomerSampleNumber = ds.MainCustomerSampleNumber,
                                   SampleNumber = ds.SampleNumber,
                                   Status = ds.Status == 0 ? "Gönderilmedi" : ds.Status == 1 ? "Süreç Başladı" : "Tamamlandı",
                                   StatusId = ds.Status,
                                   CustomerName = cs.DisplayName,
                                   FTSUser = ds.FTSUserId,
                                   FTSUserName = fts.FirstName + " " + fts.LastName,
                                   DataSheetNumber = ds.DataSheetNumber,
                                   YKKProductCode1 = ds.YKKProductCode1,
                                   StartDate = ds.StartDate,
                                   EndDate = ds.EndDate,
                                   TestResult = ds.TestResult == null ? "" : ds.TestResult == 1 ? "Good" : "No Good"
                               };
                return orderBy(listview.Where(filter)).Take(take).Skip(skip).ToList();
            }

        }

        public int GetDataSheetDtosCount(Expression<Func<DataSheetDto, bool>> filter = null)
        {
            using (var context = new FTSDataSheetContext())
            {
                var listview = from ds in context.DataSheets
                               join us in context.Users
                               on ds.CreateUser equals us.Id into dps
                               from us in dps.DefaultIfEmpty()
                               join cs in context.Customers
                               on ds.CustomerId equals cs.Id into cps
                               from cs in cps.DefaultIfEmpty()
                               join fts in context.Users
                               on ds.FTSUserId equals fts.Id into fps
                               from fts in fps.DefaultIfEmpty()
                               select new DataSheetDto
                               {
                                   Id = ds.Id,
                                   CustomerId = ds.CustomerId,
                                   CreateDate = ds.CreateDate,
                                   CreateUserName = us.FirstName + " " + us.LastName,
                                   Department = ds.Department == 1 ? "Bay" : ds.Department == 2 ? "Bayan" : "Çocuk",
                                   MainCustomer = ds.MainCustomer,
                                   MainCustomerSampleNumber = ds.MainCustomerSampleNumber,
                                   SampleNumber = ds.SampleNumber,
                                   Status = ds.Status == 0 ? "Gönderilmedi" : ds.Status == 1 ? "Süreç Başladı" : "Tamamlandı",
                                   StatusId = ds.Status,
                                   CustomerName = cs.DisplayName,
                                   FTSUser = ds.FTSUserId,
                                   FTSUserName = fts.FirstName + " " + fts.LastName,
                                   DataSheetNumber = ds.DataSheetNumber,
                                   YKKProductCode1 = ds.YKKProductCode1,
                                   StartDate = ds.StartDate,
                                   EndDate = ds.EndDate,
                                   TestResult = ds.TestResult == null ? "" : ds.TestResult == 1 ? "Good" : "No Good"
                               };
                return filter == null
                    ? listview.Count()
                    : listview.Count(filter);
            }
        }

        public List<DataSheetMonthlyDto> GetDataSheetMonthlyDtos()
        {
            using (var context = new FTSDataSheetContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"Select 
                            MONTH(StartDate) Month,
	                        YEAR(StartDate) Year,
	                        Count(*) As Count
                            from DataSheets where StartDate is not null and EndDate is not null
                            and StartDate > DATEADD(YEAR,-1,GETDATE())
                        group by MONTH(StartDate),YEAR(StartDate)";

                context.Database.OpenConnection();

                var list = new List<DataSheetMonthlyDto>();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        list.Add(new DataSheetMonthlyDto
                        {
                            Year = result.GetInt32(1),
                            Month = result.GetInt32(0),
                            Count = result.GetInt32(2),
                            Description = string.Format("{0}/{1}", Months.GetMonthName(result.GetInt32(0)).ToString(),
                                        result.GetInt32(1).ToString().Substring(2)),
                        });
                    }
                    
                }

                context.Database.CloseConnection();

                return list;
            }
        }

        public List<DataSheetWaitingForAdminDto> GetDataSheetWaitingForAdminDtos(Expression<Func<DataSheet, bool>> filter = null)
        {
            using (var context = new FTSDataSheetContext())
            {
                return context.DataSheets.Where(filter).Select(DataSheetExpression.DataSheetWaitingForAdminDto).ToList();
            }
        }

        public List<DataSheetYearlyDto> GetDataSheetYearlyDtos()
        {
            using (var context = new FTSDataSheetContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"Select 
                            MONTH(StartDate) Month,
	                        YEAR(StartDate) Year,
	                        Convert(decimal,(Sum(Datediff(Day, StartDate, EndDate)) / Count(*)),2)  Elapsed
                            from DataSheets where StartDate is not null and EndDate is not null
                            and StartDate > DATEADD(YEAR,-1,GETDATE())
                        group by MONTH(StartDate),YEAR(StartDate)";

                context.Database.OpenConnection();

                var list = new List<DataSheetYearlyDto>();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        list.Add(new DataSheetYearlyDto
                        {
                            Year = result.GetInt32(1),
                            Month = result.GetInt32(0),
                            Average = result.GetDecimal(2),
                            Description = string.Format("{0}/{1}", Months.GetMonthName(result.GetInt32(0)).ToString(),
                                        result.GetInt32(1).ToString().Substring(2)),
                        });
                    }

                }
                context.Database.CloseConnection();

                return list;
            }
        }

        //public List<DataSheetMonthlyDto> GetDataSheetMonthlyDtos()
        //{
        //    using (var context = new FTSDataSheetContext())
        //    {
        //        var list = from p in context.DataSheets
        //                   where p.StartDate != null && p.EndDate != null
        //                   group p by new
        //                   {
        //                       month = p.StartDate.Value.Month,
        //                       year = p.StartDate.Value.Year
        //                   } into d
        //                   select new DataSheetMonthlyDto
        //                   {
        //                       Month = d.Key.month,
        //                       Year = d.Key.year,
        //                       Count = d.Count(),
        //                       Description = string.Format("{0}/{1}", d.Key.month.ToString(), d.Key.year.ToString()),
        //                       Average = (from p in context.DataSheets
        //                                  where p.StartDate.Value.Month == d.Key.month && p.StartDate.Value.Year == d.Key.year
        //                                  select p
        //                                  ).Sum(k => (k.EndDate.Value - k.StartDate.Value).TotalMinutes)
        //                   };
        //        return list.ToList();
        //    }
        //}
    }
}