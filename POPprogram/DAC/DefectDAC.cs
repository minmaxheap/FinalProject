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

		public bool insert(decimal qty,string comment,string userid,string lotID,DataTable dt)
		{
			try
			{
				//SqlTransaction trans = conn.BeginTransaction();
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "[dbo].[DeffectList]";
					cmd.Connection = conn;

					cmd.Parameters.AddWithValue("@LOT_QTY", qty);
					cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT",comment);
					cmd.Parameters.AddWithValue("@LOT_ID", lotID);
					cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID",userid);

					cmd.Parameters.AddWithValue("@dtCnt", dt.Rows.Count);

					cmd.Parameters.Add(new SqlParameter("@ItemList", SqlDbType.Structured)
					{
						TypeName = "dbo.MyList5",
						Value = dt
					});

					int row = cmd.ExecuteNonQuery();
					return row > 0;
				}
			}
			catch (SqlException err)  // 에러 : Severity=11+ 인 경우
			{
				Debug.WriteLine(err.Message);
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
