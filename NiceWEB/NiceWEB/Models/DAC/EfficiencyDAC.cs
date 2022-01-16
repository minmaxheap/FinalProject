﻿using System;
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
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }


        //public List<Efficiency> GetData(string startDate, string endDate, string workID, string prdCode)
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);

        //        StringBuilder sb = new StringBuilder();

        //        sb.Append(@" SELECT  CONVERT(DATE,W.ORDER_DATE) AS ORDER_DATE,ORDER_QTY,  PRODUCT_QTY, DEFECT_QTY,
        //cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,2)) as QUALITY_RATE,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,2)) AS DEFECT_RATE, 
        //CONVERT(TIME, WORK_START_TIME) AS WORK_START_TIME,CONVERT(TIME, WORK_CLOSE_TIME) AS WORK_CLOSE_TIME, T.WORK_TIME, H2.TOTAL_DOWN,
        // cast((WORK_TIME/(WORK_TIME+H.DT_TIME))*100.0 as decimal(4,2)) as WORK_RATE,cast((H.DT_TIME/(WORK_TIME+H.DT_TIME))*100 as decimal(4,2)) AS DOWN_RATE, 
        //(PRODUCT_QTY+DEFECT_QTY)/(WORK_TIME+H.DT_TIME) AS PER_TIME
        //FROM [dbo].[WORK_ORDER_MST] W, EQUIP_DOWN_HIS H, 
        //(select ORDER_DATE, DATEDIFF(MINUTE,WORK_START_TIME, WORK_CLOSE_TIME) WORK_TIME from WORK_ORDER_MST WHERE ORDER_STATUS = 'CLOSE' ) AS T
        //,(SELECT CONVERT(DATE,DT_DATE) DT_DATE, SUM(DT_TIME) AS TOTAL_DOWN FROM EQUIP_DOWN_HIS GROUP BY DT_DATE) H2
        //WHERE W.ORDER_STATUS = 'CLOSE' AND CONVERT(DATE,W.ORDER_DATE) = CONVERT(DATE,H.DT_DATE) AND CONVERT(DATE,T.ORDER_DATE) = CONVERT(DATE,W.ORDER_DATE)
        //AND H2.DT_DATE = H.DT_DATE");

        //        cmd.CommandText = sb.ToString();
        //        cmd.Connection.Open();

        //        List<Efficiency> list = Helper.DataReaderMapToList<Efficiency>(cmd.ExecuteReader());
        //        cmd.Connection.Close();
        //        return list;

        //    }
        //}

        public List<Efficiency> GetData(string startDate, string endDate, string workID, string prdCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);

                StringBuilder sb = new StringBuilder();

                sb.Append(@"SELECT DISTINCT 
	ORDER_DATE
	,ORDER_QTY
	,PRODUCT_QTY
	,DEFECT_QTY
		,cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,0)) as QUALITY_RATE
	,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,0)) AS DEFECT_RATE
	,H.WORK_START_TIME
	,H.WORK_END_TIME
	,H.WORK_TIME
	,E.TOTAL_DOWN,
	cast((WORK_TIME/(WORK_TIME+TOTAL_DOWN))*100.0 as decimal(4,0)) as WORK_RATE,
	cast((TOTAL_DOWN/(WORK_TIME+TOTAL_DOWN))*100 as decimal(4,0)) AS DOWN_RATE, 
	(PRODUCT_QTY+DEFECT_QTY)/(WORK_TIME+TOTAL_DOWN) AS PER_TIME
	FROM 
	(SELECT CONVERT(VARCHAR,TRAN_TIME,23) TRAN_TIME, CONVERT(varchar, MIN(START_TIME) ,108)WORK_START_TIME,CONVERT(varchar,MAX(END_TIME),108) WORK_END_TIME, DATEDIFF(MINUTE,MIN(START_TIME),MAX(END_TIME)) WORK_TIME
	FROM LOT_HIS
	GROUP BY CONVERT(VARCHAR,TRAN_TIME,23)
	)AS H,
	(SELECT CONVERT(VARCHAR,ORDER_DATE,23) ORDER_DATE,  SUM(ORDER_QTY) ORDER_QTY, SUM(PRODUCT_QTY) PRODUCT_QTY, SUM(DEFECT_QTY)DEFECT_QTY 
	FROM WORK_ORDER_MST 
	GROUP BY CONVERT(VARCHAR,ORDER_DATE,23) ) AS W,
	(SELECT DT_DATE, SUM(DT_TIME) AS TOTAL_DOWN FROM EQUIP_DOWN_HIS GROUP BY DT_DATE) AS E
	WHERE H.TRAN_TIME = W.ORDER_DATE AND E.DT_DATE = W.ORDER_DATE AND E.DT_DATE = H.TRAN_TIME");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", $"%{workID}%");

                cmd.Parameters.AddWithValue("@ProductCode", $"%{prdCode}%");
                cmd.Connection.Open();

                List<Efficiency> list = Helper.DataReaderMapToList<Efficiency>(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;

            }
        }

        public int GetTotalCount(string workID, string prdCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = conn;
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select count(*) from LOT_STS
where LOT_DELETE_FLAG <> 'Y' OR LOT_DELETE_FLAG IS NULL  and STORE_CODE is not  null ");
                if (!string.IsNullOrWhiteSpace(workID))
                {
                    sb.Append(" and STORE_CODE = @STORE_CODE ");
                    cmd.Parameters.AddWithValue("@STORE_CODE", workID);
                }
                if (!string.IsNullOrWhiteSpace(prdCode))
                {
                    sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE ");
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", prdCode);
                }
                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", $"%{workID}%");

                cmd.Parameters.AddWithValue("@ProductCode", $"%{prdCode}%");
                //sb.Append(" order by STORE_CODE,OPER_IN_TIME,LOT_ID ");
                cmd.CommandText = sb.ToString();


                cmd.CommandText = sb.ToString();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable GetChartData(string startDate, string endDate, string workID, string prdCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);

                cmd.CommandText = @"WITH DATE_LIST 
	AS (
		select Convert(varchar(10),@startDate,23) as DT
		union all
		select Convert(varchar(10), DateAdd(day, 1, DT), 23) DT
		from DATE_LIST
		where DT < @endDate	
	),
   DATA AS
   (

SELECT DISTINCT 
	ORDER_DATE
	,ORDER_QTY
	,PRODUCT_QTY
	,DEFECT_QTY
		,cast((PRODUCT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100.0 as decimal(4,0)) as QUALITY_RATE
	,cast( (DEFECT_QTY/(PRODUCT_QTY+DEFECT_QTY))*100 as decimal(4,0)) AS DEFECT_RATE
	,H.WORK_START_TIME
	,H.WORK_END_TIME
	,H.WORK_TIME
	,E.TOTAL_DOWN,
	cast((WORK_TIME/(WORK_TIME+TOTAL_DOWN))*100.0 as decimal(4,0)) as WORK_RATE,
	cast((TOTAL_DOWN/(WORK_TIME+TOTAL_DOWN))*100 as decimal(4,0)) AS DOWN_RATE, 
	(PRODUCT_QTY+DEFECT_QTY)/(WORK_TIME+TOTAL_DOWN) AS PER_TIME
	FROM 
	(SELECT CONVERT(VARCHAR,TRAN_TIME,23) TRAN_TIME, CONVERT(varchar, MIN(START_TIME) ,108)WORK_START_TIME,CONVERT(varchar,MAX(END_TIME),108) WORK_END_TIME, DATEDIFF(MINUTE,MIN(START_TIME),MAX(END_TIME)) WORK_TIME
	FROM LOT_HIS
	GROUP BY CONVERT(VARCHAR,TRAN_TIME,23)
	)AS H,
	(SELECT CONVERT(VARCHAR,ORDER_DATE,23) ORDER_DATE,  SUM(ORDER_QTY) ORDER_QTY, SUM(PRODUCT_QTY) PRODUCT_QTY, SUM(DEFECT_QTY)DEFECT_QTY 
	FROM WORK_ORDER_MST 
	GROUP BY CONVERT(VARCHAR,ORDER_DATE,23) ) AS W,
	(SELECT DT_DATE, SUM(DT_TIME) AS TOTAL_DOWN FROM EQUIP_DOWN_HIS GROUP BY DT_DATE) AS E
	WHERE H.TRAN_TIME = W.ORDER_DATE AND E.DT_DATE = W.ORDER_DATE AND E.DT_DATE = H.TRAN_TIME
	)
SELECT convert(varchar,d.dt,23) DATE, ISNULL(ORDER_QTY,0)ORDER_QTY, ISNULL(PRODUCT_QTY,0)PRODUCT_QTY, 
ISNULL(DEFECT_QTY,0)DEFECT_QTY, ISNULL(QUALITY_RATE,0)QUALITY_RATE, ISNULL(DEFECT_RATE,0)DEFECT_RATE,
ISNULL(WORK_START_TIME,0)WORK_START_TIME,ISNULL(WORK_END_TIME,0)WORK_END_TIME,ISNULL(WORK_TIME,0)WORK_TIME,
ISNULL(TOTAL_DOWN,0)TOTAL_DOWN,ISNULL(WORK_RATE,0)WORK_RATE,ISNULL(DOWN_RATE,0)DOWN_RATE,ISNULL(PER_TIME,0)PER_TIME
FROM DATE_LIST D
LEFT OUTER JOIN DATA A ON CONVERT(VARCHAR,D.DT,23) = CONVERT(VARCHAR,A.ORDER_DATE,23)";

                DataTable dt = new DataTable();

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
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();

                return dt;
            }
        }

    }
}