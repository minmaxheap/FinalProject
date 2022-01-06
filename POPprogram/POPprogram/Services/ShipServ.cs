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

    }
}

