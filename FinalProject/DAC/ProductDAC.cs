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
    public class ProductDAC : IDisposable
    {
        SqlConnection conn;

        public ProductDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public List<ProductProperty> GetProductsList()
        {
            string sql = @"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[PRODUCT_MST]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            return Helper.DataReaderMapToList<ProductProperty>(cmd.ExecuteReader());
        }

        public bool Insert(ProductProperty pt)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[PRODUCT_MST]
           ([PRODUCT_CODE]
           ,[PRODUCT_NAME]
           ,[PRODUCT_TYPE]
           ,[CUSTOMER_CODE]
           ,[VENDOR_CODE]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID]
        )
     VALUES
           (@PRODUCT_CODE,
            @PRODUCT_NAME,
            @PRODUCT_TYPE,
            @CUSTOMER_CODE,
            @VENDOR_CODE,
            getdate(),
            @CREATE_USER_ID
    ) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", pt.PRODUCT_CODE);
                    if (pt.PRODUCT_NAME == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_NAME", DBNull.Value);
                    else
                     cmd.Parameters.AddWithValue("@PRODUCT_NAME", pt.PRODUCT_NAME); 
                    if (pt.PRODUCT_TYPE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_TYPE", DBNull.Value);
                    else  cmd.Parameters.AddWithValue("@PRODUCT_TYPE", pt.PRODUCT_TYPE); 
                    if (pt.CUSTOMER_CODE == null)
                     cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value); 
                   else  cmd.Parameters.AddWithValue("@CUSTOMER_CODE", pt.CUSTOMER_CODE); 
                    if (pt.VENDOR_CODE == null)
                        cmd.Parameters.AddWithValue("@VENDOR_CODE", DBNull.Value);
                    else { cmd.Parameters.AddWithValue("@VENDOR_CODE", pt.VENDOR_CODE); }
                    cmd.Parameters.AddWithValue("@CREATE_USER_ID", pt.CREATE_USER_ID);
 
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

      

        public bool Delete(ProductProperty pt)
        {
            try
            {
                string sql = @"delete from [dbo].[PRODUCT_MST]
where PRODUCT_CODE = @PRODUCT_CODE ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", pt.PRODUCT_CODE);
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

        public bool Update(ProductProperty pt)
        {
            try
            {
                string sql = @"update  [dbo].[PRODUCT_MST] set
PRODUCT_NAME= @PRODUCT_NAME, 
PRODUCT_TYPE= @PRODUCT_TYPE, 
CUSTOMER_CODE= @CUSTOMER_CODE,
VENDOR_CODE= @VENDOR_CODE,  
UPDATE_TIME= getdate(), 
UPDATE_USER_ID= @UPDATE_USER_ID
where PRODUCT_CODE = @PRODUCT_CODE";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) 
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", pt.PRODUCT_CODE);
                    if (pt.PRODUCT_NAME == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_NAME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_NAME", pt.PRODUCT_NAME);
                    if (pt.PRODUCT_TYPE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_TYPE", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@PRODUCT_TYPE", pt.PRODUCT_TYPE);
                    if (pt.CUSTOMER_CODE == null)
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@CUSTOMER_CODE", pt.CUSTOMER_CODE);
                    if (pt.VENDOR_CODE == null)
                        cmd.Parameters.AddWithValue("@VENDOR_CODE", DBNull.Value);
                    else { cmd.Parameters.AddWithValue("@VENDOR_CODE", pt.VENDOR_CODE); }
                    cmd.Parameters.AddWithValue("@UPDATE_USER_ID",pt.UPDATE_USER_ID);
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

        public List<string> GetProductType()
        {
            string sql = @"SELECT [KEY_1] as 'PRODUCT_TYPE'
        FROM [dbo].[CODE_DATA_MST]
        WHERE [CODE_TABLE_NAME] ='CM_PRODUCT_TYPE'";
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

        //        public List<string> GetProductType()
        //        {
        //            string sql = @"SELECT concat([KEY_1],'(',[DATA_1],')') as 'PRODUCT_TYPE'
        //FROM [dbo].[CODE_DATA_MST]
        //WHERE [CODE_TABLE_NAME] ='CM_PRODUCT_TYPE'";
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            List<string> productType = new List<string>();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {

        //                while (reader.Read())
        //                {
        //                    productType.Add(reader["PRODUCT_TYPE"].ToString());

        //                }
        //            }

        //            return productType;
        //        }
        public List<string> GetCustomerCode()
        {
            string sql = @"SELECT [KEY_1]  as 'CUSTOMER_CODE'
FROM [dbo].[CODE_DATA_MST]
WHERE [CODE_TABLE_NAME] ='CM_CUSTOMER'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["CUSTOMER_CODE"].ToString());

                }
            }

            return productType;
        }

        public List<string> GetVendorCode()
        {
            string sql = @"SELECT [KEY_1]  as 'VENDOR_CODE'
FROM [dbo].[CODE_DATA_MST]
WHERE [CODE_TABLE_NAME] ='CM_VENDOR'
";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productType = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productType.Add(reader["VENDOR_CODE"].ToString());

                }
            }

            return productType;
        }

        public List<ProductProperty> GetProductSearch(ProductProperty pr)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[PRODUCT_MST]
where 1=1");


            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(pr.PRODUCT_CODE))
                {
                    sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE");

                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", pr.PRODUCT_CODE);
                }
                if (!string.IsNullOrWhiteSpace(pr.PRODUCT_TYPE))
            {
                sb.Append(" and PRODUCT_TYPE=@PRODUCT_TYPE");
                cmd.Parameters.AddWithValue("@PRODUCT_TYPE", pr.PRODUCT_TYPE);
            }
            if (!string.IsNullOrWhiteSpace(pr.CUSTOMER_CODE))
            {
                sb.Append(" and CUSTOMER_CODE=@CUSTOMER_CODE");
                cmd.Parameters.AddWithValue("@CUSTOMER_CODE", pr.CUSTOMER_CODE);
            }
            if (!string.IsNullOrWhiteSpace(pr.VENDOR_CODE))
            {
                sb.Append(" and VENDOR_CODE=@VENDOR_CODE");
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", pr.VENDOR_CODE);
                }



                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;
              

                return Helper.DataReaderMapToList<ProductProperty>(cmd.ExecuteReader());
            }

        }

        //operation 부분
                public DataTable GetOperRelation(string prodCode)
        {
            string sql = @"select FLOW_SEQ,r.OPERATION_CODE, m.OPERATION_NAME
        from [dbo].[PRODUCT_OPERATION_REL] r
        inner join OPERATION_MST m on m.OPERATION_CODE = r.OPERATION_CODE
        where PRODUCT_CODE = @PRODUCT_CODE
        order by FLOW_SEQ";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@PRODUCT_CODE", prodCode);
                da.Fill(dt);
                return dt;
            }
        }

