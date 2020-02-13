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
    public class UserHelper
    {
        public Expression<Func<User, bool>> CreateSearchExpression(DataTableAjaxPostModel model)
        {
            Expression<Func<User, bool>> predicate = null;

            var searchBy = (model.search != null) ? string.IsNullOrEmpty(model.search.value) ? null : model.search.value : null;

            if (searchBy != null)
            {
                predicate = SearchAllColumnsQuery(searchBy);
            }
            if (model.columns !=null)
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
        private Expression<Func<User, bool>> SearchSingleColumnQuery(List<Column> columns)
        {
            var predicate = PredicateBuilder.True<User>();
            foreach (Column col in columns)
            {
                if (col.search.value != null)
                {
                    var searchBy = col.search.value;
                    if (col.name == "FirstName")
                        predicate = predicate.And(k => k.FirstName.Contains(searchBy));
                    if (col.name == "LastName")
                        predicate = predicate.And(k => k.LastName.Contains(searchBy));
                    if (col.name == "Email")
                        predicate = predicate.And(k => k.Email.Contains(searchBy));
                    if (col.name == "Customer")
                        predicate = predicate.And(k => k.Customer.DisplayName.Contains(searchBy));
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
        private Expression<Func<User, bool>> SearchAllColumnsQuery(string searchBy)
        {
            Expression<Func<User, bool>> predicate = PredicateBuilder.False<User>();
            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                var searchTerms = searchBy.Split('|').ToList().ConvertAll(x => x.ToLower());
                foreach (var item in searchTerms)
                {
                    predicate = predicate.Or(s => s.FirstName.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.LastName.ToLower().Contains(item));
                    predicate = predicate.Or(s => s.Email.ToLower().Contains(item));
                }
            }
            return predicate;
        }

        public Func<IQueryable<User>, IOrderedQueryable<User>> CreateOrderExpression(DataTableAjaxPostModel model)
        {
            string sortBy = "Id";
            bool sortDir = false;

            if (model.order != null)
            {
                sortBy = model.columns[model.order[0].column].name;
                sortDir = model.order[0].dir.ToLower() == "desc";
            }

            Func<IQueryable<User>, IOrderedQueryable<User>> order = null;

            if (sortDir)
            {
                if (sortBy == "Id")
                    order = (m => m.OrderByDescending(k => k.Id));
                else if (sortBy == "FirstName")
                    order = (m => m.OrderByDescending(k => k.FirstName));
                else if (sortBy == "LastName")
                    order = (m => m.OrderByDescending(k => k.LastName));
                else if (sortBy == "Email")
                    order = (m => m.OrderByDescending(k => k.Email));
            }
            else
            {
                if (sortBy == "Id")
                    order = (m => m.OrderBy(k => k.Id));
                else if (sortBy == "FirstName")
                    order = (m => m.OrderBy(k => k.FirstName));
                else if (sortBy == "LastName")
                    order = (m => m.OrderBy(k => k.LastName));
                else if (sortBy == "Email")
                    order = (m => m.OrderBy(k => k.Email));
            }

            return order;
        }
    }
}
