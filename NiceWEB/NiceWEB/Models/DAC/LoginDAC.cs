using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
namespace NiceWEB.Models.DAC
{
	public class LoginDAC
	{
		SqlConnection conn;
		public LoginDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}
		public bool CheckLogin(string email, string password)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = @"SELECT count(USER_ID) COUNT
  FROM [USER_MST]
  WHERE [USER_GROUP_CODE]='ADMIN_GROUP' AND USER_ID=@USER_ID AND USER_PASSWORD=@USER_PASSWORD";


				cmd.Parameters.AddWithValue("@USER_ID", email);
				cmd.Parameters.AddWithValue("@USER_PASSWORD", password);

				SqlDataReader reader = cmd.ExecuteReader();
				// 다음 레코드 계속 가져와서 루핑
				if (reader.Read())
				{
					string s = reader["COUNT"].ToString();
					reader.Close();
					return s == "1";
				}

				else
					reader.Close();
					return false;
			}
		}
		public List<ComboItem> getName(string email)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = @"SELECT 
      [USER_NAME] as Code
  FROM [team3].[dbo].[USER_MST]
  WHERE USER_ID=@USER_ID";

				cmd.Parameters.AddWithValue("@USER_ID", email);
				SqlDataReader reader = cmd.ExecuteReader();
				List<ComboItem> list = Helper.DataReaderMapToList<ComboItem>(reader);
				reader.Close();

				return list;

			}
		}
	}
}