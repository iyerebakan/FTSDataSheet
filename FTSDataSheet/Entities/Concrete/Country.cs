using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
