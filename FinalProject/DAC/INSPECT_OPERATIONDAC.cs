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

		//값 유형에 따라 전체 할당조건 보여주기
		public DataTable GetAll(string Value)
		{
			try
			{
				string sql = @"select ROW_NUMBER() over(order by(select 1)) as RowNum,[INSPECT_ITEM_CODE],[INSPECT_ITEM_NAME]
from [dbo].[INSPECT_ITEM_MST]
where VALUE_TYPE = @VALUE_TYPE";

				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@VALUE_TYPE", Value);
				//SqlDataReader reader = cmd.ExecuteReader();

				DataTable dt = new DataTable();

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				return dt;

				//return Helper.DataReaderMapToList<INSPECT_MSTVO>(cmd.ExecuteReader());

			}
			catch (Exception err)
			{
				Debug.WriteLine(err.Message);
				return null;
			}
		}

		//검사 공정관계 table 등록
		public bool Op_Insert(string op_code, string inspect_code,string createID,string updateID)
		{
			string sql = @"insert into [dbo].[INSPECT_ITEM_OPERATION_REL](OPERATION_CODE, INSPECT_ITEM_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID)
		values (@OPERATION_CODE, @INSPECT_ITEM_CODE, getdate(), @CREATE_USER_ID, getdate(), @UPDATE_USER_ID)";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", inspect_code);
				//cmd.Parameters.AddWithValue("@CREATE_TIME", createtime);
				cmd.Parameters.AddWithValue("@CREATE_USER_ID", createID);
				//cmd.Parameters.AddWithValue("@UPDATE_TIME", updateTime);
				cmd.Parameters.AddWithValue("@UPDATE_USER_ID", updateID);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}


		//검사 공정관계 데이터 삭제
		public bool Op_Delete(string op_code,string inspect_code)
		{
			string sql = "delete from  [dbo].[INSPECT_ITEM_OPERATION_REL] where OPERATION_CODE = @OPERATION_CODE and INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE";

		using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@OPERATION_CODE",op_code);
				cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", inspect_code);
				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		//할당 관계 grid보여주기
		public DataTable GetOp_Table(string code)
		{
			string sql = @"select  ROW_NUMBER() over(order by(select 1)) as RowNum, OPERATION_CODE, i.INSPECT_ITEM_CODE , i.INSPECT_ITEM_NAME
	from INSPECT_ITEM_OPERATION_REL ir left join INSPECT_ITEM_MST i on ir.INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE
	where OPERATION_CODE =@OPERATION_CODE";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				DataTable dt = new DataTable();
				cmd.Parameters.AddWithValue("@OPERATION_CODE", code);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				return dt;
			}
		}
	}
}
