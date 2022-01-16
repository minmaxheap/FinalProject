using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class ShipServ
    {
        public DataTable GetSalesOrderList()
        {
            ShipDAC dac = new ShipDAC();
            DataTable dt = dac.GetSalesOrderList();
            dac.Dispose();
            return dt;
        }
        public List<ShipPropertySch> GetFSStoreList(ShipProperty vo)
        {
            ShipDAC dac = new ShipDAC();
            List<ShipPropertySch> list = dac.GetFSStoreList(vo);
            dac.Dispose();
            return list;
        }
        
        public DataTable GetLOT()
        {
            ShipDAC dac = new ShipDAC();
            DataTable dt = dac.GetLOT();
            dac.Dispose();
            return dt;
        }

        public bool ShipLOT_Update(List<ShipPropertyUpdate> updateVO)
        {
            ShipDAC dac = new ShipDAC();
            bool bResult = dac.ShipLOT_Update(updateVO);
            dac.Dispose();
            return bResult;
        }

        public DataTable GetBarcodeList()
        {
            ShipDAC dac = new ShipDAC();
            DataTable dt = dac.GetBarcodeList();
            dac.Dispose();
            return dt;
        }

        public DataTable ExportBarcode(string strChkBarCodes)
        {
            ShipDAC dac = new ShipDAC();
            DataTable dt = dac.ExportBarcode(strChkBarCodes);
            dac.Dispose();
            return dt;
        }
    }
}

