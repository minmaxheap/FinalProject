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
    public class EfficiencyDAC:IDisposable
    {
        SqlConnection conn;
        public EfficiencyDAC()
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
                cmd.CommandText = @"SELECT  CONVERT(DATE,W.ORDER_DATE),ORDER_QTY,  PRODUCT_QTY, DEFECT_QTY,
cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,2)) as QUALITY_RATE,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,2)) AS DEFECT_RATE, 
CONVERT(TIME, WORK_START_TIME) AS WORK_START_TIME,CONVERT(TIME, WORK_CLOSE_TIME) AS WORK_CLOSE_TIME, T.WORK_TIME, SUM(DT_TIME),
 cast((WORK_TIME/(WORK_TIME+H.DT_TIME))*100.0 as decimal(4,2)) as WORK_RATE,cast((H.DT_TIME/(WORK_TIME+H.DT_TIME))*100 as decimal(4,2)) AS DOWN_RATE, 
(PRODUCT_QTY+DEFECT_QTY)/(WORK_TIME+H.DT_TIME) AS PER_TIME
FROM [dbo].[WORK_ORDER_MST] W, EQUIP_DOWN_HIS H, 
(select ORDER_DATE, DATEDIFF(MINUTE,WORK_START_TIME, WORK_CLOSE_TIME) WORK_TIME from WORK_ORDER_MST WHERE ORDER_STATUS = 'CLOSE' ) AS T
WHERE W.ORDER_STATUS = 'CLOSE' AND CONVERT(DATE,W.ORDER_DATE) = CONVERT(DATE,H.DT_DATE) AND CONVERT(DATE,T.ORDER_DATE) = CONVERT(DATE,W.ORDER_DATE)
GROUP BY W.ORDER_DATE,ORDER_QTY,  PRODUCT_QTY, DEFECT_QTY,WORK_START_TIME,WORK_CLOSE_TIME,T.WORK_TIME";
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
    }
}