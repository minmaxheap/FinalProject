using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
	public class INSPECT_OPERATIONDAC:IDisposable
	{
		SqlConnection conn;

		public INSPECT_OPERATIONDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}

		public DataTable Op_GetTable()
		{
			string sql = @"	select OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
	from OPERATION_MST";

			DataTable dt = new DataTable();
			using (SqlDataAdapter da = new SqlDataAdapter(sql,conn))
			{
				da.Fill(dt);
				return dt;
			}
		}
	}
}
