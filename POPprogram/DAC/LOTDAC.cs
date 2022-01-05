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

  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1 and w.PRODUCT_CODE = r.PRODUCT_CODE and r.FLOW_SEQ =1 and o.OPERATION_CODE = r.OPERATION_CODE  AND CONVERT(DATE, W.CREATE_TIME) = CONVERT(DATE, GETDATE()) AND ORDER_STATUS <>'CLOSE'


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
                string sql = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

INSERT[dbo].[LOT_STS]
(LOT_ID, LOT_DESC, 
PRODUCT_CODE, OPERATION_CODE, 
LOT_QTY, CREATE_QTY,OPER_IN_QTY,CREATE_TIME,OPER_IN_TIME,
 WORK_ORDER_ID,
LAST_TRAN_CODE,LAST_TRAN_TIME, LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ) 
VALUES(@LOT_ID, @LOT_DESC, 
@PRODUCT_CODE, @OPERATION_CODE, 
@LOT_QTY, @CREATE_QTY,@OPER_IN_QTY, GETDATE(),getdate(),
 @WORK_ORDER_ID,
'CREATE',GETDATE(), @LAST_TRAN_USER_ID, @LAST_TRAN_COMMENT, 1  )

insert [dbo].[LOT_HIS]
(LOT_ID, HIST_SEQ, TRAN_TIME, TRAN_CODE, LOT_DESC, 
PRODUCT_CODE, OPERATION_CODE, LOT_QTY, 
CREATE_QTY,OPER_IN_QTY,CREATE_TIME,OPER_IN_TIME, WORK_ORDER_ID,TRAN_USER_ID, TRAN_COMMENT)
select LOT_ID, s.LAST_HIST_SEQ, s.LAST_TRAN_TIME, s.LAST_TRAN_CODE, LOT_DESC, 
PRODUCT_CODE, OPERATION_CODE, LOT_QTY, 
CREATE_QTY,OPER_IN_QTY,CREATE_TIME,OPER_IN_TIME, WORK_ORDER_ID,LAST_TRAN_USER_ID, LAST_TRAN_COMMENT
from [dbo].[LOT_STS] s
where LOT_ID = @LOT_ID

	COMMIT TRANSACTION;  
END TRY  
BEGIN CATCH  
   IF (XACT_STATE()) = -1  
    BEGIN  	    
        PRINT  '에러발생 : ' + ERROR_MESSAGE()  
        ROLLBACK TRANSACTION;  		
    END;  
END CATCH;  


";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", lot.LOT_ID);
                    cmd.Parameters.AddWithValue("@LOT_DESC", lot.LOT_DESC);
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", lot.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", lot.OPERATION_CODE);
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", lot.WORK_ORDER_ID);
                    cmd.Parameters.AddWithValue("@LOT_QTY", lot.LOT_QTY);
                    cmd.Parameters.AddWithValue("@CREATE_QTY", lot.CREATE_QTY);
                    cmd.Parameters.AddWithValue("@OPER_IN_QTY", lot.LOT_QTY);
                    cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", lot.LAST_TRAN_USER_ID);
                    cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", lot.LAST_TRAN_COMMENT);



                    int row = cmd.ExecuteNonQuery();
                    return row > 0;
                }
            }
            catch (Exception err)
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

        public DataTable GetLOTSearch(LOTSearchProperty pr)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(@"select LOT_ID, LOT_DESC, L.PRODUCT_CODE, P.PRODUCT_NAME PRODUCT_NAME, OPERATION_CODE,LOT_QTY
from [dbo].[LOT_STS] L inner join PRODUCT_MST P ON L.PRODUCT_CODE = P.PRODUCT_CODE
where 1=1");

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand();
                    //da.SelectCommand.Connection = conn;
                    if (!string.IsNullOrWhiteSpace(pr.OPERATION_CODE))
                    {
                        sb.Append(" and OPERATION_CODE = @OPERATION_CODE");
                        cmd.Parameters.AddWithValue("@OPERATION_CODE", pr.OPERATION_CODE);
                    }
                    if (!string.IsNullOrWhiteSpace(pr.LOT_ID))
                    {
                        sb.Append(" and LOT_ID=@LOT_ID");
                        cmd.Parameters.AddWithValue("@LOT_ID", pr.LOT_ID);
                    }
                    if (!string.IsNullOrWhiteSpace(pr.PRODUCT_CODE))
                    {
                        sb.Append(" and L.PRODUCT_CODE=@PRODUCT_CODE");
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", pr.PRODUCT_CODE);
                    }
                    if (!string.IsNullOrWhiteSpace(pr.STORE_CODE))
                    {
                        sb.Append(" and STORE_CODE=@STORE_CODE");
                        cmd.Parameters.AddWithValue("@STORE_CODE", pr.STORE_CODE);
                    }
                    cmd.CommandText = sb.ToString();
                    cmd.Connection = conn;

                    da.SelectCommand = cmd;

                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    return dt;
                }

            
                
            }

            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

        }

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
