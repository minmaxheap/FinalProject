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
    
    public class ComparePlanDAC :IDisposable
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

        public DataTable GetData(string from, string to, string workID, string prdCode )
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);

                StringBuilder sb = new StringBuilder();

                sb.Append(@"  SELECT CONVERT(varchar, CONVERT(DATE, ORDER_DATE)) ORDER_DATE,WORK_ORDER_ID,  W.PRODUCT_CODE, P.PRODUCT_NAME, 
ORDER_QTY,  PRODUCT_QTY, DEFECT_QTY,
cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,0)) as QUALITY_RATE,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,0)) AS DEFECT_RATE, CONVERT(varchar, WORK_CLOSE_TIME)WORK_CLOSE_TIME
FROM [dbo].[WORK_ORDER_MST] W, PRODUCT_MST P
WHERE W.PRODUCT_CODE = P.PRODUCT_CODE");

                if(!(string.IsNullOrWhiteSpace(from)) && !(string.IsNullOrWhiteSpace(to)))
                {
                    sb.Append(" and ");
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                }

                if (!(string.IsNullOrWhiteSpace(workID)))
                {
                    sb.Append(" and ");
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", workID);
                }

                if (!(string.IsNullOrWhiteSpace(prdCode)))
                {
                    sb.Append(" and ");
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", prdCode);
                }
                cmd.CommandText = sb.ToString();
            
                DataTable dt = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                //List<StoreProperty> list = Helper.DataReaderMapToList<StoreProperty>(cmd.ExecuteReader());
                //return list;


                return dt;
            }
        }

        public List<ComparePlan> GetChartData(string from, string to)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT CONVERT(varchar, count(WORK_ORDER_ID)) WORK_ORDER_ID, sum(ORDER_QTY) ORDER_QTY,  sum(PRODUCT_QTY) PRODUCT_QTY , sum(DEFECT_QTY) DEFECT_QTY
FROM [dbo].[WORK_ORDER_MST] W";
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);


                cmd.Connection.Open();
                List<ComparePlan> list = Helper.DataReaderMapToList<ComparePlan>(cmd.ExecuteReader());
                cmd.Connection.Close();



                return list;
            }

        }


    }
}