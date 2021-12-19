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
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
            
        }

        public DataTable GetFuncList()
        {
            string sql = @"select FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, PNT_FUNCTION_CODE, FUNCTION_LEVEL, PROGRAM_NAME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[FUNCTION_MST]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable GetUserGroupList()
        {
            string sql = @"select USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[USER_GROUP_MST]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetRelationList()
        {
            string sql = @"select USER_GROUP_CODE, FUNCTION_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
  from [dbo].[FUNCTION_USER_GROUP_REL]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.Fill(dt);
                return dt;
            }
        }




        public DataTable GetFuncRelationList()
        {
            string sql = @"  select R.USER_GROUP_CODE, FUNCTION_CODE, USER_GROUP_NAME, USER_GROUP_TYPE,  R.CREATE_TIME, R.CREATE_USER_ID, R.UPDATE_TIME, R.UPDATE_USER_ID
  from [dbo].[FUNCTION_USER_GROUP_REL] R inner join [dbo].[USER_GROUP_MST] G ON G.USER_GROUP_CODE = R.USER_GROUP_CODE";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
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
where U.USER_ID = @USER_ID
)";


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
