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
    public class LoginDAC : IDisposable
    {
        SqlConnection conn;
        public LoginDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }
        public bool CheckLogin(LoginProperty vo)
        {

            string sql = @"
SELECT count(USER_ID) COUNT
  FROM [USER_MST]
  WHERE USER_ID=@USER_ID AND USER_PASSWORD=@USER_PASSWORD
";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@USER_ID", vo.USER_ID);
                cmd.Parameters.AddWithValue("@USER_PASSWORD", vo.USER_PASSWORD);

                // SqlDataReader 객체를 리턴
                SqlDataReader rdr = cmd.ExecuteReader();

                // 다음 레코드 계속 가져와서 루핑
                if (rdr.Read())
                {
                    string s = rdr["COUNT"].ToString();
                    return s == "1";
                }
                else
                    return false;
            }

        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}

