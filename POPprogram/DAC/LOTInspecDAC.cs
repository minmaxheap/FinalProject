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
	public class LOTInspecDAC:IDisposable
	{
		SqlConnection conn;
		public LOTInspecDAC()
		{
			//conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();

		}

		public void Dispose()
		{
			conn.Close();
		}


		public DataTable GetInspec(string Code)
		{
			string sql = @"select ir.OPERATION_CODE,ir.INSPECT_ITEM_CODE,i.INSPECT_ITEM_NAME,i.VALUE_TYPE,i.SPEC_LSL,i.SPEC_TARGET,i.SPEC_USL,'' as 검사데이터, ''as 유효값 from INSPECT_ITEM_OPERATION_REL ir
	left join INSPECT_ITEM_MST i on ir.INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE
	where OPERATION_CODE = @OPERATION_CODE";

			using (SqlCommand cmd = new SqlCommand(sql,conn))
			{
				cmd.Parameters.AddWithValue("@OPERATION_CODE", Code);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;

			}
		}
		public List<string> GetCode()
		{

			string sql = "select EQUIPMENT_CODE from EQUIPMENT_MST";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["EQUIPMENT_CODE"].ToString());

				}
			}
			return List;
		}

		public bool insert(string LAST_TRAN_USER_ID,string LAST_TRAN_COMMENT, string LOT_ID, DataTable dt)
		{
			//for(int i=0;i<dt.Rows.Count;i++)
			try
			{
				//SqlTransaction trans = conn.BeginTransaction();
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "dbo.InsertOrderItems2";
					cmd.Connection = conn;

					cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", LAST_TRAN_USER_ID);
					cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", LAST_TRAN_COMMENT);
					cmd.Parameters.AddWithValue("@LOT_ID", LOT_ID);
					cmd.Parameters.AddWithValue("@dtCnt", dt.Rows.Count);

					cmd.Parameters.Add(new SqlParameter("@ItemList", SqlDbType.Structured)
					{
						TypeName = "dbo.MyList4",
						Value = dt
					});

					int row = cmd.ExecuteNonQuery();
					return row > 0;
				}
			}
			catch (SqlException err)  // 에러 : Severity=11+ 인 경우
			{
				Debug.WriteLine(err.Message);
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
