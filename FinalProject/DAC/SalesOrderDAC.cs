
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
    public class SalesOrderDAC : IDisposable
    {
        SqlConnection conn;
        static bool confirmTrigger;
        public static bool ConfirmTrigger { get {return confirmTrigger; } set {confirmTrigger=value; } }
        public SalesOrderDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public DataTable GetSalesOrderList()
        {
            string sql = @"SELECT SALES_ORDER_ID
      ,ORDER_DATE
      ,w.CUSTOMER_CODE
	  ,cd.DATA_1 CUSTOMER_NAME
      ,w.PRODUCT_CODE
	  ,pm.PRODUCT_NAME PRODUCT_NAME
      ,ORDER_QTY
      ,CONFIRM_FLAG
      ,SHIP_FLAG
      ,w.CREATE_TIME
      ,w.CREATE_USER_ID
      ,w.UPDATE_TIME
      ,w.UPDATE_USER_ID
  FROM SALES_ORDER_MST w, PRODUCT_MST pm, CODE_DATA_MST cd
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(SalesOrderProperty vo)
        {
            try
            {
                string sql = @"INSERT INTO [SALES_ORDER_MST]
           ([SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[PRODUCT_CODE]
           ,[CUSTOMER_CODE]
           ,[ORDER_QTY]
           ,[CONFIRM_FLAG]
           ,[SHIP_FLAG]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID])
     VALUES
            (@SALES_ORDER_ID
           ,@ORDER_DATE
           ,@PRODUCT_CODE
           ,@CUSTOMER_CODE
           ,@ORDER_QTY
           ,@CONFIRM_FLAG
           ,@SHIP_FLAG
           ,getdate()
           ,@CREATE_USER_ID) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                    if ((vo.ORDER_DATE == default(DateTime)))
                        cmd.Parameters.AddWithValue("@ORDER_DATE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_DATE", vo.ORDER_DATE);
                    if (vo.CUSTOMER_CODE == null)
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    if (vo.PRODUCT_CODE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    if (vo.ORDER_QTY == null)
                        cmd.Parameters.AddWithValue("@ORDER_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    if (vo.CONFIRM_FLAG == null)
                        cmd.Parameters.AddWithValue("@CONFIRM_FLAG", DBNull.Value);
                    else
                    {
                        cmd.Parameters.AddWithValue("@CONFIRM_FLAG", vo.CONFIRM_FLAG);
                        if (vo.CONFIRM_FLAG == "Y")
                            confirmTrigger = true;
                    }
                    if (vo.SHIP_FLAG == null)
                        cmd.Parameters.AddWithValue("@SHIP_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@SHIP_FLAG", vo.SHIP_FLAG);

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

        public bool Delete(SalesOrderProperty pt)
        {
            try
            {
                string sql = @"delete from [dbo].[SALES_ORDER_MST]
where SALES_ORDER_ID = @SALES_ORDER_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", pt.SALES_ORDER_ID);
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

        public bool Update(SalesOrderProperty vo)
        {
            try
            {
                string sql = @"UPDATE [dbo].[SALES_ORDER_MST] SET
      ORDER_DATE = @ORDER_DATE
      ,PRODUCT_CODE = @PRODUCT_CODE
      ,CUSTOMER_CODE = @CUSTOMER_CODE
      ,ORDER_QTY = @ORDER_QTY
      ,CONFIRM_FLAG = @CONFIRM_FLAG
      ,SHIP_FLAG = @SHIP_FLAG
      ,UPDATE_TIME = getdate()
      ,UPDATE_USER_ID = @UPDATE_USER_ID
      WHERE SALES_ORDER_ID = @SALES_ORDER_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                    if ((vo.ORDER_DATE == default(DateTime)))
                        cmd.Parameters.AddWithValue("@ORDER_DATE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_DATE", vo.ORDER_DATE);
                    if (vo.CUSTOMER_CODE == null)
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    if (vo.PRODUCT_CODE == null)
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    if (vo.ORDER_QTY == null)
                        cmd.Parameters.AddWithValue("@ORDER_QTY", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    if (vo.CONFIRM_FLAG == "" || vo.CONFIRM_FLAG == null)
                        cmd.Parameters.AddWithValue("@CONFIRM_FLAG", DBNull.Value);
                    else
                    {
                        cmd.Parameters.AddWithValue("@CONFIRM_FLAG", vo.CONFIRM_FLAG);
                        if (vo.CONFIRM_FLAG=="Y")
                            confirmTrigger = true;
                    }
                    if (vo.SHIP_FLAG == ""|| vo.SHIP_FLAG == null)
                        cmd.Parameters.AddWithValue("@SHIP_FLAG", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@SHIP_FLAG", vo.SHIP_FLAG);

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
        public bool InsertAutoPurchase(SalesOrderProperty vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[PURCHASE_ORDER_MST]
           ([PURCHASE_ORDER_ID]
           ,[SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[VENDOR_CODE]
           ,[MATERIAL_CODE]
           ,[ORDER_QTY]
           ,[STOCK_IN_LOT_ID])
     VALUES
           (@PURCHASE_ORDER_ID
           ,@SALES_ORDER_ID
           ,getdate()
           ,@VENDOR_CODE
           ,@MATERIAL_CODE
           ,@ORDER_QTY
           ,@STOCK_IN_LOT_ID)";

                string str = vo.SALES_ORDER_ID;
                str = str.Substring(str.Length - 3);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", "PURCHASE_"+str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", "VD_Happy");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE", "RM_Meat");
                    cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID", "220105-RM-MT-" + str);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    int row = cmd.ExecuteNonQuery();

                    if (row <= 0)
                        return false;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", "VD_Miryo");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE", "RM_Salt");
                    cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID", "220105-RM-CD-" + str);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    row = cmd.ExecuteNonQuery();

                    if (row <= 0)
                        return false;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", "VD_Daejin");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE", "RM_Cover");
                    cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID", "220105-RM-CV-" + str);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    row = cmd.ExecuteNonQuery();

                    if (row <= 0)
                        return false;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", "VD_Icandoit");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE", "RM_Can");
                    cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID", "220105-RM-CN-" + str);

                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    row = cmd.ExecuteNonQuery();

                    return row > 0;

                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message); //log에 찍게 해야하나?
                return false;
            }
        }
        public bool InsertAutoWorkOrder(SalesOrderProperty vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[WORK_ORDER_MST]
           ([WORK_ORDER_ID]
           ,[ORDER_DATE]
           ,[PRODUCT_CODE]
           ,[CUSTOMER_CODE]
           ,[ORDER_QTY]
           ,[ORDER_STATUS]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID])
     VALUES
           (@WORK_ORDER_ID
           ,getdate()
           ,@PRODUCT_CODE
           ,@CUSTOMER_CODE
           ,@ORDER_QTY
           ,@ORDER_STATUS
           ,getdate()
           ,@CREATE_USER_ID)";

                string str = vo.SALES_ORDER_ID;
                str = str.Substring(str.Length - 3);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", "WORK_" + str);
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    cmd.Parameters.AddWithValue("@ORDER_QTY", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@ORDER_STATUS", "OPEN");
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
        public List<SalesOrderProperty> GetSalesOrderSearch(SalesOrderPropertySch vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT SALES_ORDER_ID
      ,ORDER_DATE
      ,w.CUSTOMER_CODE
	  ,cd.DATA_1 CUSTOMER_NAME
      ,w.PRODUCT_CODE
	  ,pm.PRODUCT_NAME PRODUCT_NAME
      ,ORDER_QTY
      ,CONFIRM_FLAG
      ,SHIP_FLAG
      ,w.CREATE_TIME
      ,w.CREATE_USER_ID
      ,w.UPDATE_TIME
      ,w.UPDATE_USER_ID
  FROM SALES_ORDER_MST w, PRODUCT_MST pm, CODE_DATA_MST cd
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1 AND 1=1");


            using (SqlCommand cmd = new SqlCommand())
            {
                if (vo.SEARCH_START_DATE != default(DateTime))
                {
                    sb.Append(" and ORDER_DATE >= @SEARCH_START_DATE");
                    cmd.Parameters.AddWithValue("@SEARCH_START_DATE", vo.SEARCH_START_DATE);
                }
                if (vo.SEARCH_END_DATE != default(DateTime))
                {
                    sb.Append(" and ORDER_DATE <= @SEARCH_END_DATE");
                    cmd.Parameters.AddWithValue("@SEARCH_END_DATE", vo.SEARCH_END_DATE);
                }
                if (!string.IsNullOrWhiteSpace(vo.SALES_ORDER_ID))
                {
                    sb.Append(" and SALES_ORDER_ID=@SALES_ORDER_ID");
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);
                }
                if (!string.IsNullOrWhiteSpace(vo.CUSTOMER_CODE))
                {
                    sb.Append(" and w.CUSTOMER_CODE=@CUSTOMER_CODE");
                    cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                }
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    sb.Append(" and w.PRODUCT_CODE=@PRODUCT_CODE");
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }
                if (!string.IsNullOrWhiteSpace(vo.CONFIRM_CHECK))
                {
                    sb.Append(" and CONFIRM_CHECK=@CONFIRM_CHECK");
                    cmd.Parameters.AddWithValue("@CONFIRM_CHECK", vo.CONFIRM_CHECK);
                }
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;


                return Helper.DataReaderMapToList<SalesOrderProperty>(cmd.ExecuteReader());
            }

        }
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

        public List<string> GetProductCodeList()
        {
            string sql = @"SELECT [PRODUCT_CODE] FROM [PRODUCT_MST]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> productCodeList = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    productCodeList.Add(reader["PRODUCT_CODE"].ToString());

                }
            }

            return productCodeList;
        }

        public void Dispose()
        {
            conn.Close();
        }


    }
}
