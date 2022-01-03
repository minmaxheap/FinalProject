using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class StockServ
    {
        public DataTable GetPurchaseList()
        {
            StockDAC dac = new StockDAC();
            DataTable dt = dac.GetPurchaseList();
            dac.Dispose();
            return dt;
        }

        public DataTable Purchase_warehousing(string Code)
        {
            StockDAC dac = new StockDAC();
            DataTable dt = dac.Purchase_warehousing(Code);
            dac.Dispose();
            return dt;
        }
    }
}

