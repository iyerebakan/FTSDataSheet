using Core.Utilities.LinqKits;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebUI.Components;

namespace WebUI.Helpers
{
    public class CustomerHelper
    {
        public Expression<Func<Customer, bool>> CreateSearchExpression(DataTableAjaxPostModel model)
        {
            Expression<Func<Customer, bool>> predicate = null;

            var searchBy = (model.search != null) ? string.IsNullOrEmpty(model.search.value) ? null : model.search.value : null;

            if (searchBy != null)
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
        private Expression<Func<Customer, bool>> SearchSingleColumnQuery(List<Column> columns)
        {
            var predicate = PredicateBuilder.True<Customer>();
            foreach (Column col in columns)
            {
                if (col.search.value != null)
                {
                    var searchBy = col.search.value;
                    if (col.name == "DisplayName")
                        predicate = predicate.And(k => k.DisplayName.Contains(searchBy));
                    if (col.name == "CommercialTitle")
                        predicate = predicate.And(k => k.CommercialTitle.Contains(searchBy));
                    if (col.name == "TelephoneNumber")
                        predicate = predicate.And(k => k.TelephoneNumber.Contains(searchBy));
                    if (col.name == "EmailAddress")
                        predicate = predicate.And(k => k.EmailAddress.Contains(searchBy));
                    if (col.name == "WebAddress")
                        predicate = predicate.And(k => k.WebAddress.Contains(searchBy));
                }
            }
            return predicate;
        }
        /// <summary>
        /// Tün kolonlarda arama (sadece data tipi string olanlar)
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private Expression<Func<Customer, bool>> SearchAllColumnsQuery(string searchBy)
        {
            Expression<Func<Customer, bool>> predicate = PredicateBuilder.False<Customer>();
            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                var searchTerms = searchBy.Split('|').ToList().ConvertAll(x => x.ToLower());
                foreach (var item in searchTerms)
                {
                    predicate = predicate.Or(s => s.DisplayName.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.CommercialTitle.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.TelephoneNumber.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.EmailAddress.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.WebAddress.ToLower().Contains(item));
                }
            }
            return predicate;
        }

        public Func<IQueryable<Customer>, IOrderedQueryable<Customer>> CreateOrderExpression(DataTableAjaxPostModel model)
        {
            string sortBy = "Id";
            bool sortDir = false;

            if (model.order != null)
            {
                sortBy = model.columns[model.order[0].column].name;
                sortDir = model.order[0].dir.ToLower() == "desc";
            }

            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> order = null;

            if (sortDir)
            {
                if (sortBy == "Id")
                    order = (m => m.OrderByDescending(k => k.Id));
                else if (sortBy == "DisplayName")
                    order = (m => m.OrderByDescending(k => k.DisplayName));
                else if (sortBy == "CommercialTitle")
                    order = (m => m.OrderByDescending(k => k.CommercialTitle));
                else if (sortBy == "TelephoneNumber")
                    order = (m => m.OrderByDescending(k => k.TelephoneNumber));
                else if (sortBy == "EmailAddress")
                    order = (m => m.OrderByDescending(k => k.EmailAddress));
                else if (sortBy == "WebAddress")
                    order = (m => m.OrderByDescending(k => k.WebAddress));
            }
            else
            {
                if (sortBy == "Id")
                    order = (m => m.OrderBy(k => k.Id));
                else if (sortBy == "DisplayName")
                    order = (m => m.OrderBy(k => k.DisplayName));
                else if (sortBy == "CommercialTitle")
                    order = (m => m.OrderBy(k => k.CommercialTitle));
                else if (sortBy == "TelephoneNumber")
                    order = (m => m.OrderBy(k => k.TelephoneNumber));
                else if (sortBy == "EmailAddress")
                    order = (m => m.OrderBy(k => k.EmailAddress));
                else if (sortBy == "WebAddress")
                    order = (m => m.OrderBy(k => k.WebAddress));
            }

            return order;
        }
    }
}
