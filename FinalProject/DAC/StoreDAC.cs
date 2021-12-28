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
    public class StoreDAC : IDisposable
    {
        SqlConnection conn;

        public StoreDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }
        public List<StoreVO> GetStoreList()
        {
            string sql = @"select STORE_CODE, STORE_NAME, STORE_TYPE, FIFO_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[STORE_MST]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            return Helper.DataReaderMapToList<StoreVO>(cmd.ExecuteReader());
        }
    

        public bool Insert(StoreVO vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[STORE_MST]
           ([STORE_CODE]
           ,[STORE_NAME]
           ,[STORE_TYPE]
           ,[FIFO_FLAG]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID]

        )
     VALUES
           (@STORE_CODE,
            @STORE_NAME,
            @STORE_TYPE,
            @FIFO_FLAG,
            getdate(),
            @CREATE_USER_ID

    ) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@STORE_CODE", vo.STORE_CODE);
                    cmd.Parameters.AddWithValue("@STORE_NAME", vo.STORE_NAME);
                    cmd.Parameters.AddWithValue("@STORE_TYPE", vo.STORE_TYPE);
                    cmd.Parameters.AddWithValue("@FIFO_FLAG", vo.FIFO_FLAG);
                    cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
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

        public bool Delete(StoreVO sv)
        {
            try
            {
                string sql = @"delete from [dbo].[STORE_MST]
where STORE_CODE = @STORE_CODE ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@STORE_CODE", sv.STORE_CODE);
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

        public bool Update(StoreVO sv)
        {
            try
            {
                string sql = @"update  [dbo].[STORE_MST] set
STORE_NAME= @STORE_NAME, 
STORE_TYPE= @STORE_TYPE, 
FIFO_FLAG= @FIFO_FLAG, 
UPDATE_TIME= getdate(), 
UPDATE_USER_ID= @UPDATE_USER_ID
where STORE_CODE = @STORE_CODE";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@STORE_CODE", sv.STORE_CODE);
                    cmd.Parameters.AddWithValue("@STORE_NAME", sv.STORE_NAME);
                    cmd.Parameters.AddWithValue("@STORE_TYPE", sv.STORE_TYPE);
                    cmd.Parameters.AddWithValue("@FIFO_FLAG", sv.FIFO_FLAG);
                    cmd.Parameters.AddWithValue("@UPDATE_USER_ID", sv.UPDATE_USER_ID);
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

        public void Dispose()
        {
            conn.Close();
        }
    }

}
