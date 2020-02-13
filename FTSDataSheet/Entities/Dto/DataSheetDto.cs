using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class DataSheetDto : IDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CreateUserName { get; set; }
        public string DataSheetNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Department { get; set; }
        public string MainCustomer { get; set; }
        public string MainCustomerSampleNumber { get; set; }
        public string SampleNumber { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public int? FTSUser { get; set; }
        public string FTSUserName { get; set; }
        public string YKKProductCode1 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TestResult { get; set; }
    }
}
