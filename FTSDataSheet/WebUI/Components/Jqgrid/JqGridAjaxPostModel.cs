using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Components.Jqgrid
{
    public class JqGridAjaxPostModel
    {
        public bool _search { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }
        public string searchField { get; set; }
        public string searchString { get; set; }
        public string searchOper { get; set; }
        public Filters filters { get; set; }
    }

    public class Filters
    {
        public string groupOp { get; set; }
        public Rules[] rules { get; set; }
    }
    public class Rules
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }
}
