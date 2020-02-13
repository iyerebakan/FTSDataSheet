using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class DataSheet : IEntity
    {
        public int Id { get; set; }
        public int Department { get; set; }
        public string Contact { get; set; }
        public string MainCustomer { get; set; }
        public string TelephoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CustomerId { get; set; }
        public DateTime? SampleSentDate { get; set; }
        public string MainCustomerSampleNumber { get; set; }
        public string SampleNumber { get; set; }
        public string FabricType { get; set; }
        public string YKKProductCode1 { get; set; }
        public string YKKProductCode2 { get; set; }
        public string MainCustomerContact { get; set; }
        public int Status { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? FTSUserId { get; set; }
        public string ProductPosition1 { get; set; }
        public string ProductPosition2 { get; set; }
        public string ProductPosition3 { get; set; }
        public string ProductPosition4 { get; set; }
        public string DataSheetNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TestResult { get; set; }

        [InverseProperty("DataSheet")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Customer Customer { get; set; }

        [InverseProperty("DataSheet")]
        public virtual ICollection<File> Files { get; set; }

        [InverseProperty("DataSheet")]
        [ForeignKey("CreateUser")]
        public virtual User User { get; set; }

        [InverseProperty("FTSDataSheet")]
        [ForeignKey("FTSUserId")]
        public virtual User FTSUser { get; set; }
    }
}
