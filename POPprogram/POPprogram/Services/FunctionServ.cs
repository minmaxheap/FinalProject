
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
        public DataTable GetFuncList()
        {
            FunctionDAC dac = new FunctionDAC();
            DataTable dt = dac.GetFuncList();
            dac.Dispose();
            return dt;
        }


        public DataTable GetUserGroupList()
        {
            FunctionDAC dac = new FunctionDAC();
            DataTable dt = dac.GetUserGroupList();
            dac.Dispose();
            return dt;
        }

        public DataTable GetRelationList()
        {
            FunctionDAC dac = new FunctionDAC();
            DataTable dt = dac.GetRelationList();
            dac.Dispose();
            return dt;
        }




        public DataTable GetFuncRelationList()
        {
            FunctionDAC dac = new FunctionDAC();
            DataTable dt = dac.GetFuncRelationList();
            dac.Dispose();
            return dt;
        }


        public DataTable GetUserFunctionList(string userID)
        {

            FunctionDAC dac = new FunctionDAC();
            DataTable dt = dac.GetUserFunctionList(userID);
            dac.Dispose();
            return dt;
        }
    }
}
