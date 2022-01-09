using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            conn.Close();
        }

        public DataTable GetData(string from, string to)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT CONVERT(varchar, CONVERT(DATE, ORDER_DATE)) ORDER_DATE,WORK_ORDER_ID,  W.PRODUCT_CODE, P.PRODUCT_NAME, 
ORDER_QTY,  PRODUCT_QTY, DEFECT_QTY,
cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,2)) as QUALITY_RATE,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,2)) AS DEFECT_RATE, CONVERT(varchar, WORK_CLOSE_TIME) WORK_CLOSE_TIME
FROM [dbo].[WORK_ORDER_MST] W, PRODUCT_MST P
WHERE W.PRODUCT_CODE = P.PRODUCT_CODE";
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);

                DataTable dt = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();



                return dt;
            }
        }

        public DataTable GetWorkOrder()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT WORK_ORDER_ID
FROM [dbo].[WORK_ORDER_MST]";
                DataTable dt = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();



                return dt;
            }
        }

        public DataTable GetProductCode()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT DISTINCT PRODUCT_CODE
FROM [dbo].[WORK_ORDER_MST]";
                DataTable dt = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();



                return dt;
            }
        }
    }
}