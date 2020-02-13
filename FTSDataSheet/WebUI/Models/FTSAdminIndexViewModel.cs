using Entities.Dto.ExcelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class FTSAdminIndexViewModel
    {
        public List<DataSheetMonthlyDto> DataSheetMonthlyDtos { get; set; }
        public List<DataSheetYearlyDto> DataSheetYearlyDtos { get; set; }
    }
}
