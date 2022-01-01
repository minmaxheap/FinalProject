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
    public class LOTDAC : IDisposable
    {
        SqlConnection conn;

        public LOTDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetWorkOrderList()
        {
            string sql = @"SELECT WORK_ORDER_ID
      ,ORDER_DATE
      ,w.CUSTOMER_CODE
	  ,cd.DATA_1 CUSTOMER_NAME_JOIN
      ,w.PRODUCT_CODE
	  ,pm.PRODUCT_NAME PRODUCT_CODE_JOIN
      ,ORDER_QTY
      ,ORDER_STATUS
      ,PRODUCT_QTY
      ,DEFECT_QTY
      ,WORK_START_TIME
      ,WORK_CLOSE_TIME
      ,WORK_CLOSE_USER_ID
      ,w.CREATE_TIME
      ,w.CREATE_USER_ID
      ,w.UPDATE_TIME
      ,w.UPDATE_USER_ID
  FROM WORK_ORDER_MST w, PRODUCT_MST pm, CODE_DATA_MST cd
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetLOTList()
        {
            string sql = @"select LOT_ID, LOT_DESC, L.PRODUCT_CODE, P.PRODUCT_NAME PRODUCT_NAME, OPERATION_CODE,LOT_QTY
from [dbo].[LOT_STS] L inner join PRODUCT_MST P ON L.PRODUCT_CODE = P.PRODUCT_CODE

select LOT_ID, LOT_DESC, PRODUCT_CODE, OPERATION_CODE, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY, START_FLAG, START_QTY, 
START_TIME, START_EQUIPMENT_CODE, END_FLAG, END_TIME, END_EQUIPMENT_CODE, SHIP_FLAG, SHIP_CODE, SHIP_TIME, PRODUCTION_TIME, 
CREATE_TIME, OPER_IN_TIME, WORK_ORDER_ID, LOT_DELETE_FLAG, LOT_DELETE_CODE, LOT_DELETE_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME, LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ
from [dbo].[LOT_STS]
WHERE LOT_ID=''

SELECT  HIST_SEQ, TRAN_TIME, TRAN_CODE, L.OPERATION_CODE,O.OPERATION_NAME OPERATION_NAME,LOT_QTY, START_FLAG
from [dbo].[LOT_HIS] L inner join [dbo].[OPERATION_MST] O ON L.OPERATION_CODE = O.OPERATION_CODE
where LOT_ID=''
order by HIST_SEQ desc";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }


        public List<string> GetOperationCode()
        {
            string sql = @"SELECT [KEY_1] as 'PRODUCT_TYPE'
        FROM [dbo].[CODE_DATA_MST]
        WHERE [CODE_TABLE_NAME] ='CM_PRODUCT_TYPE'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["PRODUCT_TYPE"].ToString());

                }
            }

            return productType;
        }



        public List<string> GetStoreCode()
        {
            string sql = @"SELECT [KEY_1] as 'PRODUCT_TYPE'
        FROM [dbo].[CODE_DATA_MST]
        WHERE [CODE_TABLE_NAME] ='CM_PRODUCT_TYPE'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["PRODUCT_TYPE"].ToString());

                }
            }

            return productType;
        }



        public List<string> GetProductCode()
        {
            string sql = @"SELECT [KEY_1] as 'PRODUCT_TYPE'
        FROM [dbo].[CODE_DATA_MST]
        WHERE [CODE_TABLE_NAME] ='CM_PRODUCT_TYPE'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["PRODUCT_TYPE"].ToString());

                }
            }

            return productType;
        }
    }

}
