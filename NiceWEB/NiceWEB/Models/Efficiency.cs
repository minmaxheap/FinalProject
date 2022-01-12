using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
    public class Efficiency
    {

        public DateTime ORDER_DATE { get; set; }
        public decimal ORDER_QTY { get; set; }
        public decimal PRODUCT_QTY { get; set; }
        public decimal DEFECT_QTY { get; set; }
        public decimal QUALITY_RATE { get; set; }
        public decimal DEFECT_RATE { get; set; }
        public DateTime WORK_START_TIME { get; set; }
        public DateTime WORK_CLOSE_TIME { get; set; }

        public int WORK_TIME { get; set; }
        public decimal TOTAL_DOWN { get; set; }

        public decimal WORK_RATE { get; set; }
        public decimal DOWN_RATE { get; set; }
        public decimal PER_TIME { get; set; }
    }
}