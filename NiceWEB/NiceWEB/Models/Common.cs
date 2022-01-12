using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
    public class TableData
    {
        public string JsonData { get; set; }
        public string Columns { get; set; }
        public string Data { get; set; }
    }

    public class ColumnsInfo
    {
        public string Title { get; set; }
        public string data { get; set; }
    }

  
}