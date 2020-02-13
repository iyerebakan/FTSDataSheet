using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IAddressService
    {
        List<Country> GetCountries(Expression<Func<Country, bool>> filter = null,
            Func<IQueryable<Country>, IOrderedQueryable<Country>> orderby = null, int skip = 0, int take = 10);
        List<City> GetCities(Expression<Func<City, bool>> filter = null,
            Func<IQueryable<City>, IOrderedQueryable<City>> orderby = null, int skip = 0, int take = 10);
        List<District> GetDistricts(Expression<Func<District, bool>> filter = null,
            Func<IQueryable<District>, IOrderedQueryable<District>> orderby = null, int skip = 0, int take = 10);

        Country GetCountry(int Id);
        City GetCity(int Id);
        District GetDistrict(int Id);
    }
}
