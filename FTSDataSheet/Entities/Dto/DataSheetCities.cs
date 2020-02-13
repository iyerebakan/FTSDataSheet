using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class DataSheetCities : IDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Customer { get; set; }
    }
}
