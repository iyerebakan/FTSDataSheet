using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
    }
}
