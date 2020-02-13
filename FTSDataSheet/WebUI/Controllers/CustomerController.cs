using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Components;
using WebUI.Components.Select2;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = nameof(Roles.FTSAdmin))]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        private readonly CustomerHelper _customerHelper;
        public CustomerController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _customerHelper = new CustomerHelper();
            _addressService = addressService;
        }

        [Route("musteriler")]
        public IActionResult CustomerList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CustomerListDataTable([FromBody] DataTableAjaxPostModel model)
        {
            var expression = _customerHelper.CreateSearchExpression(model);

            var customerList = _customerService.GetAllCustomers(
                expression,
                _customerHelper.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in customerList
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.DisplayName,
                             a.CommercialTitle,
                             a.TelephoneNumber,
                             a.EmailAddress,
                             a.WebAddress
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _customerService.CustomerCount(),
                recordsFiltered = _customerService.CustomerCount(expression),
                data = result
            });
        }

        [Route("musteri/{Id}")]
        public IActionResult Customer(int Id = 0)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (Id > 0)
            {
                model.Customer = _customerService.GetById(Id);
                model.Countries = _addressService.GetCountries(k => k.Id != model.Customer.CountryId, skip: 0, take: 10);
                model.Cities = _addressService.GetCities(k => k.Id != model.Customer.CityId, skip: 0, take: 10);
                model.Districts = _addressService.GetDistricts(k => k.Id != model.Customer.DistrictId, skip: 0, take: 10);

                if(model.Customer.CountryId != null)
                    model.Countries.Add(_addressService.GetCountry((int)model.Customer.CountryId));

                if(model.Customer.CityId != null)
                    model.Cities.Add(_addressService.GetCity((int)model.Customer.CityId));

                if(model.Customer.DistrictId != null)
                    model.Districts.Add(_addressService.GetDistrict((int)model.Customer.DistrictId));
            }
            else
            {
                model.Customer = new Customer
                {
                    Id = 0,
                    DisplayName = "",
                    CommercialTitle = "",
                    EmailAddress = "",
                    TelephoneNumber = "",
                    WebAddress = ""
                };
                model.Countries = _addressService.GetCountries();
                model.Cities = _addressService.GetCities();
                model.Districts = _addressService.GetDistricts();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AddOrUpdateCustomer(CustomerViewModel model)
        {
            if (model.Customer.Id == 0)
                _customerService.Add(model.Customer);
            else
                _customerService.Update(model.Customer);
            return RedirectToAction("Customer", "Customer", new { Id = model.Customer.Id });
        }

        [HttpPost]
        public JsonResult DeleteCustomer([FromBody]Customer model)
        {
            try
            {
                _customerService.Delete(model);
                return Json("");
            }
            catch (Exception exception)
            {
                return Json("Hata Oluştu.. " + exception.Message);
            }
        }

        public JsonResult GetCustomers(string searchTerm, int pageSize = 0, int pageNum = 0)
        {
            List<Customer> customers;
            if (searchTerm == null)
                customers = _customerService.GetAllCustomers(take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                customers = _customerService.GetAllCustomers(k => k.DisplayName.Contains(searchTerm), take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = customers.Count(),
                Results = Select2Model.CustomerSelect2Model(customers)
            };

            return new JsonResult(result);
        }

    }
}