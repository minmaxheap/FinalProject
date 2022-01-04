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
	}
}
