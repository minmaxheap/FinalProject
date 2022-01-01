using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class LOTServ
    {
        public DataTable GetWorkOrderList()
        {
            LOTDAC dac = new LOTDAC();
            DataTable dt = dac.GetWorkOrderList();
            dac.Dispose();
            return dt;
        }

        public DataTable GetLOTList()
        {
            LOTDAC dac = new LOTDAC();
            DataTable dt = dac.GetWorkOrderList();
            dac.Dispose();
            return dt;
        }
    }
}
