using Core.Utilities.LinqKits;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebUI.Components;

namespace WebUI.Helpers
{
    public class DataSheetHelper
    {
        public Expression<Func<DataSheetDto, bool>> CreateSearchExpression(DataTableAjaxPostModel model)
        {
            Expression<Func<DataSheetDto, bool>> predicate = null;

            var searchBy = (model.search != null) ? string.IsNullOrEmpty(model.search.value) ? null : model.search.value : null;

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                predicate = SearchAllColumnsQuery(searchBy);
            }
            if (model.columns != null)
            {
                if (model.columns.Where(k => k.search.value != null && k.search.value != "").Count() > 0)
                {
                    predicate = SearchSingleColumnQuery(model.columns);
                }
            }
            return predicate;
        }

        /// <summary>
        ///  Kolon Kolon Arama İşlemi
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        private Expression<Func<DataSheetDto, bool>> SearchSingleColumnQuery(List<Column> columns)
        {
            var predicate = PredicateBuilder.True<DataSheetDto>();
            foreach (Column col in columns)
            {
                if (!string.IsNullOrWhiteSpace(col.search.value))
                {
                    var searchBy = col.search.value;
                    if (col.name == "FTSUserName")
                        predicate = predicate.And(k => k.FTSUserName.Contains(searchBy));
                    if (col.name == "DataSheetNumber")
                        predicate = predicate.And(k => k.DataSheetNumber.Contains(searchBy));
                    if (col.name == "StartDate")
                        predicate = predicate.And(k => k.StartDate >= Convert.ToDateTime(searchBy));
                    if (col.name == "EndDate")
                        predicate = predicate.And(k => k.EndDate >= Convert.ToDateTime(searchBy));
                    if (col.name == "Department")
                        predicate = predicate.And(k => k.Department.Contains(searchBy));
                    if (col.name == "YKKProductCode1")
                        predicate = predicate.And(k => k.YKKProductCode1.Contains(searchBy));
                    if (col.name == "MainCustomer")
                        predicate = predicate.And(k => k.MainCustomer.Contains(searchBy));
                    if (col.name == "MainCustomerSampleNumber")
                        predicate = predicate.And(k => k.MainCustomerSampleNumber.Contains(searchBy));
                    if (col.name == "SampleNumber")
                        predicate = predicate.And(k => k.SampleNumber.Contains(searchBy));
                    if (col.name == "Status")
                        predicate = predicate.And(k => k.Status.Contains(searchBy));
                    if (col.name == "CustomerName")
                        predicate = predicate.And(k => k.CustomerName.Contains(searchBy));
                    if (col.name == "TestResult")
                        predicate = predicate.And(k => k.TestResult.Contains(searchBy));
                }
            }
            return predicate;
        }
        /// <summary>
        /// Tüm kolonlarda arama (sadece data tipi string olanlar)
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private Expression<Func<DataSheetDto, bool>> SearchAllColumnsQuery(string searchBy)
        {
            Expression<Func<DataSheetDto, bool>> predicate = PredicateBuilder.False<DataSheetDto>();
            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                var searchTerms = searchBy.Split('|').ToList().ConvertAll(x => x.ToLower());
                foreach (var item in searchTerms)
                {
                    predicate = predicate.Or(s => s.MainCustomer.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.DataSheetNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.MainCustomerSampleNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.SampleNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.CustomerName.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.FTSUserName.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.YKKProductCode1.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.TestResult.ToLower().Contains(item));
                }
            }
            return predicate;
        }

        public Func<IQueryable<DataSheetDto>, IOrderedQueryable<DataSheetDto>> CreateOrderExpression(DataTableAjaxPostModel model)
        {
            string sortBy = "Id";
            bool sortDir = false;

            if (model.order != null)
            {
                sortBy = model.columns[model.order[0].column].name;
                sortDir = model.order[0].dir.ToLower() == "desc";
            }

            Func<IQueryable<DataSheetDto>, IOrderedQueryable<DataSheetDto>> order = null;

            if (!sortDir)
            {
                if (sortBy == "Id")
                    order = (m => m.OrderByDescending(k => k.Id));
                else if (sortBy == "DataSheetNumber")
                    order = (m => m.OrderByDescending(k => k.DataSheetNumber));
                else if (sortBy == "StartDate")
                    order = (m => m.OrderByDescending(k => k.StartDate));
                else if (sortBy == "EndDate")
                    order = (m => m.OrderByDescending(k => k.EndDate));
                else if (sortBy == "Department")
                    order = (m => m.OrderByDescending(k => k.Department));
                else if (sortBy == "YKKProductCode1")
                    order = (m => m.OrderByDescending(k => k.YKKProductCode1));
                else if (sortBy == "MainCustomer")
                    order = (m => m.OrderByDescending(k => k.MainCustomer));
                else if (sortBy == "MainCustomerSampleNumber")
                    order = (m => m.OrderByDescending(k => k.MainCustomerSampleNumber));
                else if (sortBy == "SampleNumber")
                    order = (m => m.OrderByDescending(k => k.SampleNumber));
                else if (sortBy == "Status")
                    order = (m => m.OrderByDescending(k => k.Status));
                else if (sortBy == "CustomerName")
                    order = (m => m.OrderByDescending(k => k.CustomerName));
                else if (sortBy == "FTSUserName")
                    order = (m => m.OrderByDescending(k => k.FTSUserName));
                else if (sortBy == "TestResult")
                    order = (m => m.OrderByDescending(k => k.TestResult));
            }
            else
            {
                if (sortBy == "Id")
                    order = (m => m.OrderBy(k => k.Id));
                else if (sortBy == "DataSheetNumber")
                    order = (m => m.OrderBy(k => k.DataSheetNumber));
                else if (sortBy == "StartDate")
                    order = (m => m.OrderBy(k => k.StartDate));
                else if (sortBy == "EndDate")
                    order = (m => m.OrderBy(k => k.EndDate));
                else if (sortBy == "Department")
                    order = (m => m.OrderBy(k => k.Department));
                else if (sortBy == "YKKProductCode1")
                    order = (m => m.OrderBy(k => k.YKKProductCode1));
                else if (sortBy == "MainCustomer")
                    order = (m => m.OrderBy(k => k.MainCustomer));
                else if (sortBy == "MainCustomerSampleNumber")
                    order = (m => m.OrderBy(k => k.MainCustomerSampleNumber));
                else if (sortBy == "SampleNumber")
                    order = (m => m.OrderBy(k => k.SampleNumber));
                else if (sortBy == "Status")
                    order = (m => m.OrderBy(k => k.Status));
                else if (sortBy == "CustomerName")
                    order = (m => m.OrderBy(k => k.CustomerName));
                else if (sortBy == "FTSUserName")
                    order = (m => m.OrderBy(k => k.FTSUserName));
                else if (sortBy == "TestResult")
                    order = (m => m.OrderBy(k => k.TestResult));
            }

            return order;
        }


        public Expression<Func<DataSheet, bool>> SearchForExcel(string searchBy)
        {
            Expression<Func<DataSheet, bool>> predicate = PredicateBuilder.False<DataSheet>();
            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                var searchTerms = searchBy.Split('|').ToList().ConvertAll(x => x.ToLower());
                foreach (var item in searchTerms)
                {
                    predicate = predicate.Or(s => s.MainCustomer.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.DataSheetNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.MainCustomerSampleNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.SampleNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.Customer.DisplayName.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.FTSUser.FirstName.ToLower().Contains(item));
                }
                return predicate;
            }
            return null;
        }
    }
}
