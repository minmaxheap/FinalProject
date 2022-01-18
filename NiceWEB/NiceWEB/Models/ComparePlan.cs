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
        public decimal ORDER_QTY { get; set; }
        public decimal PRODUCT_QTY { get; set; }
        public decimal DEFECT_QTY { get; set; }
        public decimal QUALITY_RATE { get; set; }
        public decimal DEFECT_RATE { get; set; }
        public string WORK_CLOSE_TIME { get; set; }
    }

 
}