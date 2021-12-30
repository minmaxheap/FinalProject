using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAC
{
	public class UserGroupDAC:IDisposable
	{
		SqlConnection conn;

		public UserGroupDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}

		public void Dispose()
		{
			conn.Dispose();
		}

		public bool Insert(UserGroupVO vo)
		{
			try
			{
				string sql = @"insert into  [dbo].[USER_GROUP_MST] (USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID)
values(@USER_GROUP_CODE, @USER_GROUP_NAME, @USER_GROUP_TYPE,getdate(), @CREATE_USER_ID)";

				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@USER_GROUP_CODE", vo.USER_GROUP_CODE);
					cmd.Parameters.AddWithValue("@USER_GROUP_NAME", vo.USER_GROUP_NAME);
					cmd.Parameters.AddWithValue("@USER_GROUP_TYPE", vo.USER_GROUP_TYPE);
					
					//cmd.Parameters.AddWithValue("@CREATE_TIME", vo.CREATE_TIME);
					cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
					//cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
					//cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);

					int row = cmd.ExecuteNonQuery();
					return row > 0;


				}

			}
			catch (Exception err)
			{
				return false;
			}
		}

		public bool Delete(string Code)
		{
			string sql = "delete from [dbo].[USER_GROUP_MST] where USER_GROUP_CODE = @USER_GROUP_CODE";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@USER_GROUP_CODE", Code);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		public bool Update(UserGroupVO vo)
		{
			string sql = @"update [dbo].[USER_GROUP_MST]
set USER_GROUP_CODE = @USER_GROUP_CODE, USER_GROUP_NAME = @USER_GROUP_NAME, USER_GROUP_TYPE = @USER_GROUP_TYPE,UPDATE_TIME = getdate(), UPDATE_USER_ID = @UPDATE_USER_ID
where USER_GROUP_CODE = @USER_GROUP_CODE";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@USER_GROUP_CODE", vo.USER_GROUP_CODE);
				cmd.Parameters.AddWithValue("@USER_GROUP_NAME", vo.USER_GROUP_NAME);
				cmd.Parameters.AddWithValue("@USER_GROUP_TYPE", vo.USER_GROUP_TYPE);

				//cmd.Parameters.AddWithValue("@CREATE_TIME", vo.CREATE_TIME);
				//cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
				//cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
				cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		public DataTable GetTable()
		{
			string sql = "select USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID from USER_GROUP_MST";
			DataTable dt = new DataTable();

			using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
			{
				da.Fill(dt);
				return dt;
			}
		}

		//해야할것(조회조건)

		//public List<UserGroupVO> GetSearch(UserGroupVO vo)
		//{

		//}

		public List<UserGroupVO> GetSearch(UserGroupVO vo)
		{
			//StringBuilder sb = new StringBuilder();

			StringBuilder sb = new StringBuilder();

			sb.Append(@"SELECT USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
FROM USER_GROUP_MST
WHERE 1=1");

			using (SqlCommand cmd = new SqlCommand())
			{
				if (!string.IsNullOrWhiteSpace(vo.USER_GROUP_CODE))
				{
					sb.Append(" and USER_GROUP_CODE = @USER_GROUP_CODE");
					cmd.Parameters.AddWithValue("@USER_GROUP_CODE", vo.USER_GROUP_CODE);

				}

				if (!string.IsNullOrWhiteSpace(vo.USER_GROUP_TYPE))
				{
					sb.Append(" and USER_GROUP_TYPE = @USER_GROUP_TYPE");
					cmd.Parameters.AddWithValue("@USER_GROUP_TYPE", vo.USER_GROUP_TYPE);

				}


				cmd.CommandText = sb.ToString();
				cmd.Connection = conn;

				return Helper.DataReaderMapToList<UserGroupVO>(cmd.ExecuteReader());
			}
		}

		//공통코드로 조회하기 => 사용자 그룹유형
		public List<string> GetCode()
		{
			string sql = @"SELECT [KEY_1] as 'PRODUCT_TYPE'
FROM [dbo].[CODE_DATA_MST]
WHERE [CODE_TABLE_NAME] ='CM_Group_Code'";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> list = new List<string>();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					list.Add(reader["PRODUCT_TYPE"].ToString());

				}
			}
			return list;
		}
	}
}
