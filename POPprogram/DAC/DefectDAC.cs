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
	public class DefectDAC : IDisposable
	{

		SqlConnection conn;
		public DefectDAC()
		{
			//conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();

		}

		public void Dispose()
		{
			conn.Close();
		}


		public List<string> GetDefect_Code()
		{
			string sql = "select KEY_1 FROM [dbo].CODE_DATA_MST WHERE CODE_TABLE_NAME = 'CM_DEFECT'";

			SqlCommand cmd = new SqlCommand(sql, conn);
			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["KEY_1"].ToString());

				}
			}
			return List;
		}
	}
}
