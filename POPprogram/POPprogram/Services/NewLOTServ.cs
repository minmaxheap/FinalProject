using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POPprogram
{
    public class WorkOrderServ
    {
        public DataTable GetWorkOrderList()
        {
            NewLOTDAC dac = new NewLOTDAC();
            DataTable dt = dac.GetWorkOrderList();
            dac.Dispose();
            return dt;
        }

    }
}
