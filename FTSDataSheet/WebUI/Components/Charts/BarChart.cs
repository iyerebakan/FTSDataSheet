using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Components.Charts
{
    public class BarChart
    {
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public string HighlightFill { get; set; }
        public string HighlightStroke { get; set; }
        public List<BarData> Datas { get; set; }
    }


    public class BarData
    {
        public string Name { get; set; }
        public decimal Data { get; set; }
    }
}
