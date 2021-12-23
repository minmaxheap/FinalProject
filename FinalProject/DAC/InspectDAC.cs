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
	public class InspectDAC : IDisposable
	{
		SqlConnection conn;

		public InspectDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}

		public void Dispose()
		{
			conn.Dispose();
		}

		public DataTable GetInsMst()
		{
			string sql = "select INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID from INSPECT_ITEM_MST ";
			DataTable dt = new DataTable();
			using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
			{
				da.Fill(dt);
				return dt;
			}
		}
	}
}
