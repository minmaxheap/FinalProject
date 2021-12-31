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
    public class BomDAC : IDisposable
    {
        SqlConnection conn;

        public BomDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public List<BomVO> GetBOMList()
        {
            string sql = @"select [dbo].[BOM_MST].PRODUCT_CODE,[dbo].[BOM_MST].CHILD_PRODUCT_CODE, [dbo].[BOM_MST].REQUIRE_QTY, [dbo].[BOM_MST].ALTER_PRODUCT_CODE, [dbo].[BOM_MST].CREATE_TIME, [dbo].[BOM_MST].CREATE_USER_ID, [dbo].[BOM_MST].UPDATE_TIME, [dbo].[BOM_MST].UPDATE_USER_ID
from [dbo].[BOM_MST]
INNER JOIN [dbo].[PRODUCT_MST] ON([dbo].[BOM_MST].PRODUCT_CODE = [dbo].[PRODUCT_MST].PRODUCT_CODE)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            return Helper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
        }

        public DataTable GetBOMList1()
        {
            string sql = @"select [dbo].[BOM_MST].PRODUCT_CODE,[dbo].[BOM_MST].CHILD_PRODUCT_CODE, [dbo].[BOM_MST].REQUIRE_QTY, [dbo].[BOM_MST].ALTER_PRODUCT_CODE, [dbo].[BOM_MST].CREATE_TIME, [dbo].[BOM_MST].CREATE_USER_ID, [dbo].[BOM_MST].UPDATE_TIME, [dbo].[BOM_MST].UPDATE_USER_ID
from [dbo].[BOM_MST]
INNER JOIN [dbo].[PRODUCT_MST] ON([dbo].[BOM_MST].PRODUCT_CODE = [dbo].[PRODUCT_MST].PRODUCT_CODE)";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(BomVO vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[BOM_MST]
           ([PRODUCT_CODE]
           ,[CHILD_PRODUCT_CODE]
           ,[REQUIRE_QTY]
           ,[ALTER_PRODUCT_CODE]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID]

        )
     VALUES
           (@PRODUCT_CODE,
            @CHILD_PRODUCT_CODE,
            @REQUIRE_QTY,
            @ALTER_PRODUCT_CODE,
            getdate(),
            @CREATE_USER_ID

    ) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", vo.CHILD_PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@REQUIRE_QTY", vo.REQUIRE_QTY);
                    //cmd.Parameters.AddWithValue("@ALTER_PRODUCT_CODE", vo.ALTER_PRODUCT_CODE);
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


        public bool Delete(BomVO bv)
        {
            try
            {
                string sql = @"delete from [dbo].[BOM_MST]
where CHILD_PRODUCT_CODE = @CHILD_PRODUCT_CODE ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", bv.CHILD_PRODUCT_CODE);
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


        public bool Update(BomVO bv)
        {
            try
            {
                string sql = @"update  [dbo].[BOM_MST] set
REQUIRE_QTY= @REQUIRE_QTY, 
ALTER_PRODUCT_CODE= @ALTER_PRODUCT_CODE, 
UPDATE_TIME= getdate(), 
UPDATE_USER_ID= @UPDATE_USER_ID
where CHILD_PRODUCT_CODE = @CHILD_PRODUCT_CODE";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //cmd.Parameters.AddWithValue("@STORE_CODE", sv.STORE_CODE);
                    //cmd.Parameters.AddWithValue("@STORE_NAME", sv.STORE_NAME);
                    //cmd.Parameters.AddWithValue("@STORE_TYPE", sv.STORE_TYPE);
                    //cmd.Parameters.AddWithValue("@FIFO_FLAG", sv.FIFO_FLAG);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", sv.UPDATE_USER_ID);
                    //int row = cmd.ExecuteNonQuery();
                    //return row > 0;


                    cmd.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", bv.CHILD_PRODUCT_CODE);
                    if (bv.REQUIRE_QTY == null)
                        cmd.Parameters.AddWithValue("@REQUIRE_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@REQUIRE_QTY", bv.REQUIRE_QTY);
                    //if (bv.ALTER_PRODUCT_CODE == null)
                    //    cmd.Parameters.AddWithValue("@ALTER_PRODUCT_CODE", DBNull.Value);
                    //else cmd.Parameters.AddWithValue("@ALTER_PRODUCT_CODE", bv.ALTER_PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@UPDATE_USER_ID", bv.UPDATE_USER_ID);
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
