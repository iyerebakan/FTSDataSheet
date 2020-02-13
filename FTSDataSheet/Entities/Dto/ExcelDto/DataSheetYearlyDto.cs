using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.ExcelDto
{
    public class DataSheetYearlyDto : IDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string Description { get; set; }
        public decimal Average { get; set; }
    }
}
