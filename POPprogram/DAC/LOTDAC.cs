using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
	  ,cd.DATA_1 CUSTOMER_NAME
      ,w.PRODUCT_CODE
	  ,pm.PRODUCT_NAME PRODUCT_NAME
	  ,r.OPERATION_CODE
	  ,o.OPERATION_NAME
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
  FROM WORK_ORDER_MST w, PRODUCT_MST pm, CODE_DATA_MST cd, PRODUCT_OPERATION_REL r, OPERATION_MST o

  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1 and w.PRODUCT_CODE = r.PRODUCT_CODE and r.FLOW_SEQ =1 and o.OPERATION_CODE = r.OPERATION_CODE
";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public bool SetNewLOT(LOTProperty lot)
        {
            try
            {
                string sql = @"INSERT ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return true;
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public DataTable GetLOTAllList()
        {
            string sql = @"select LOT_ID, LOT_DESC, L.PRODUCT_CODE, P.PRODUCT_NAME PRODUCT_NAME, OPERATION_CODE,LOT_QTY
from [dbo].[LOT_STS] L inner join PRODUCT_MST P ON L.PRODUCT_CODE = P.PRODUCT_CODE
";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable GetLOTHistory(string lotID)
        {
            string sql = @"SELECT  HIST_SEQ, TRAN_TIME, TRAN_CODE, L.OPERATION_CODE,O.OPERATION_NAME OPERATION_NAME,LOT_QTY, START_FLAG
from [dbo].[LOT_HIS] L inner join [dbo].[OPERATION_MST] O ON L.OPERATION_CODE = O.OPERATION_CODE
where LOT_ID=@LOT_ID
order by HIST_SEQ desc";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@LOT_ID", lotID);
                da.Fill(dt);
                return dt;
            }
        }

        public List<LOTProperty> GetLOTStatus(string lotID)
        {
            string sql = @"select LOT_ID, LOT_DESC, PRODUCT_CODE, OPERATION_CODE, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY, START_FLAG, START_QTY, 
START_TIME, START_EQUIPMENT_CODE, END_FLAG, END_TIME, END_EQUIPMENT_CODE, SHIP_FLAG, SHIP_CODE, SHIP_TIME, PRODUCTION_TIME, 
CREATE_TIME, OPER_IN_TIME, WORK_ORDER_ID, LOT_DELETE_FLAG, LOT_DELETE_CODE, LOT_DELETE_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME, LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ
from [dbo].[LOT_STS]
WHERE LOT_ID=@LOT_ID
";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@LOT_ID", lotID);
                da.Fill(dt);
                return Helper.DataTableMapToList<LOTProperty>(dt);
            }
        }

        //        public DataTable GetLOTStatus(string lotID)
        //        {
        //            string sql = @"select LOT_ID, LOT_DESC, PRODUCT_CODE, OPERATION_CODE, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY, START_FLAG, START_QTY, 
        //START_TIME, START_EQUIPMENT_CODE, END_FLAG, END_TIME, END_EQUIPMENT_CODE, SHIP_FLAG, SHIP_CODE, SHIP_TIME, PRODUCTION_TIME, 
        //CREATE_TIME, OPER_IN_TIME, WORK_ORDER_ID, LOT_DELETE_FLAG, LOT_DELETE_CODE, LOT_DELETE_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME, LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ
        //from [dbo].[LOT_STS]
        //WHERE LOT_ID=@LOT_ID
        //";
        //            DataTable dt = new DataTable();
        //            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
        //            {
        //                da.SelectCommand.Parameters.AddWithValue("@LOT_ID", lotID);
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }

        public List<string> GetOperationCode()
        {
            string sql = @"select OPERATION_CODE
from [dbo].[OPERATION_MST]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["OPERATION_CODE"].ToString());

                }
            }

            return productType;
        }



        public List<string> GetStoreCode()
        {
            string sql = @"select STORE_CODE
from [dbo].[STORE_MST]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["STORE_CODE"].ToString());

                }
            }

            return productType;
        }



        public List<string> GetProductCode()
        {
            string sql = @"select PRODUCT_CODE
from [dbo].[PRODUCT_MST]
where PRODUCT_TYPE in('FERT','HALB')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["PRODUCT_CODE"].ToString());

                }
            }

            return productType;
        }
    }

}
