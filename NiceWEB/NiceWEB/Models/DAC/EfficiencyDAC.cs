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

        public List<Efficiency> GetData(string startDate, string endDate, string workID, string prdCode, int page, int pagesize)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);

				//StringBuilder sb = new StringBuilder();

				cmd.CommandText = @"
SET ANSI_WARNINGS OFF;

SET ARITHIGNORE ON;

SET ARITHABORT OFF;



SELECT ORDER_DATE
	,ORDER_QTY
	,PRODUCT_QTY
	,DEFECT_QTY
		,QUALITY_RATE
	,DEFECT_RATE
	,WORK_START_TIME
	,WORK_END_TIME
	,WORK_TIME
	,TOTAL_DOWN,
	cast((WORK_TIME/(WORK_TIME+TOTAL_DOWN))*100.0 as decimal(4,0)) as WORK_RATE,
	cast((TOTAL_DOWN/(WORK_TIME+TOTAL_DOWN))*100 as decimal(4,0)) AS DOWN_RATE, 
	(PRODUCT_QTY+DEFECT_QTY)/(WORK_TIME+TOTAL_DOWN) AS PER_TIME

	FROM
	(SELECT DISTINCT 
	W.ORDER_DATE
	,W.ORDER_QTY
	,W.PRODUCT_QTY
	,(W.ORDER_QTY-W.PRODUCT_QTY)DEFECT_QTY
		,cast((PRODUCT_QTY/W.ORDER_QTY)*100.0 as decimal(4,0)) as QUALITY_RATE
	,cast(( (W.ORDER_QTY-W.PRODUCT_QTY)/W.ORDER_QTY)*100 as decimal(4,0)) AS DEFECT_RATE
	,H.WORK_START_TIME
	,H.WORK_END_TIME
	,ISNULL(H.WORK_TIME,0) WORK_TIME
	,ISNULL(E.TOTAL_DOWN,0)TOTAL_DOWN,
	cast((ISNULL(WORK_TIME,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)))*100.0 as decimal(4,0)) as WORK_RATE,
	cast((ISNULL(TOTAL_DOWN,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)))*100 as decimal(4,0)) AS DOWN_RATE, 
	ISNULL(ORDER_QTY,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)) AS PER_TIME,
	   row_number() over(order by ORDER_DATE DESC) as RowNum
	FROM 
	(SELECT CONVERT(VARCHAR,ORDER_DATE,23) TRAN_TIME, CONVERT(varchar, MIN(WORK_START_TIME) ,108)WORK_START_TIME,CONVERT(varchar,MAX(WORK_CLOSE_TIME),108) WORK_END_TIME, 
	DATEDIFF(MINUTE,MIN(WORK_START_TIME),MAX(WORK_CLOSE_TIME)) WORK_TIME FROM WORK_ORDER_MST
	GROUP BY CONVERT(VARCHAR,ORDER_DATE,23)
	)AS H,
	(
	SELECT CONVERT(VARCHAR,OPER_IN_TIME,23) ORDER_DATE, SUM(CREATE_QTY) ORDER_QTY,SUM(S.LOT_QTY) PRODUCT_QTY FROM LOT_STS S 
	WHERE SHIP_FLAG = 'Y' 
	AND PRODUCT_CODE  like @ProductCode
	and WORK_ORDER_ID like @WORK_ORDER_ID
	and CONVERT(VARCHAR,OPER_IN_TIME,23)  between isnull(@startDate,CONVERT(VARCHAR,OPER_IN_TIME,23) ) and isnull(@endDate,CONVERT(VARCHAR,OPER_IN_TIME,23) )
	GROUP BY CONVERT(VARCHAR,OPER_IN_TIME,23) 

	) AS W
	LEFT OUTER JOIN 	(SELECT DT_DATE, ISNULL(SUM(DT_TIME),0) AS TOTAL_DOWN FROM EQUIP_DOWN_HIS GROUP BY DT_DATE
	) AS E ON E.DT_DATE = W.ORDER_DATE
	WHERE H.TRAN_TIME = W.ORDER_DATE) A
