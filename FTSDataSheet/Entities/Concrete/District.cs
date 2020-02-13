using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        [InverseProperty("Districts")]
        public virtual City City { get; set; }

        [InverseProperty("District")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
