using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
           // conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
            
        }

        public DataTable GetUserList(string userID)
        {

            string sql = @"SELECT [USER_ID]
      ,[USER_NAME]
      ,[USER_GROUP_CODE]
      ,[USER_PASSWORD]
      ,[USER_DEPARTMENT]
  FROM [team3].[dbo].[USER_MST]
  WHERE USER_ID=@USER_ID";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.SelectCommand.Parameters.AddWithValue("@USER_ID", userID);
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetUserFunctionList(string userID)
        {

            string sql = @"select FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, PNT_FUNCTION_CODE, FUNCTION_LEVEL, PROGRAM_NAME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from FUNCTION_MST
where FUNCTION_CODE in (

select FUNCTION_CODE
from USER_MST U inner join FUNCTION_USER_GROUP_REL A on U.USER_GROUP_CODE = a.USER_GROUP_CODE
where U.USER_ID = @USER_ID
)
union

select distinct P.FUNCTION_CODE, P.FUNCTION_NAME, P.SHORT_CUT_KEY, P.ICON_INDEX, P.PNT_FUNCTION_CODE, P.FUNCTION_LEVEL, P.PROGRAM_NAME, P.CREATE_TIME, P.CREATE_USER_ID, P.UPDATE_TIME, P.UPDATE_USER_ID
from FUNCTION_MST p inner join FUNCTION_MST c on p.FUNCTION_CODE = C.PNT_FUNCTION_CODE
where c.FUNCTION_CODE in (select FUNCTION_CODE
from USER_MST U inner join FUNCTION_USER_GROUP_REL A on U.USER_GROUP_CODE = a.USER_GROUP_CODE
where U.USER_ID = @USER_ID)";


            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.SelectCommand.Parameters.AddWithValue("@USER_ID", userID);
                da.Fill(dt);
                return dt;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
