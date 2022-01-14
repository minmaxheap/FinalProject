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
	public class StartWorkDAC:IDisposable
	{

		SqlConnection conn;
		public StartWorkDAC()
		{
			//conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();

		}

		public void Dispose()
		{
			conn.Close();
		}

		public DataTable GetCode()
		{
			string sql = "select LOT_ID from LOT_STS";

			using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}

		public List<string> GetLotCode()
		{
			string sql = @"select LOT_ID,s.PRODUCT_CODE
from LOT_STS s inner
join WORK_ORDER_MST w on s.WORK_ORDER_ID = w.WORK_ORDER_ID
WHERE LEFT(s.PRODUCT_CODE, 2) = 'pd' AND ORDER_STATUS<>'close'";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["LOT_ID"].ToString());

				}
			}
			return List;
		}

		//검사
		public List<string> GetLotOpCode()
		{
			string sql = @"select LOT_ID,s.PRODUCT_CODE
from LOT_STS s inner
join WORK_ORDER_MST w on s.WORK_ORDER_ID = w.WORK_ORDER_ID
left join OPERATION_MST o  on s.OPERATION_CODE = o.OPERATION_CODE
WHERE  LEFT(s.PRODUCT_CODE, 2) = 'pd' AND ORDER_STATUS = 'PROC' and o.CHECK_INSPECT_FLAG ='Y'";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["LOT_ID"].ToString());

				}
			}
			return List;
		}
		//건희 불량 
		public List<string> GetDeffectCode()
		{
			string sql = @"select LOT_ID,s.PRODUCT_CODE
from LOT_STS s inner
join WORK_ORDER_MST w on s.WORK_ORDER_ID = w.WORK_ORDER_ID
left join OPERATION_MST o  on s.OPERATION_CODE = o.OPERATION_CODE
WHERE  LEFT(s.PRODUCT_CODE, 2) = 'pd' AND ORDER_STATUS = 'PROC' and o.CHECK_DEFECT_FLAG ='Y' ";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["LOT_ID"].ToString());

				}
			}
			return List;
		}



		public List<StarWorkProperty> GetOpData(string Code)
		{
			string sql = @"select c.DATA_1,lot.LOT_QTY, lot.LOT_DESC,lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   left join CODE_DATA_MST c on work.CUSTOMER_CODE = c.KEY_1
   where LOT_ID = @LOT_ID and o.CHECK_INSPECT_FLAG = 'y'";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@LOT_ID", Code);

				return Helper.DataReaderMapToList<StarWorkProperty>(cmd.ExecuteReader());
			}
		}

		//모두 다 꺼 
		public List<StarWorkProperty> GetData(string Code)
		{
			string sql = @"select c.DATA_1,lot.LOT_QTY, lot.LOT_DESC,lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   left join CODE_DATA_MST c on work.CUSTOMER_CODE = c.KEY_1
   where LOT_ID = @LOT_ID"; 

				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@LOT_ID", Code);

					return Helper.DataReaderMapToList<StarWorkProperty>(cmd.ExecuteReader());
				}
			
		}

	   

		//실행
		public bool Insert(LOTProperty pr)
		{
			string sql = @" SET XACT_ABORT ON;

			BEGIN TRY

	BEGIN TRANSACTION;

			
 UPDATE LOT_STS
SET LOT_ID =@LOT_ID, LOT_DESC=@LOT_DESC,PRODUCT_CODE=@PRODUCT_CODE,OPERATION_CODE=@OPERATION_CODE,LOT_QTY=@LOT_QTY,CREATE_QTY=@CREATE_QTY,OPER_IN_QTY=@OPER_IN_QTY,START_FLAG='Y',   
START_QTY=@START_QTY,START_TIME=getdate(),START_EQUIPMENT_CODE=@START_EQUIPMENT_CODE,
CREATE_TIME=getdate(),OPER_IN_TIME=getdate(),WORK_ORDER_ID =@WORK_ORDER_ID,
LAST_TRAN_CODE = 'START' , LAST_TRAN_TIME = getdate(),LAST_TRAN_USER_ID = @LAST_TRAN_USER_ID, LAST_TRAN_COMMENT = @LAST_TRAN_COMMENT,LAST_HIST_SEQ = LAST_HIST_SEQ+1,END_FLAG = NULL
where LOT_ID = @LOT_ID


insert LOT_HIS
(LOT_ID
,LOT_DESC
,PRODUCT_CODE
,OPERATION_CODE,
LOT_QTY,
CREATE_QTY,
OPER_IN_QTY,
START_FLAG,
START_QTY,
START_TIME,
START_EQUIPMENT_CODE,
CREATE_TIME	,
OPER_IN_TIME,
WORK_ORDER_ID,
TRAN_CODE,
TRAN_TIME,
TRAN_USER_ID,
TRAN_COMMENT,
HIST_SEQ , 
OLD_PRODUCT_CODE,
OLD_OPERATION_CODE,
OLD_LOT_QTY)

select s.LOT_ID
,s.LOT_DESC
,s.PRODUCT_CODE
,s.OPERATION_CODE,
s.LOT_QTY,
s.CREATE_QTY,
s.OPER_IN_QTY,
s.START_FLAG,
s.START_QTY,
s.START_TIME,
s.START_EQUIPMENT_CODE,
s.CREATE_TIME,
s.OPER_IN_TIME,
s.WORK_ORDER_ID,
s.LAST_TRAN_CODE,
s.LAST_TRAN_TIME,
s.LAST_TRAN_USER_ID,
s.LAST_TRAN_COMMENT,
s.LAST_HIST_SEQ,
h.PRODUCT_CODE,
h.OPERATION_CODE,
h.LOT_QTY

from LOT_STS S left join LOT_HIS h on s.LOT_ID = h.LOT_ID
where s.LOT_ID = @LOT_ID and h.HIST_SEQ = s.LAST_HIST_SEQ-1


 update WORK_ORDER_MST
  set ORDER_STATUS ='PROC'
  where WORK_ORDER_ID =@WORK_ORDER_ID

 COMMIT TRANSACTION;  
END TRY  
BEGIN CATCH  
   IF (XACT_STATE()) = -1  
    BEGIN         
        PRINT  '에러발생 : ' + ERROR_MESSAGE()  
        ROLLBACK TRANSACTION;        
    END;  
END CATCH;";


			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@LOT_ID", pr.LOT_ID);
				cmd.Parameters.AddWithValue("@LOT_DESC", pr.LOT_DESC);
				cmd.Parameters.AddWithValue("@PRODUCT_CODE", pr.PRODUCT_CODE);
				cmd.Parameters.AddWithValue("@OPERATION_CODE", pr.OPERATION_CODE);
				cmd.Parameters.AddWithValue("@LOT_QTY", pr.LOT_QTY);
				cmd.Parameters.AddWithValue("@CREATE_QTY", pr.CREATE_QTY);
				cmd.Parameters.AddWithValue("@OPER_IN_QTY", pr.OPER_IN_QTY);
				if (pr.START_EQUIPMENT_CODE == null)
				{
					cmd.Parameters.AddWithValue("@START_EQUIPMENT_CODE", DBNull.Value);
				}
				else
				{
					cmd.Parameters.AddWithValue("@START_EQUIPMENT_CODE",pr.START_EQUIPMENT_CODE);

				}

				cmd.Parameters.AddWithValue("@WORK_ORDER_ID", pr.WORK_ORDER_ID);
				
				cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", pr.LAST_TRAN_USER_ID);
				if (pr.LAST_TRAN_COMMENT == null)
				{
					cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", DBNull.Value);

				}
				else
					cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", pr.LAST_TRAN_COMMENT);
				cmd.Parameters.AddWithValue("@START_QTY", pr.START_QTY);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}

   

		}

		// 누나 LotProperty를 가져온다고 치면?
		public List<LOTProperty> GetLotProperty(string Code)
		{
			string sql = @"select lot.LOT_QTY, lot.LOT_DESC ,lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
			where LOT_ID = @LOT_ID";
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@LOT_ID", Code);

				return Helper.DataReaderMapToList<LOTProperty>(cmd.ExecuteReader());
			}
		}

		public List<EndPropertyEQ> GetEqList(string EqCode)
		{
			string sql = @"
SELECT DATA_1 as EQ_NAME
FROM CODE_DATA_MST
WHERE KEY_1=@KEY_1";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				List<EndPropertyEQ> List = new List<EndPropertyEQ>();

				cmd.Parameters.AddWithValue("@KEY_1", EqCode);
				return Helper.DataReaderMapToList<EndPropertyEQ>(cmd.ExecuteReader());
			}
		}
	}
}
