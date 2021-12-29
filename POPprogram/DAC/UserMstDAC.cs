using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
namespace DAC
{
	public class UserMstDAC
	{
		SqlConnection conn;
		public UserMstDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}

		public void Dispose()
		{
			conn.Dispose();
		}
		public bool Insert(User_MST_Property pr)
		{
			try
			{
				string sql = @"insert into USER_MST(USER_ID, USER_NAME, USER_GROUP_CODE, USER_PASSWORD,USER_DEPARTMENT,CREATE_TIME, CREATE_USER_ID)
values (@USER_ID, @USER_NAME, @USER_GROUP_CODE, @USER_PASSWORD,@USER_DEPARTMENT,getdate(),@CREATE_USER_ID)";


				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@USER_ID", pr.USER_ID);
					cmd.Parameters.AddWithValue("@USER_NAME", pr.USER_NAME);
					cmd.Parameters.AddWithValue("@USER_GROUP_CODE", pr.USER_GROUP_CODE);
					cmd.Parameters.AddWithValue("@USER_PASSWORD", pr.USER_PASSWORD);
					cmd.Parameters.AddWithValue("@USER_DEPARTMENT", pr.USER_DEPARTMENT);
					cmd.Parameters.AddWithValue("@CREATE_USER_ID", pr.CREATE_USER_ID);
					//cmd.Parameters.AddWithValue("@UPDATE_TIME", pr.UPDATE_TIME);
					//cmd.Parameters.AddWithValue("@UPDATE_USER_ID", pr.UPDATE_USER_ID);

					int row = cmd.ExecuteNonQuery();
					return row > 0;
				}
			}
			catch (Exception err)
			{
				Debug.WriteLine(err.Message); //log에 찍게 해야하나?
				return false;
			}
		}

		public bool Update(User_MST_Property pr)
		{
			string sql = @"update USER_MST 
set USER_ID = @USER_ID, USER_NAME = @USER_NAME , USER_GROUP_CODE = @USER_GROUP_CODE, USER_PASSWORD = @USER_PASSWORD, USER_DEPARTMENT = @USER_DEPARTMENT,
 UPDATE_TIME = getdate() ,UPDATE_USER_ID = @UPDATE_USER_ID
where USER_ID = @USER_ID";
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@USER_ID", pr.USER_ID);
				cmd.Parameters.AddWithValue("@USER_NAME", pr.USER_NAME);
				cmd.Parameters.AddWithValue("@USER_GROUP_CODE", pr.USER_GROUP_CODE);
				cmd.Parameters.AddWithValue("@USER_PASSWORD", pr.USER_PASSWORD);
				cmd.Parameters.AddWithValue("@USER_DEPARTMENT", pr.USER_DEPARTMENT);

				//cmd.Parameters.AddWithValue("@CREATE_TIME", pr.CREATE_TIME);
				//cmd.Parameters.AddWithValue("@CREATE_USER_ID", pr.CREATE_USER_ID);
				//cmd.Parameters.AddWithValue("@UPDATE_TIME", pr.UPDATE_TIME);
				cmd.Parameters.AddWithValue("@UPDATE_USER_ID", pr.UPDATE_USER_ID);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		public bool Delete(string Code)
		{
			string sql = "delete from USER_MST where USER_ID = @USER_ID";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@USER_ID", Code);

				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
		}

		public DataTable GetTable()
		{
			string sql = @"select  USER_ID, USER_NAME, USER_GROUP_CODE, USER_PASSWORD, USER_DEPARTMENT, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID from USER_MST";
			DataTable dt = new DataTable();

			using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
			{
				da.Fill(dt);
				return dt;
			}
		}

		//조회조건
		public List<User_MST_Property> GetSearch(User_MST_Property pr)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(@"select USER_ID, USER_NAME, USER_GROUP_CODE, USER_PASSWORD, USER_DEPARTMENT, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from USER_MST
where 1=1");

			using (SqlCommand cmd = new SqlCommand())
			{
				if (!string.IsNullOrWhiteSpace(pr.USER_ID))
				{
					sb.Append(" and USER_ID = @USER_ID");
					cmd.Parameters.AddWithValue("@USER_ID", pr.USER_ID);

				}

				if (!string.IsNullOrWhiteSpace(pr.USER_GROUP_CODE))
				{
					sb.Append(" and USER_GROUP_CODE = @USER_GROUP_CODE");
					cmd.Parameters.AddWithValue("@USER_GROUP_CODE", pr.USER_GROUP_CODE);

				}
				if (!string.IsNullOrWhiteSpace(pr.USER_DEPARTMENT))
				{
					sb.Append(" and USER_DEPARTMENT = @USER_DEPARTMENT");
					cmd.Parameters.AddWithValue("@USER_DEPARTMENT", pr.USER_DEPARTMENT);
				}
				cmd.CommandText = sb.ToString();
				cmd.Connection = conn;

				return Helper.DataReaderMapToList<User_MST_Property>(cmd.ExecuteReader());
			}
			
		}

		//공통코드 조회하기(부서)
		public List<string> GetCode()
		{
			string sql = @"SELECT [KEY_1] as 'PRODUCT_TYPE'
FROM [dbo].[CODE_DATA_MST]
WHERE [CODE_TABLE_NAME] ='CM_DEPARTMENT'";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> productType = new List<string>();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					productType.Add(reader["PRODUCT_TYPE"].ToString());

				}
			}
			return productType;
		}

		//사용자 그룹 아이디 가지고오기
		public List<string> GetGroupCode()
		{
			string sql = @"SELECT USER_GROUP_CODE FROM USER_GROUP_MST";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> list = new List<string>();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{

				while (reader.Read())
				{
					list.Add(reader["USER_GROUP_CODE"].ToString());

				}
			}
			return list;
		}
	}
}

