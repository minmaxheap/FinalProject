using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class FunctionDAC : IDisposable
    {
        SqlConnection conn;
        
        public FunctionDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
            
        }

        public void GetFunctionInfo()
        {
            string sql = @"select FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, PNT_FUNCTION_CODE, FUNCTION_LEVEL, PROGRAM_NAME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[FUNCTION_MST]";
            using(SqlDataAdapter da = new SqlDataAdapter())
            {
                
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
