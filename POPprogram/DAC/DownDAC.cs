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
	public class DownDAC : IDisposable
	{

		SqlConnection conn;
		public DownDAC()
		{
			//conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();

		}

		public void Dispose()
		{
			conn.Close();
		}


		public List<DownProperty> GetDownList()
		{
			string sql = @"select DT_DATE, substring(convert(varchar(10), DT_START_TIME, 108), 1, 5) DT_START_TIME, substring(convert(varchar(10), DT_END_TIME, 108), 1, 5) DT_END_TIME, DT_TIME, DT_CODE, DT_COMMENT, DT_USER_ID, ACTION_COMMENT, CONFIRM_TIME, CONFIRM_USER_ID
from [dbo].[EQUIP_DOWN_HIS]";
			SqlCommand cmd = new SqlCommand(sql, conn);
			return Helper.DataReaderMapToList<DownProperty>(cmd.ExecuteReader());
		}

		public List<string> GetDown_Code()
		{
			string sql = "select KEY_1 FROM [dbo].CODE_DATA_MST WHERE CODE_TABLE_NAME = 'CM_DOWN'";

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

		public bool Insert(DateTime DT_DATE, DateTime DT_START_TIME, DateTime DT_END_TIME, int DT_TIME, string DT_CODE, string DT_COMMENT, string DT_USER_ID, string ACTION_COMMENT)
        {
            try
            {
                string sql = @"INSERT INTO EQUIP_DOWN_HIS (DT_DATE, DT_START_TIME, DT_END_TIME, DT_TIME, DT_CODE, DT_COMMENT, DT_USER_ID, ACTION_COMMENT)
     VALUES
           (@DT_DATE, @DT_START_TIME, @DT_END_TIME, @DT_TIME, @DT_CODE, @DT_COMMENT, @DT_USER_ID, @ACTION_COMMENT) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DT_DATE", DT_DATE);
                    cmd.Parameters.AddWithValue("@DT_START_TIME", DT_START_TIME);
                    cmd.Parameters.AddWithValue("@DT_END_TIME", DT_END_TIME);
                    cmd.Parameters.AddWithValue("@DT_TIME", DT_TIME);
                    cmd.Parameters.AddWithValue("@DT_CODE", DT_CODE);
                    cmd.Parameters.AddWithValue("@DT_COMMENT", DT_COMMENT);
                    cmd.Parameters.AddWithValue("@DT_USER_ID", DT_USER_ID);
                    cmd.Parameters.AddWithValue("@ACTION_COMMENT", ACTION_COMMENT);
                    //cmd.Parameters.AddWithValue("@CONFIRM_TIME", CONFIRM_TIME);
                    //cmd.Parameters.AddWithValue("@CONFIRM_USER_ID", CONFIRM_USER_ID);
                    int row = cmd.ExecuteNonQuery();
                    return row > 0;

                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}
