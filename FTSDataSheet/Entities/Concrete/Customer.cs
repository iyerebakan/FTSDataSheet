using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string CommercialTitle { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Identifier { get; set; }
        public string FaxNumber { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<User> Users { get; set; }

        [InverseProperty("Customers")]
        public virtual Country Country { get; set; }

        [InverseProperty("Customers")]
        public virtual City City { get; set; }

        [InverseProperty("Customers")]
        public virtual District District { get; set; }

    }
}
