﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.ExcelDto
{
    public class DataSheetListForExportDto : IDto
    {
        public string CreateUserName { get; set; }
        public string CreateDate { get; set; }
        public string Department { get; set; }
        public string MainCustomer { get; set; }
        public string MainCustomerSampleNumber { get; set; }
        public string SampleNumber { get; set; }
        public string Status { get; set; }
    }
}
