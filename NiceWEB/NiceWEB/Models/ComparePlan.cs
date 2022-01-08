using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
    public class ComparePlan
    {
        public string ORDER_DATE { get; set; }
        public string WORK_ORDER_ID { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string ORDER_QTY { get; set; }
        public string PRODUCT_QTY { get; set; }
        public string DEFECT_QTY { get; set; }
        public string QUALITY_RATE { get; set; }
        public string DEFECT_RATE { get; set; }
        public string WORK_CLOSE_TIME { get; set; }
    }

    public class TestData
    {
        public string JsonData { get; set; }
        public string Columns { get; set; }
        public string Data { get; set; }
    }

    public class ColumnsInfo
    {
        public string Title { get; set; }
        public string Data { get; set; }
    }
}