using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly ICountryDal _countryDal;
        private readonly ICityDal _cityDal;
        private readonly IDistrictDal _districtDal;

        public AddressManager(ICountryDal countryDal, ICityDal cityDal, IDistrictDal districtDal)
        {
            _countryDal = countryDal;
            _cityDal = cityDal;
            _districtDal = districtDal;
        }
        
        public List<City> GetCities(Expression<Func<City, bool>> filter = null, Func<IQueryable<City>, IOrderedQueryable<City>> orderby = null, int skip = 0, int take = 10)
        {
            return _cityDal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public City GetCity(int Id)
        {
            return _cityDal.Get(k => k.Id == Id);
        }

        public List<Country> GetCountries(Expression<Func<Country, bool>> filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>> orderby = null, int skip = 0, int take = 10)
        {
            return _countryDal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public Country GetCountry(int Id)
        {
            return _countryDal.Get(k => k.Id == Id);
        }

        public District GetDistrict(int Id)
        {
            return _districtDal.Get(k => k.Id == Id);
        }

        public List<District> GetDistricts(Expression<Func<District, bool>> filter = null, Func<IQueryable<District>, IOrderedQueryable<District>> orderby = null, int skip = 0, int take = 10)
        {
            return _districtDal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }
    }
}
