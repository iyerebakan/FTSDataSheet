using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Components.Select2
{
    public class Select2Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Select2Model> CustomerSelect2Model(List<Customer> customers)
        {
            List<Select2Model> select2 = new List<Select2Model>();
            foreach (var item in customers)
            {
                select2.Add(new Select2Model
                {
                    Id = item.Id,
                    Name = item.DisplayName
                });
            }
            return select2;
        }

        public static List<Select2Model> CountrySelect2Model(List<Country> countries)
        {
            List<Select2Model> select2 = new List<Select2Model>();
            foreach (var item in countries)
            {
                select2.Add(new Select2Model
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return select2;
        }

        public static List<Select2Model> CitySelect2Model(List<City> cities)
        {
            List<Select2Model> select2 = new List<Select2Model>();
            foreach (var item in cities)
            {
                select2.Add(new Select2Model
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return select2;
        }

        public static List<Select2Model> DistrictSelect2Model(List<District> districts)
        {
            List<Select2Model> select2 = new List<Select2Model>();
            foreach (var item in districts)
            {
                select2.Add(new Select2Model
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return select2;
        }
    }
}
