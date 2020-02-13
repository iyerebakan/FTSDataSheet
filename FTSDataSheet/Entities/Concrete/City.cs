using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<District> Districts { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