//        public List<int,string,string> GetOperRelation(string prodCode)
//        {
//            string sql = @"select FLOW_SEQ,r.OPERATION_CODE, m.OPERATION_NAME
//from [dbo].[PRODUCT_OPERATION_REL] r
//inner join OPERATION_MST m on m.OPERATION_CODE = r.OPERATION_CODE
//where PRODUCT_CODE = @PRODUCT_CODE
//order by FLOW_SEQ";

//            SqlCommand cmd = new SqlCommand(sql, conn);
//             List<string> operRelList = new List<string>();
//            cmd.Parameters.AddWithValue("@PRODUCT_CODE", prodCode);
//            using (SqlDataReader reader = cmd.ExecuteReader())
//            {

//                while (reader.Read())
//                {
//                    operRelList.Add(reader["VENDOR_CODE"].ToString());

//                }
//            }

//            return operRelList;
//        }

        public bool SetOperation(string prodCode, string userID, List<string> list)
        {
            try
            {
                int row = 0;
                string sql = @"
declare @vSEQ NUMERIC(5,0)

select @vSEQ = max([FLOW_SEQ] )
from PRODUCT_OPERATION_REL
where  PRODUCT_CODE =@PRODUCT_CODE

insert into [dbo].[PRODUCT_OPERATION_REL]([PRODUCT_CODE],[OPERATION_CODE],[FLOW_SEQ],[CREATE_TIME] ,[CREATE_USER_ID] ) values(@PRODUCT_CODE,@OPERATION_CODE, ISNULL(@vSEQ+1,1),getdate(), @CREATE_USER_ID); ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", prodCode);
                    cmd.Parameters.AddWithValue("@CREATE_USER_ID", userID);
                    foreach (string operCode in list)
                    {
                        
                        cmd.Parameters.AddWithValue("@OPERATION_CODE", operCode);
                        row = cmd.ExecuteNonQuery();
                    }
                    return row > 0;

                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteOperation(string prodCode, List<string> list)
        {
            try
            {
                int row = 0;
                string sql = @"delete from PRODUCT_OPERATION_REL
where PRODUCT_CODE = @PRODUCT_CODE and OPERATION_CODE =@OPERATION_CODE ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", prodCode);
                    foreach (string operCode in list)
                    {
                    
                        cmd.Parameters.AddWithValue("@OPERATION_CODE", operCode);
                        row = cmd.ExecuteNonQuery();
                    }
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
