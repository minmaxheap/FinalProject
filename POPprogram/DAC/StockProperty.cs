using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class StockProperty
    {
        public string SALES_ORDER_ID { get; set; }
        public string CREATE_USER_ID { get; set; }
        public string STOCK_IN_LOT_ID { get; set; }
        public string MATERIAL_CODE { get; set; }
        public decimal STOCK_IN_LOT_QTY { get; set; }
    }
}
