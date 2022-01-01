using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class FunctionServ
    {

        public DataTable GetUserFunctionList(string userID)
        {

            FunctionDAC dac = new FunctionDAC();
            DataTable dt = dac.GetUserFunctionList(userID);
            dac.Dispose();
            return dt;
        }
    }
}