where RowNum between ((@PAGE_NO - 1) * @PAGE_SIZE) + 1 and (@PAGE_NO * @PAGE_SIZE)


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

				cmd.Parameters.AddWithValue("@PAGE_NO", page);
				cmd.Parameters.AddWithValue("@PAGE_SIZE", pagesize);

				cmd.Connection.Open();

                List<Efficiency> list = Helper.DataReaderMapToList<Efficiency>(cmd.ExecuteReader());
                cmd.Connection.Close();
				if (string.IsNullOrWhiteSpace(startDate)) return null;
				else { return list; }

            }
        }

        public int GetTotalCount(string startDate, string endDate, string workID, string prdCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = conn;

				cmd.CommandText = @"

 	SELECT count(*) 
 from (SELECT DISTINCT 
	W.ORDER_DATE
	,W.ORDER_QTY
	,W.PRODUCT_QTY
	,(W.ORDER_QTY-W.PRODUCT_QTY)DEFECT_QTY
		,cast((PRODUCT_QTY/W.ORDER_QTY)*100.0 as decimal(4,0)) as QUALITY_RATE
	,cast(( (W.ORDER_QTY-W.PRODUCT_QTY)/W.ORDER_QTY)*100 as decimal(4,0)) AS DEFECT_RATE
	,H.WORK_START_TIME
	,H.WORK_END_TIME
	,ISNULL(H.WORK_TIME,0) WORK_TIME
	,ISNULL(E.TOTAL_DOWN,0)TOTAL_DOWN,
	cast((ISNULL(WORK_TIME,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)))*100.0 as decimal(4,0)) as WORK_RATE,
	cast((ISNULL(TOTAL_DOWN,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)))*100 as decimal(4,0)) AS DOWN_RATE, 
	ISNULL(ORDER_QTY,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)) AS PER_TIME,
	   row_number() over(order by ORDER_DATE) as RowNum
	FROM 
	(SELECT CONVERT(VARCHAR,ORDER_DATE,23) TRAN_TIME, CONVERT(varchar, MIN(WORK_START_TIME) ,108)WORK_START_TIME,CONVERT(varchar,MAX(WORK_CLOSE_TIME),108) WORK_END_TIME, 
	DATEDIFF(MINUTE,MIN(WORK_START_TIME),MAX(WORK_CLOSE_TIME)) WORK_TIME FROM WORK_ORDER_MST
	GROUP BY CONVERT(VARCHAR,ORDER_DATE,23)
	)AS H,
	(
	SELECT CONVERT(VARCHAR,OPER_IN_TIME,23) ORDER_DATE, SUM(CREATE_QTY) ORDER_QTY,SUM(S.LOT_QTY) PRODUCT_QTY FROM LOT_STS S 
	WHERE SHIP_FLAG = 'Y' 
	AND PRODUCT_CODE  like @ProductCode
	and WORK_ORDER_ID like @WORK_ORDER_ID
	and CONVERT(VARCHAR,OPER_IN_TIME,23)  between isnull(@startDate,CONVERT(VARCHAR,OPER_IN_TIME,23) ) and isnull(@endDate,CONVERT(VARCHAR,OPER_IN_TIME,23) )
	GROUP BY CONVERT(VARCHAR,OPER_IN_TIME,23) 

	) AS W
	LEFT OUTER JOIN 	(SELECT DT_DATE, ISNULL(SUM(DT_TIME),0) AS TOTAL_DOWN FROM EQUIP_DOWN_HIS GROUP BY DT_DATE
	) AS E ON E.DT_DATE = W.ORDER_DATE
	WHERE H.TRAN_TIME = W.ORDER_DATE) A
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
				//sb.Append(" order by STORE_CODE,OPER_IN_TIME,LOT_ID ");
				if (string.IsNullOrWhiteSpace(startDate)) return 0;
				else { return Convert.ToInt32(cmd.ExecuteScalar()); }
            }
        }

        public DataTable GetChartData(string startDate, string endDate, string workID, string prdCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);

                cmd.CommandText = @"
SET ANSI_WARNINGS OFF;

SET ARITHIGNORE ON;

SET ARITHABORT OFF;

	WITH DATE_LIST 
	AS (
		select Convert(varchar(10),@startDate) as DT
		union all
		select Convert(varchar(10), DateAdd(day, 1, DT), 23) DT
		from DATE_LIST
		where DT < @endDate
	),
   DATA AS
   (

SELECT DISTINCT 
	W.ORDER_DATE
	,W.ORDER_QTY
	,W.PRODUCT_QTY
	,(W.ORDER_QTY-W.PRODUCT_QTY)DEFECT_QTY
		,cast((PRODUCT_QTY/W.ORDER_QTY)*100.0 as decimal(4,0)) as QUALITY_RATE
	,cast(( (W.ORDER_QTY-W.PRODUCT_QTY)/W.ORDER_QTY)*100 as decimal(4,0)) AS DEFECT_RATE
	,H.WORK_START_TIME
	,H.WORK_END_TIME
	,ISNULL(H.WORK_TIME,0) WORK_TIME
	,ISNULL(E.TOTAL_DOWN,0)TOTAL_DOWN,
	cast((ISNULL(WORK_TIME,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)))*100.0 as decimal(4,0)) as WORK_RATE,
	cast((ISNULL(TOTAL_DOWN,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)))*100 as decimal(4,0)) AS DOWN_RATE, 
	ISNULL(ORDER_QTY,0)/(ISNULL(WORK_TIME,0)+ISNULL(TOTAL_DOWN,0)) AS PER_TIME
	FROM 
	(SELECT CONVERT(VARCHAR,ORDER_DATE,23) TRAN_TIME, CONVERT(varchar, MIN(WORK_START_TIME) ,108)WORK_START_TIME,CONVERT(varchar,MAX(WORK_CLOSE_TIME),108) WORK_END_TIME, 
	DATEDIFF(MINUTE,MIN(WORK_START_TIME),MAX(WORK_CLOSE_TIME)) WORK_TIME FROM WORK_ORDER_MST
	GROUP BY CONVERT(VARCHAR,ORDER_DATE,23)
	)AS H,
	(
	SELECT CONVERT(VARCHAR,OPER_IN_TIME,23) ORDER_DATE, SUM(CREATE_QTY) ORDER_QTY,SUM(S.LOT_QTY) PRODUCT_QTY FROM LOT_STS S 
	WHERE SHIP_FLAG = 'Y' 
		AND PRODUCT_CODE  like @ProductCode
	and WORK_ORDER_ID like @WORK_ORDER_ID
	and CONVERT(VARCHAR,OPER_IN_TIME,23)  between isnull(@startDate,CONVERT(VARCHAR,OPER_IN_TIME,23) ) and isnull(@endDate,CONVERT(VARCHAR,OPER_IN_TIME,23) )
	GROUP BY CONVERT(VARCHAR,OPER_IN_TIME,23) 

	) AS W
	LEFT OUTER JOIN 	(SELECT DT_DATE, ISNULL(SUM(DT_TIME),0) AS TOTAL_DOWN FROM EQUIP_DOWN_HIS GROUP BY DT_DATE
	) AS E ON E.DT_DATE = W.ORDER_DATE
	WHERE H.TRAN_TIME = W.ORDER_DATE) 
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