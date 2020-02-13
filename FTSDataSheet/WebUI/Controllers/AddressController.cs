using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Components.Select2;

namespace WebUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        public JsonResult GetCountries(string searchTerm, int pageSize = 0, int pageNum = 0)
        {
            List<Country> countries;
            if (searchTerm == null)
                countries = _addressService.GetCountries(take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                countries = _addressService.GetCountries(k => k.Name.Contains(searchTerm), take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = countries.Count(),
                Results = Select2Model.CountrySelect2Model(countries)
            };

            return new JsonResult(result);
        }

        public JsonResult GetCities(string searchTerm, int pageSize = 0, int pageNum = 0,int countryId = 0)
        {
            List<City> cities;
            if (searchTerm == null)
                cities = _addressService.GetCities(k => k.CountryId == countryId, take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                cities = _addressService.GetCities(k => k.CountryId == countryId && k.Name.Contains(searchTerm),
                    take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = cities.Count(),
                Results = Select2Model.CitySelect2Model(cities)
            };

            return new JsonResult(result);
        }

        public JsonResult GetDistricts(string searchTerm, int pageSize = 0, int pageNum = 0, int cityId = 0)
        {
            List<District> districts;
            if (searchTerm == null)
                districts = _addressService.GetDistricts(k => k.CityId == cityId, take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                districts = _addressService.GetDistricts(k => k.CityId == cityId && k.Name.Contains(searchTerm),
                    take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = districts.Count(),
                Results = Select2Model.DistrictSelect2Model(districts)
            };

            return new JsonResult(result);
        }
    }
}