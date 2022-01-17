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

    public class ComparePlanDAC : IDisposable
    {
        SqlConnection conn;
        public ComparePlanDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }



       
        public List<ComparePlan> GetPageList(string startDate, string endDate, string workID, string prdCode, int page, int pagesize)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"

	 SELECT  ORDER_DATE,WORK_ORDER_ID,  A.PRODUCT_CODE, A.PRODUCT_NAME, 
	ORDER_QTY,  PRODUCT_QTY, DEFECT_QTY,
	cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,0)) as QUALITY_RATE,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,0)) AS DEFECT_RATE, 
	 WORK_CLOSE_TIME
	FROM (
			select ORDER_DATE, W.WORK_ORDER_ID,  W.PRODUCT_CODE, P.PRODUCT_NAME, 
	ORDER_QTY,  L.LOT_QTY AS PRODUCT_QTY, (ORDER_QTY-L.LOT_QTY)DEFECT_QTY,
	cast(((L.LOT_QTY/ORDER_QTY))*100.0 as decimal(4,0)) as QUALITY_RATE,	cast((((ORDER_QTY-L.LOT_QTY)/ORDER_QTY))*100.0 as decimal(4,0)) AS DEFECT_RATE, 
	WORK_CLOSE_TIME,   row_number() over(order by W.WORK_ORDER_ID) as RowNum
	FROM [dbo].[WORK_ORDER_MST] W, PRODUCT_MST P,LOT_STS L
	WHERE W.PRODUCT_CODE = P.PRODUCT_CODE AND L.WORK_ORDER_ID = W.WORK_ORDER_ID AND L.PRODUCT_CODE = P.PRODUCT_CODE AND L.SHIP_FLAG = 'Y'
	and w.PRODUCT_CODE  like @ProductCode
	and WORK_ORDER_ID like @WORK_ORDER_ID
	and ORDER_DATE between isnull(@startDate,Convert(varchar,ORDER_DATE,23)) and isnull(@endDate,Convert(varchar,ORDER_DATE,23))
	)A
		where RowNum between ((@PAGE_NO - 1) * @PAGE_SIZE) + 1 and (@PAGE_NO * @PAGE_SIZE)";
               // cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", $"%{workID}%");

                cmd.Parameters.AddWithValue("@ProductCode", $"%{prdCode}%");

                if(string.IsNullOrWhiteSpace(startDate))

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
                List<ComparePlan> list = Helper.DataReaderMapToList<ComparePlan>(reader);
                reader.Close();
                return list;

            }
        }
        public List<ComparePlan> GetChartData(string startDate, string endDate, string workID, string prdCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT CONVERT(varchar, count(W.WORK_ORDER_ID)) WORK_ORDER_ID, sum(ORDER_QTY) ORDER_QTY,  sum( L.LOT_QTY) PRODUCT_QTY , (sum(ORDER_QTY)-sum( L.LOT_QTY)) DEFECT_QTY
FROM [dbo].[WORK_ORDER_MST] W ,LOT_STS L
WHERE  L.WORK_ORDER_ID = W.WORK_ORDER_ID AND L.SHIP_FLAG = 'Y'
AND w.PRODUCT_CODE  like @ProductCode 
and W.WORK_ORDER_ID like @WORK_ORDER_ID 
and ORDER_DATE between isnull(@startDate,Convert(varchar,ORDER_DATE,23)) and isnull(@endDate,Convert(varchar,ORDER_DATE,23))

";
                if (string.IsNullOrWhiteSpace(startDate))

                    cmd.Parameters.AddWithValue("@startDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@startDate", startDate);


                if (string.IsNullOrWhiteSpace(endDate))

                    cmd.Parameters.AddWithValue("@endDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", $"%{workID}%");

                cmd.Parameters.AddWithValue("@ProductCode", $"%{prdCode}%");

                cmd.Connection.Open();
                List<ComparePlan> list = Helper.DataReaderMapToList<ComparePlan>(cmd.ExecuteReader());
                cmd.Connection.Close();



                return list;
            }

        }

        public int GetTotalCount(string startDate, string endDate, string workID, string prdCode )
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = conn;
                cmd.CommandText = @"select count(*) 
	FROM [dbo].[WORK_ORDER_MST] W, PRODUCT_MST P, LOT_STS L
	WHERE W.PRODUCT_CODE = P.PRODUCT_CODE AND L.WORK_ORDER_ID = W.WORK_ORDER_ID AND L.PRODUCT_CODE = P.PRODUCT_CODE AND L.SHIP_FLAG = 'Y'	
	and w.PRODUCT_CODE  like @ProductCode
	and WORK_ORDER_ID like @WORK_ORDER_ID
and ORDER_DATE between isnull(@startDate,Convert(varchar,ORDER_DATE,23)) and isnull(@endDate,Convert(varchar,ORDER_DATE,23))
";
                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", $"%{workID}%");

                cmd.Parameters.AddWithValue("@ProductCode", $"%{prdCode}%");

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