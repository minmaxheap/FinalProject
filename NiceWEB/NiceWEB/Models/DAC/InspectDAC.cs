using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace NiceWEB.Models
{
    public class InspectDAC : IDisposable
    {
        SqlConnection conn;
        public InspectDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<Inspect> GetPageList(string startDate, string endDate, string prdCode, string operCode, string lotID, int page, int pagesize)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"	 SELECT TRAN_TIME,LOT_ID,  A.PRODUCT_CODE, PRODUCT_NAME, A.OPERATION_CODE, OPERATION_NAME, INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, 
 SPEC_LSL, SPEC_TARGET, SPEC_USL, INSPECT_VALUE,  TRAN_CODE,TRAN_USER_ID
 FROM (	
 SELECT TRAN_TIME,LOT_ID,  H.PRODUCT_CODE, PRODUCT_NAME, H.OPERATION_CODE, OPERATION_NAME, INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, 
 SPEC_LSL, SPEC_TARGET, SPEC_USL, INSPECT_VALUE,  TRAN_CODE,TRAN_USER_ID, row_number() over(order by  LOT_ID) as RowNum
 FROM [dbo].[LOT_INSPECT_HIS] H, PRODUCT_MST P, OPERATION_MST O
 WHERE H.PRODUCT_CODE = P.PRODUCT_CODE AND H.OPERATION_CODE = O.OPERATION_CODE
 AND H.PRODUCT_CODE like @PRODUCT_CODE
 AND H.OPERATION_CODE like @OPERATION_CODE
 AND LOT_ID like @LOT_ID 
and TRAN_TIME between isnull(@startDate,Convert(varchar,TRAN_TIME,23)) and isnull(@endDate,Convert(varchar,TRAN_TIME,23))

 )A
where RowNum between ((@PAGE_NO - 1) * @PAGE_SIZE) + 1 and (@PAGE_NO * @PAGE_SIZE)";

                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", $"%{prdCode}%");
                cmd.Parameters.AddWithValue("@OPERATION_CODE", $"%{operCode}%");
                cmd.Parameters.AddWithValue("@LOT_ID", $"%{lotID}%");

                if (string.IsNullOrWhiteSpace(startDate))

                    cmd.Parameters.AddWithValue("@startDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@startDate", startDate);


                if (string.IsNullOrWhiteSpace(endDate))

                    cmd.Parameters.AddWithValue("@endDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                cmd.Parameters.AddWithValue("@PAGE_NO", page);
                cmd.Parameters.AddWithValue("@PAGE_SIZE", pagesize);


                SqlDataReader reader = cmd.ExecuteReader();
                List<Inspect> list = Helper.DataReaderMapToList<Inspect>(reader);
                cmd.Connection.Close();
                return list;


            }
        }

        public int GetTotalCount(string startDate, string endDate, string prdCode, string operCode, string lotID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = conn;
                cmd.CommandText = @" SELECT count(*) 
 FROM [dbo].[LOT_INSPECT_HIS] H, PRODUCT_MST P, OPERATION_MST O
 WHERE H.PRODUCT_CODE = P.PRODUCT_CODE AND H.OPERATION_CODE = O.OPERATION_CODE
 AND H.PRODUCT_CODE like @PRODUCT_CODE
 AND H.OPERATION_CODE like @OPERATION_CODE
 AND LOT_ID like @LOT_ID
and TRAN_TIME between isnull(@startDate,Convert(varchar,TRAN_TIME,23)) and isnull(@endDate,Convert(varchar,TRAN_TIME,23))
";

                if (conn.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", $"%{prdCode}%");
                cmd.Parameters.AddWithValue("@OPERATION_CODE", $"%{operCode}%");
                cmd.Parameters.AddWithValue("@LOT_ID", $"%{lotID}%");
                if (string.IsNullOrWhiteSpace(startDate))

                    cmd.Parameters.AddWithValue("@startDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@startDate", startDate);


                if (string.IsNullOrWhiteSpace(endDate))

                    cmd.Parameters.AddWithValue("@endDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}