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

        public List<string> GetStore_Code()
        {
            StockDAC dac = new StockDAC();
            List<string> List = dac.GetStore_Code();
            dac.Dispose();
            return List;
        }

        public bool SaveStockLot(List<string> lotlist, string storeID, string msUserID)
        {
            StockDAC dac = new StockDAC();
            bool bResult = dac.SaveStockLot(lotlist, storeID, msUserID);
            dac.Dispose();
            return bResult;
        }
    }
}

