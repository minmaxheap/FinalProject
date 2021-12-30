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

		//공통코드 여기서 가지고오기

		public List<string> GetDeffeg()
		{
			string sql = @"";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> Type = new List<string>();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					Type.Add(reader["Type"].ToString());

				}
			}
			return Type;

		}

		public List<string> GetInspect()
		{
			string sql = @"";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> Type = new List<string>();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					Type.Add(reader["Type"].ToString());

				}
			}
			return Type;
		}

		public List<string> GetMaterial()
		{
			string sql = @"";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> Type = new List<string>();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					Type.Add(reader["Type"].ToString());

				}
			}
			return Type;

		}



		public DataTable Op_GetTable()
		{
			string sql = @"	select ROW_NUMBER() over(order by(select 1)) as RowNum,OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
	from OPERATION_MST";

			DataTable dt = new DataTable();
			using (SqlDataAdapter da = new SqlDataAdapter(sql,conn))
			{
				da.Fill(dt);
				return dt;
			}
		}

		//조회조건
		public DataTable GetSearch(INSPECT_OPERATIONProperty pr)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(@"select ROW_NUMBER() over(order by(select 1)) as RowNum,OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
	from OPERATION_MST
     where 1=1");

			using (SqlCommand cmd = new SqlCommand())
			{
				if (!string.IsNullOrWhiteSpace(pr.OPERATION_CODE))
				{
					sb.Append(" and OPERATION_CODE = @OPERATION_CODE");
					cmd.Parameters.AddWithValue("@OPERATION_CODE", pr.OPERATION_CODE);

				}

				if (!string.IsNullOrWhiteSpace(pr.CHECK_DEFECT_FLAG))
				{
					sb.Append(" and CHECK_DEFECT_FLAG = @CHECK_DEFECT_FLAG");
					cmd.Parameters.AddWithValue("@CHECK_DEFECT_FLAG", pr.CHECK_DEFECT_FLAG);
				}

				if (!string.IsNullOrWhiteSpace(pr.CHECK_MATERIAL_FLAG))
				{
					sb.Append(" and CHECK_MATERIAL_FLAG = @CHECK_MATERIAL_FLAG");
					cmd.Parameters.AddWithValue("@CHECK_MATERIAL_FLAG", pr.CHECK_MATERIAL_FLAG);

				}

				if (!string.IsNullOrWhiteSpace(pr.CHECK_INSPECT_FLAG))
				{
					sb.Append(" and CHECK_INSPECT_FLAG = @CHECK_INSPECT_FLAG");
					cmd.Parameters.AddWithValue("@CHECK_INSPECT_FLAG", pr.CHECK_INSPECT_FLAG);
				}



				cmd.CommandText = sb.ToString();
				cmd.Connection = conn;

				DataTable dt = new DataTable();
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
					return dt;
				}
			}
		}
	}
}
