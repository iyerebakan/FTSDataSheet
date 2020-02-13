using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class DataSheetViewModel
    {
        public DataSheetViewModel()
        {
            this.CustomerUser = false;
        }
        public DataSheet DataSheet { get; set; }
        public string CustomerName { get; set; }
        public List<File> Files { get; set; }
        public bool CustomerUser { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
