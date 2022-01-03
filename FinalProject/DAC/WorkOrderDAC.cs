
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class WorkOrderDAC : IDisposable
    {
        SqlConnection conn;

        public WorkOrderDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public DataTable GetWorkOrderList()
        {
            string sql = @"SELECT WORK_ORDER_ID
      ,ORDER_DATE
      ,w.CUSTOMER_CODE
	  ,cd.DATA_1 CUSTOMER_NAME
      ,w.PRODUCT_CODE
	  ,pm.PRODUCT_NAME PRODUCT_NAME
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

        public bool Insert(WorkOrderProperty vo)
        {
            try
            {
                string sql = @"INSERT INTO [WORK_ORDER_MST]
           ([WORK_ORDER_ID]
           ,[ORDER_DATE]
           ,[PRODUCT_CODE]
           ,[CUSTOMER_CODE]
           ,[ORDER_QTY]
           ,[ORDER_STATUS]
           ,[PRODUCT_QTY]
           ,[DEFECT_QTY]
           ,[WORK_START_TIME]
           ,[WORK_CLOSE_TIME]
           ,[WORK_CLOSE_USER_ID]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID])
     VALUES
            (@WORK_ORDER_ID
           ,@ORDER_DATE
           ,@PRODUCT_CODE
           ,@CUSTOMER_CODE
           ,@ORDER_QTY
           ,@ORDER_STATUS
           ,@PRODUCT_QTY
           ,@DEFECT_QTY
           ,@WORK_START_TIME
           ,@WORK_CLOSE_TIME
           ,@WORK_CLOSE_USER_ID
           ,getdate()
           ,@CREATE_USER_ID) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", vo.WORK_ORDER_ID);
                    if ((vo.ORDER_DATE == default(DateTime)))
                        cmd.Parameters.AddWithValue("@ORDER_DATE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_DATE", vo.ORDER_DATE);
                    if (vo.CUSTOMER_CODE == null)
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    if (vo.PRODUCT_CODE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    if (vo.ORDER_QTY == null)
                        cmd.Parameters.AddWithValue("@ORDER_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    if (vo.ORDER_STATUS == null)
                        cmd.Parameters.AddWithValue("@ORDER_STATUS", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_STATUS", vo.ORDER_STATUS);

                    if (vo.PRODUCT_QTY == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_QTY", vo.PRODUCT_QTY);
                    if (vo.DEFECT_QTY == null)
                        cmd.Parameters.AddWithValue("@DEFECT_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DEFECT_QTY", vo.DEFECT_QTY);
                    if ((vo.WORK_START_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@WORK_START_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_START_TIME", vo.WORK_START_TIME);
                    if (vo.WORK_CLOSE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", vo.WORK_CLOSE_USER_ID);
                    if ((vo.WORK_CLOSE_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", vo.WORK_CLOSE_TIME);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    int row = cmd.ExecuteNonQuery();
                    return row > 0;

                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message); //log에 찍게 해야하나?
                return false;
            }
        }

        public bool Delete(WorkOrderProperty pt)
        {
            try
            {
                string sql = @"delete from [dbo].[WORK_ORDER_MST]
where WORK_ORDER_ID = @WORK_ORDER_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", pt.WORK_ORDER_ID);
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

        public bool Update(WorkOrderProperty vo)
        {
            try
            {
                string sql = @"UPDATE [dbo].[WORK_ORDER_MST] SET
      ORDER_DATE = @ORDER_DATE
      ,PRODUCT_CODE = @PRODUCT_CODE
      ,CUSTOMER_CODE = @CUSTOMER_CODE
      ,ORDER_QTY = @ORDER_QTY
      ,ORDER_STATUS = @ORDER_STATUS
      ,PRODUCT_QTY = @PRODUCT_QTY
      ,DEFECT_QTY = @DEFECT_QTY
      ,WORK_START_TIME = @WORK_START_TIME
      ,WORK_CLOSE_TIME = @WORK_CLOSE_TIME
      ,WORK_CLOSE_USER_ID = @WORK_CLOSE_USER_ID
      ,UPDATE_TIME = getdate()
      ,UPDATE_USER_ID = @UPDATE_USER_ID
      WHERE WORK_ORDER_ID = @WORK_ORDER_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) 
                {
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", vo.WORK_ORDER_ID);
                    if ((vo.ORDER_DATE == default(DateTime)))
                        cmd.Parameters.AddWithValue("@ORDER_DATE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_DATE", vo.ORDER_DATE);
                    if (vo.CUSTOMER_CODE == null)
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    if (vo.PRODUCT_CODE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    if (vo.ORDER_QTY == null)
                        cmd.Parameters.AddWithValue("@ORDER_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    if (vo.ORDER_STATUS == null)
                        cmd.Parameters.AddWithValue("@ORDER_STATUS", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_STATUS", vo.ORDER_STATUS);

                    if (vo.PRODUCT_QTY == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_QTY", vo.PRODUCT_QTY);
                    if (vo.DEFECT_QTY == null)
                        cmd.Parameters.AddWithValue("@DEFECT_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DEFECT_QTY", vo.DEFECT_QTY);
                    if ((vo.WORK_START_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@WORK_START_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_START_TIME", vo.WORK_START_TIME);
                    if (vo.WORK_CLOSE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", vo.WORK_CLOSE_USER_ID);
                    if ((vo.WORK_CLOSE_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", vo.WORK_CLOSE_TIME);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.UPDATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@UPDATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
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

        public List<WorkOrderProperty> GetWorkOrderSearch(WorkOrderPropertySch vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT WORK_ORDER_ID
      ,ORDER_DATE
      ,w.CUSTOMER_CODE
	  ,cd.DATA_1 CUSTOMER_NAME
      ,w.PRODUCT_CODE
	  ,pm.PRODUCT_NAME
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
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1 AND 1=1");


            using (SqlCommand cmd = new SqlCommand())
            {
                if (vo.SEARCH_START_DATE!=default(DateTime))
                {
                    sb.Append(" and ORDER_DATE >= @SEARCH_START_DATE");
                    cmd.Parameters.AddWithValue("@SEARCH_START_DATE", vo.SEARCH_START_DATE);
                }
                if (vo.SEARCH_END_DATE != default(DateTime))
                {
                    sb.Append(" and ORDER_DATE <= @SEARCH_END_DATE");
                    cmd.Parameters.AddWithValue("@SEARCH_END_DATE", vo.SEARCH_END_DATE);
                }
                if (!string.IsNullOrWhiteSpace(vo.WORK_ORDER_ID))
                {
                    sb.Append(" and WORK_ORDER_ID=@WORK_ORDER_ID");
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", vo.WORK_ORDER_ID);
                }
                if (!string.IsNullOrWhiteSpace(vo.CUSTOMER_CODE))
                {
                    sb.Append(" and w.CUSTOMER_CODE=@CUSTOMER_CODE");
                    cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                }
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    sb.Append(" and w.PRODUCT_CODE=@PRODUCT_CODE");
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }
                if (!string.IsNullOrWhiteSpace(vo.ORDER_STATUS))
                {
                    sb.Append(" and ORDER_STATUS=@ORDER_STATUS");
                    cmd.Parameters.AddWithValue("@ORDER_STATUS", vo.ORDER_STATUS);
                }
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;
              

                return Helper.DataReaderMapToList<WorkOrderProperty>(cmd.ExecuteReader());
            }

        }
        public List<string> GetCustomerCode()
        {
            string sql = @"SELECT [KEY_1]  as 'CUSTOMER_CODE'
FROM [dbo].[CODE_DATA_MST]
WHERE [CODE_TABLE_NAME] ='CM_CUSTOMER'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["CUSTOMER_CODE"].ToString());

                }
            }

            return productType;
        }
        public DataTable GetProductCodeName()
        {
            string sql = @"SELECT [PRODUCT_CODE],[PRODUCT_NAME] FROM [PRODUCT_MST]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }
        public List<string> GetProductCodeList()
        {
            string sql = @"SELECT [PRODUCT_CODE] FROM [PRODUCT_MST]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productCodeList = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productCodeList.Add(reader["PRODUCT_CODE"].ToString());

                }
            }

            return productCodeList;
        }
        public bool WorkEnd(WorkOrderProperty vo)
        {
            try
            {
                string sql = @"UPDATE [dbo].[WORK_ORDER_MST] SET
      WORK_CLOSE_TIME = getdate()
      ,WORK_CLOSE_USER_ID = @WORK_CLOSE_USER_ID
      WHERE WORK_ORDER_ID = @WORK_ORDER_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", vo.WORK_ORDER_ID);
                    if ((vo.ORDER_DATE == default(DateTime)))
                        cmd.Parameters.AddWithValue("@ORDER_DATE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_DATE", vo.ORDER_DATE);
                    if (vo.CUSTOMER_CODE == null)
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    if (vo.PRODUCT_CODE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    if (vo.ORDER_QTY == null)
                        cmd.Parameters.AddWithValue("@ORDER_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    if (vo.ORDER_STATUS == null)
                        cmd.Parameters.AddWithValue("@ORDER_STATUS", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_STATUS", vo.ORDER_STATUS);

                    if (vo.PRODUCT_QTY == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_QTY", vo.PRODUCT_QTY);
                    if (vo.DEFECT_QTY == null)
                        cmd.Parameters.AddWithValue("@DEFECT_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DEFECT_QTY", vo.DEFECT_QTY);
                    if ((vo.WORK_START_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@WORK_START_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_START_TIME", vo.WORK_START_TIME);
                    if (vo.WORK_CLOSE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", vo.WORK_CLOSE_USER_ID);
                    if ((vo.WORK_CLOSE_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", vo.WORK_CLOSE_TIME);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.UPDATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@UPDATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
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
        public void Dispose()
        {
            conn.Close();
        }
    }
}
