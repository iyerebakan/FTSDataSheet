using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
