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

		public DataTable GetTable()
		{
			string sql = "select INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID from INSPECT_ITEM_MST ";
			DataTable dt = new DataTable();
			using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
			{
				da.Fill(dt);
				return dt; 
			}
		}

		public bool insert(INSPECT_MSTVO vo)
		{
			try
			{
				if (vo.VALUE_TYPE == "N")
				{
					string sql = @"insert into [dbo].[INSPECT_ITEM_MST] (INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_TIME, CREATE_USER_ID)
values(@INSPECT_ITEM_CODE, @INSPECT_ITEM_NAME, @VALUE_TYPE, @SPEC_LSL, @SPEC_TARGET, @SPEC_USL,getdate(), @CREATE_USER_ID)";

					using (SqlCommand cmd = new SqlCommand(sql, conn))
					{

						cmd.Parameters.AddWithValue("INSPECT_ITEM_CODE", vo.INSPECT_ITEM_CODE);
						cmd.Parameters.AddWithValue("INSPECT_ITEM_NAME", vo.INSPECT_ITEM_NAME);
						cmd.Parameters.AddWithValue("VALUE_TYPE", vo.VALUE_TYPE);
						cmd.Parameters.AddWithValue("SPEC_LSL", vo.SPEC_LSL);
						cmd.Parameters.AddWithValue("SPEC_TARGET", vo.SPEC_TARGET);
						cmd.Parameters.AddWithValue("SPEC_USL", vo.SPEC_USL);
						//cmd.Parameters.AddWithValue("CREATE_TIME", vo.CREATE_TIME);
						cmd.Parameters.AddWithValue("CREATE_USER_ID", vo.CREATE_USER_ID);
						//cmd.Parameters.AddWithValue("UPDATE_TIME", vo.UPDATE_TIME);
						//cmd.Parameters.AddWithValue("UPDATE_USER_ID", vo.UPDATE_USER_ID);



						int row = cmd.ExecuteNonQuery();
						return row > 0;
					}

				}

				else
				{
					string sql = @"insert into [dbo].[INSPECT_ITEM_MST] (INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE,CREATE_TIME, CREATE_USER_ID)
values(@INSPECT_ITEM_CODE, @INSPECT_ITEM_NAME, @VALUE_TYPE,getdate(), @CREATE_USER_ID)";

					using (SqlCommand cmd = new SqlCommand(sql, conn))
					{

						cmd.Parameters.AddWithValue("INSPECT_ITEM_CODE", vo.INSPECT_ITEM_CODE);
						cmd.Parameters.AddWithValue("INSPECT_ITEM_NAME", vo.INSPECT_ITEM_NAME);
						cmd.Parameters.AddWithValue("VALUE_TYPE", vo.VALUE_TYPE);
						//cmd.Parameters.AddWithValue("SPEC_LSL", vo.SPEC_LSL);
						//cmd.Parameters.AddWithValue("SPEC_TARGET", vo.SPEC_TARGET);
						//cmd.Parameters.AddWithValue("SPEC_USL", vo.SPEC_USL);
						//cmd.Parameters.AddWithValue("CREATE_TIME", vo.CREATE_TIME);
						cmd.Parameters.AddWithValue("CREATE_USER_ID", vo.CREATE_USER_ID);
						//cmd.Parameters.AddWithValue("UPDATE_TIME", vo.UPDATE_TIME);
						//cmd.Parameters.AddWithValue("UPDATE_USER_ID", vo.UPDATE_USER_ID);



						int row = cmd.ExecuteNonQuery();
						return row > 0;
					}
				}
			}
			catch (Exception err)
			{
				Debug.WriteLine(err.Message);
				return false;
			}
		}

		public bool Delete(INSPECT_MSTVO vo)
		{
			string sql = @"delete from INSPECT_ITEM_MST
where INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", vo.INSPECT_ITEM_CODE);
				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		public bool Update(INSPECT_MSTVO vo)
		{
			string sql = @"Update [dbo].[INSPECT_ITEM_MST]
set INSPECT_ITEM_CODE =@INSPECT_ITEM_CODE, INSPECT_ITEM_NAME = @INSPECT_ITEM_NAME, VALUE_TYPE = @VALUE_TYPE, SPEC_LSL = @SPEC_LSL, SPEC_TARGET = @SPEC_TARGET, SPEC_USL=@SPEC_USL, CREATE_TIME=@CREATE_TIME, CREATE_USER_ID = @CREATE_USER_ID, 
UPDATE_TIME =@UPDATE_TIME, UPDATE_USER_ID = @UPDATE_USER_ID
where  INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE ";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", vo.INSPECT_ITEM_CODE);
				cmd.Parameters.AddWithValue("@INSPECT_ITEM_NAME", vo.INSPECT_ITEM_NAME);
				cmd.Parameters.AddWithValue("@VALUE_TYPE", vo.VALUE_TYPE);
				cmd.Parameters.AddWithValue("@SPEC_LSL", vo.SPEC_LSL);
				cmd.Parameters.AddWithValue("@SPEC_TARGET", vo.SPEC_TARGET);
				cmd.Parameters.AddWithValue("@SPEC_USL", vo.SPEC_USL);
				cmd.Parameters.AddWithValue("@CREATE_TIME", vo.CREATE_TIME);
				cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
				cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
				cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		//조회조건
		public List<INSPECT_MSTVO> GetINSPECT_MST_Search(INSPECT_MSTVO vo)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(@"SELECT INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
FROM INSPECT_ITEM_MST
where 1=1");

			using (SqlCommand cmd = new SqlCommand())
			{
				if (!string.IsNullOrWhiteSpace(vo.INSPECT_ITEM_CODE))
				{
					sb.Append(" and INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE");
					cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", vo.INSPECT_ITEM_CODE);

				}

				if (!string.IsNullOrWhiteSpace(vo.VALUE_TYPE))
				{
					sb.Append(" and VALUE_TYPE = @VALUE_TYPE");
					cmd.Parameters.AddWithValue("@VALUE_TYPE", vo.VALUE_TYPE);

				}


				cmd.CommandText = sb.ToString();
				cmd.Connection = conn;

				return Helper.DataReaderMapToList<INSPECT_MSTVO>(cmd.ExecuteReader());
			}

		}
		public DataTable GetSearchTable(INSPECT_MSTVO vo)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(@"select INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[INSPECT_ITEM_MST]
where 1=1");

			if (!string.IsNullOrWhiteSpace(vo.INSPECT_ITEM_CODE))
			{
				sb.Append(" and INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE");
			}

			if (!string.IsNullOrWhiteSpace(vo.VALUE_TYPE))
			{
				sb.Append(" and VALUE_TYPE = @VALUE_TYPE");
			}


			using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
			{
				cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE",vo.INSPECT_ITEM_CODE );
				cmd.Parameters.AddWithValue("@VALUE_TYPE", vo.VALUE_TYPE);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				return dt;
				//return Helper.DataReaderMapToList<Search_INSPEC_MSEVO>(cmd.ExecuteReader());
			}

		}
	}
}
