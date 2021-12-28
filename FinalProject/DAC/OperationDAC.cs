
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
    public class OperationDAC : IDisposable
    {
        SqlConnection conn;

        public OperationDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public DataTable GetOperationList()
        {
            string sql = @"select OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[OPERATION_MST]"; 
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(OperationProperty vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[OPERATION_MST]
           ([OPERATION_CODE]
           ,[OPERATION_NAME]
           ,[CHECK_DEFECT_FLAG]
           ,[CHECK_INSPECT_FLAG]
           ,[CHECK_MATERIAL_FLAG]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID]
        )
     VALUES
           (@OPERATION_CODE,
            @OPERATION_NAME,
            @CHECK_DEFECT_FLAG,
            @CHECK_INSPECT_FLAG,
            @CHECK_MATERIAL_FLAG,
            getdate(),
            @CREATE_USER_ID
    ) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", vo.OPERATION_CODE);
                    if (vo.OPERATION_NAME == null)
                        cmd.Parameters.AddWithValue("@OPERATION_NAME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OPERATION_NAME", vo.OPERATION_NAME);
                    if (vo.CHECK_DEFECT_FLAG == null)
                        cmd.Parameters.AddWithValue("@CHECK_DEFECT_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CHECK_DEFECT_FLAG", vo.CHECK_DEFECT_FLAG);
                    if (vo.CHECK_INSPECT_FLAG == null)
                        cmd.Parameters.AddWithValue("@CHECK_INSPECT_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CHECK_INSPECT_FLAG", vo.CHECK_INSPECT_FLAG);
                    if (vo.CHECK_MATERIAL_FLAG == null)
                        cmd.Parameters.AddWithValue("@CHECK_MATERIAL_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CHECK_MATERIAL_FLAG", vo.CHECK_MATERIAL_FLAG);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
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

        public bool Delete(OperationProperty pt)
        {
            try
            {
                string sql = @"delete from [dbo].[OPERATION_MST]
where OPERATION_CODE = @OPERATION_CODE ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", pt.OPERATION_CODE);
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

        public bool Update(OperationProperty vo)
        {
            try
            {
                string sql = @"update  [dbo].[OPERATION_MST] set
OPERATION_NAME= @OPERATION_NAME, 
CHECK_DEFECT_FLAG= @CHECK_DEFECT_FLAG, 
CHECK_INSPECT_FLAG= @CHECK_INSPECT_FLAG,
CHECK_MATERIAL_FLAG= @CHECK_MATERIAL_FLAG,  
UPDATE_TIME= getdate(), 
UPDATE_USER_ID= @UPDATE_USER_ID
where OPERATION_CODE = @OPERATION_CODE";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) 
                {
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", vo.OPERATION_CODE);
                    if (vo.OPERATION_NAME == null)
                        cmd.Parameters.AddWithValue("@OPERATION_NAME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OPERATION_NAME", vo.OPERATION_NAME);
                    if (vo.CHECK_DEFECT_FLAG == null)
                        cmd.Parameters.AddWithValue("@CHECK_DEFECT_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CHECK_DEFECT_FLAG", vo.CHECK_DEFECT_FLAG);
                    if (vo.CHECK_INSPECT_FLAG == null)
                        cmd.Parameters.AddWithValue("@CHECK_INSPECT_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CHECK_INSPECT_FLAG", vo.CHECK_INSPECT_FLAG);
                    if (vo.CHECK_MATERIAL_FLAG == null)
                        cmd.Parameters.AddWithValue("@CHECK_MATERIAL_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CHECK_MATERIAL_FLAG", vo.CHECK_MATERIAL_FLAG);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.UPDATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@UPDATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
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

        public List<OperationProperty> GetOperationSearch(OperationProperty pr)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"select OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[OPERATION_MST]
where 1=1");


            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(pr.OPERATION_CODE))
                {
                    sb.Append(" and OPERATION_CODE = @OPERATION_CODE");
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", pr.OPERATION_CODE);
                }
                if (!string.IsNullOrWhiteSpace(pr.OPERATION_NAME))
                {
                    sb.Append(" and OPERATION_NAME=@OPERATION_NAME");
                    cmd.Parameters.AddWithValue("@OPERATION_NAME", pr.OPERATION_NAME);
                }
                if (!string.IsNullOrWhiteSpace(pr.CHECK_DEFECT_FLAG))
                {
                    sb.Append(" and CHECK_DEFECT_FLAG=@CHECK_DEFECT_FLAG");
                    cmd.Parameters.AddWithValue("@CHECK_DEFECT_FLAG", pr.CHECK_DEFECT_FLAG);
                }
                if (!string.IsNullOrWhiteSpace(pr.CHECK_INSPECT_FLAG))
                {
                    sb.Append(" and CHECK_INSPECT_FLAG=@CHECK_INSPECT_FLAG");
                    cmd.Parameters.AddWithValue("@CHECK_INSPECT_FLAG", pr.CHECK_INSPECT_FLAG);
                }
                if (!string.IsNullOrWhiteSpace(pr.CHECK_MATERIAL_FLAG))
                {
                    sb.Append(" and CHECK_MATERIAL_FLAG=@CHECK_MATERIAL_FLAG");
                    cmd.Parameters.AddWithValue("@CHECK_MATERIAL_FLAG", pr.CHECK_MATERIAL_FLAG);
                }
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;
              

                return Helper.DataReaderMapToList<OperationProperty>(cmd.ExecuteReader());
            }

        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
