
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
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1 ORDER BY ORDER_DATE";
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
                string str = vo.SALES_ORDER_ID;
                str = str.Substring(str.Length - 3);

                string rmmtCode = "-RM-MT-";
                string rmcdCode = "-RM-CD-";
                string rmcvCode = "-RM-CV-";
                string rmcnCode = "-RM-CN-";
                string rmlbCode = "-RM-LB-";
                string time = DateTime.Now.ToString("yyMMdd");
                
                string sql = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  
                    
INSERT INTO [dbo].[PURCHASE_ORDER_MST]
           ([PURCHASE_ORDER_ID]
           ,[SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[VENDOR_CODE]
           ,[MATERIAL_CODE]
           ,[ORDER_QTY]
           ,[STOCK_IN_LOT_ID])
     VALUES
           (@PURCHASE_ORDER_ID1
           ,@SALES_ORDER_ID1
           ,getdate()
           ,@VENDOR_CODE1
           ,@MATERIAL_CODE1
           ,@ORDER_QTY1
           ,@STOCK_IN_LOT_ID1)

INSERT INTO [dbo].[PURCHASE_ORDER_MST]
           ([PURCHASE_ORDER_ID]
           ,[SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[VENDOR_CODE]
           ,[MATERIAL_CODE]
           ,[ORDER_QTY]
           ,[STOCK_IN_LOT_ID])
     VALUES
           (@PURCHASE_ORDER_ID2
           ,@SALES_ORDER_ID2
           ,getdate()
           ,@VENDOR_CODE2
           ,@MATERIAL_CODE2
           ,@ORDER_QTY2
           ,@STOCK_IN_LOT_ID2)

INSERT INTO [dbo].[PURCHASE_ORDER_MST]
           ([PURCHASE_ORDER_ID]
           ,[SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[VENDOR_CODE]
           ,[MATERIAL_CODE]
           ,[ORDER_QTY]
           ,[STOCK_IN_LOT_ID])
     VALUES
           (@PURCHASE_ORDER_ID3
           ,@SALES_ORDER_ID3
           ,getdate()
           ,@VENDOR_CODE3
           ,@MATERIAL_CODE3
           ,@ORDER_QTY3
           ,@STOCK_IN_LOT_ID3)

INSERT INTO [dbo].[PURCHASE_ORDER_MST]
           ([PURCHASE_ORDER_ID]
           ,[SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[VENDOR_CODE]
           ,[MATERIAL_CODE]
           ,[ORDER_QTY]
           ,[STOCK_IN_LOT_ID])
     VALUES
           (@PURCHASE_ORDER_ID4
           ,@SALES_ORDER_ID4
           ,getdate()
           ,@VENDOR_CODE4
           ,@MATERIAL_CODE4
           ,@ORDER_QTY4
           ,@STOCK_IN_LOT_ID4)

INSERT INTO [dbo].[PURCHASE_ORDER_MST]
           ([PURCHASE_ORDER_ID]
           ,[SALES_ORDER_ID]
           ,[ORDER_DATE]
           ,[VENDOR_CODE]
           ,[MATERIAL_CODE]
           ,[ORDER_QTY]
           ,[STOCK_IN_LOT_ID])
     VALUES
           (@PURCHASE_ORDER_ID5
           ,@SALES_ORDER_ID5
           ,getdate()
           ,@VENDOR_CODE5
           ,@MATERIAL_CODE5
           ,@ORDER_QTY5
           ,@STOCK_IN_LOT_ID5)

	COMMIT TRANSACTION;  
END TRY  
BEGIN CATCH  
   IF (XACT_STATE()) = -1  
    BEGIN  	    
        PRINT  '에러발생 : ' + ERROR_MESSAGE()  
        ROLLBACK TRANSACTION;  		
    END;  
END CATCH;  
";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID1", "PURCHASE_"+str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID1", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE1", "VD_Happy");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE1", "RM_Meat");
                    cmd.Parameters.AddWithValue("@ORDER_QTY1", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID1", time+rmmtCode+str);
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID2", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID2", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE2", "VD_Miryo");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE2", "RM_Salt");
                    cmd.Parameters.AddWithValue("@ORDER_QTY2", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID2", time + rmcdCode + str);
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID3", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID3", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE3", "VD_Daejin");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE3", "RM_Cover");
                    cmd.Parameters.AddWithValue("@ORDER_QTY3", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID3", time + rmcvCode + str);
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID4", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID4", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE4", "VD_Icandoit");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE4", "RM_Can");
                    cmd.Parameters.AddWithValue("@ORDER_QTY4", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID4", time + rmcnCode + str);
                    cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID5", "PURCHASE_" + str);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID5", vo.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE5", "VD_Label");
                    cmd.Parameters.AddWithValue("@MATERIAL_CODE5", "RM_Label");
                    cmd.Parameters.AddWithValue("@ORDER_QTY5", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID5", time + rmlbCode + str);

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

        public bool InsertLOTStatus(SalesOrderProperty vo)
        {
            try
            {
               

                using (SqlCommand cmd = new SqlCommand())
                {
                  
                    cmd.CommandText = @"DECLARE

@COUNT INT,
@STOCK_IN_LOT_ID VARCHAR(1000),
@MATERIAL_CODE VARCHAR(1000)


SET 
@COUNT = 1


DECLARE @NewLot  TABLE 
				(
					ID INT identity(1,1),
							STOCK_IN_LOT_ID VARCHAR(1000),
						MATERIAL_CODE VARCHAR(1000)
				)
 
				INSERT INTO @NewLot
				SELECT STOCK_IN_LOT_ID, MATERIAL_CODE FROM PURCHASE_ORDER_MST
				WHERE SALES_ORDER_ID = @SALES_ORDER_ID

				SELECT * FROM @NewLot



				WHILE @COUNT <6
				BEGIN
					select @STOCK_IN_LOT_ID = STOCK_IN_LOT_ID, @MATERIAL_CODE =MATERIAL_CODE FROM @NewLot WHERE ID=@COUNT

						INSERT[dbo].[LOT_STS]
						(LOT_ID, LOT_DESC, PRODUCT_CODE, STORE_CODE, 
						LOT_QTY, CREATE_QTY, OPER_IN_QTY, PRODUCTION_TIME, 
						CREATE_TIME, OPER_IN_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME,
						LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ)
						VALUES(@STOCK_IN_LOT_ID, '자재 LOT 생성', @MATERIAL_CODE, 'RS_STOCK', 
						@LOT_QTY, @LOT_QTY, @LOT_QTY, GETDATE(), 
						GETDATE(), GETDATE(), 'CREATE', GETDATE(),
						LAST_TRAN_USER_ID, '자재 LOT 생성', 1);

						INSERT [dbo].[LOT_HIS]
						(LOT_ID, LOT_DESC, PRODUCT_CODE, STORE_CODE, 
						LOT_QTY, CREATE_QTY, OPER_IN_QTY, PRODUCTION_TIME, 
						CREATE_TIME, OPER_IN_TIME, TRAN_CODE, TRAN_TIME,
						TRAN_USER_ID,TRAN_COMMENT, HIST_SEQ)
						SELECT LOT_ID, LOT_DESC, PRODUCT_CODE, STORE_CODE, 
						LOT_QTY, CREATE_QTY, OPER_IN_QTY, PRODUCTION_TIME, 
						CREATE_TIME, OPER_IN_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME,
						LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ
						FROM LOT_STS
						WHERE LOT_ID = @STOCK_IN_LOT_ID AND PRODUCT_CODE = @MATERIAL_CODE

						SET @COUNT = @COUNT +1

				END";

                    cmd.Connection = conn;
                    if (vo.CREATE_USER_ID == null)
                        cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", vo.CREATE_USER_ID);
                    cmd.Parameters.AddWithValue("@LOT_QTY", vo.ORDER_QTY);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", vo.SALES_ORDER_ID);

                    int row = cmd.ExecuteNonQuery();

                    return true;

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
