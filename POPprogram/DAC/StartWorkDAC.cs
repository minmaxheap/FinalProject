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
			string sql = "select LOT_ID from LOT_STS WHERE  LEFT(PRODUCT_CODE,2) = 'pd'";

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


		public List<StarWorkProperty>  GetData(string Code)
		{
			string sql = @"select lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   where LOT_ID = @LOT_ID";
			if (string.IsNullOrWhiteSpace(Code))
			{
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@LOT_ID", "");

					return Helper.DataReaderMapToList<StarWorkProperty>(cmd.ExecuteReader());
				}
			}
			else
			{
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@LOT_ID", Code);

					return Helper.DataReaderMapToList<StarWorkProperty>(cmd.ExecuteReader());
				}
			}
		}

		public bool Insert(LOTProperty pr)
		{
			string sql = @" SET XACT_ABORT ON;

			BEGIN TRY

	BEGIN TRANSACTION;

			--lot_sts 업데이트문
update LOT_STS
set START_FLAG = 'Y' , START_QTY = @START_QTY,START_TIME = GETDATE(),START_EQUIPMENT_CODE = @START_EQUIPMENT_CODE, LAST_TRAN_CODE = @LAST_TRAN_CODE , LAST_TRAN_TIME = GETDATE(),LAST_TRAN_USER_ID = @LAST_TRAN_USER_ID, LAST_TRAN_COMMENT = @LAST_TRAN_COMMENT
	where LOT_ID = @LOT_ID


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
	}
}
