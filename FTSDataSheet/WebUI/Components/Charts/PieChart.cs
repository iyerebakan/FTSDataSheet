using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Components.Charts
{
    public class PieChart
    {
        public PieChart()
        {
            this.Result = 0;
        }
        public double Result { get; set; }
        public string Color { get; set; }
        public string Label { get; set; }
        public string Highlight { get; set; }
    }
}
