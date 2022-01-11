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
    public class ShipDAC : IDisposable
    {
        SqlConnection conn;
        public ShipDAC()
        {
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
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1 AND SHIP_FLAG is null ORDER BY ORDER_DATE ";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetLOT()
        {
            string sql = @"SELECT [LOT_ID]
      ,[LOT_DESC]
      ,[PRODUCT_CODE]
      ,[OPERATION_CODE]
      ,[STORE_CODE]
      ,[LOT_QTY]
      ,[CREATE_QTY]
      ,[OPER_IN_QTY]
      ,[START_FLAG]
      ,[START_QTY]
      ,[START_TIME]
      ,[START_EQUIPMENT_CODE]
      ,[END_FLAG]
      ,[END_TIME]
      ,[END_EQUIPMENT_CODE]
      ,[SHIP_FLAG]
      ,[SHIP_CODE]
      ,[SHIP_TIME]
      ,[PRODUCTION_TIME]
      ,[CREATE_TIME]
      ,[OPER_IN_TIME]
      ,[WORK_ORDER_ID]
      ,[LOT_DELETE_FLAG]
      ,[LOT_DELETE_CODE]
      ,[LOT_DELETE_TIME]
      ,[LAST_TRAN_CODE]
      ,[LAST_TRAN_TIME]
      ,[LAST_TRAN_USER_ID]
      ,[LAST_TRAN_COMMENT]
      ,[LAST_HIST_SEQ]
  FROM [dbo].[LOT_STS]
  WHERE STORE_CODE='FS_STORE' ";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }
        public List<ShipPropertySch> GetFSStoreList(ShipProperty vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT LOT_ID
      ,LOT_QTY
      ,OPER_IN_TIME
  FROM LOT_STS
  WHERE 1=1 AND STORE_CODE='FS_STORE' and PRODUCT_CODE=@PRODUCT_CODE
  ");


            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }

                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<ShipPropertySch>(cmd.ExecuteReader());
            }

        }

        public bool ShipLOT_Update(ShipPropertyUpdate updateVO)
        {
            try
            {
                string sql = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

UPDATE[dbo].[LOT_STS]
         SET SHIP_FLAG = @SHIP_FLAG
              , SHIP_CODE = @SHIP_CODE
              , SHIP_TIME = getdate()
              , PRODUCTION_TIME = @PRODUCTION_TIME
              , OPER_IN_TIME = @OPER_IN_TIME
              , LOT_DELETE_FLAG = @LOT_DELETE_FLAG
              , LOT_DELETE_CODE = @LOT_DELETE_CODE
              , LOT_DELETE_TIME = getdate()
              , LAST_TRAN_CODE = @LAST_TRAN_CODE
              , LAST_TRAN_TIME = getdate()
              , LAST_TRAN_USER_ID = @LAST_TRAN_USER_ID
              , LAST_TRAN_COMMENT = @LAST_TRAN_COMMENT
              , LAST_HIST_SEQ = @LAST_HIST_SEQ
         WHERE LOT_ID = @LOT_ID

UPDATE [dbo].[SALES_ORDER_MST]
   SET [SHIP_FLAG] = @SHIP_FLAG
      ,[UPDATE_TIME] = getdate()
      ,[UPDATE_USER_ID] = @LAST_TRAN_USER_ID
 WHERE [SALES_ORDER_ID] = @SALES_ORDER_ID

INSERT [dbo].[SHIP_LOT_HIS]
           ([SALES_ORDER_ID]
           ,[LOT_ID]
           ,[SHIP_TIME]
           ,[PRODUCT_CODE]
           ,[SHIP_QTY]
           ,[SHIP_USER_ID])
     SELECT
           @SALES_ORDER_ID
           ,@LOT_ID
           ,getdate()
           ,@PRODUCT_CODE
           ,@LOT_QTY
           ,@LAST_TRAN_USER_ID

INSERT [dbo].[LOT_HIS]
           ([LOT_ID]
           ,[HIST_SEQ]
           ,[TRAN_TIME]
           ,[TRAN_CODE]
           ,[LOT_DESC]
           ,[PRODUCT_CODE]
           ,[OPERATION_CODE]
           ,[STORE_CODE]
           ,[LOT_QTY]
           ,[CREATE_QTY]
           ,[OPER_IN_QTY]
           ,[START_FLAG]
           ,[START_QTY]
           ,[START_TIME]
           ,[START_EQUIPMENT_CODE]
           ,[END_FLAG]
           ,[END_TIME]
           ,[END_EQUIPMENT_CODE]
           ,[SHIP_FLAG]
           ,[SHIP_CODE]
           ,[SHIP_TIME]
           ,[PRODUCTION_TIME]
           ,[CREATE_TIME]
           ,[OPER_IN_TIME]
           ,[WORK_ORDER_ID]
           ,[LOT_DELETE_FLAG]
           ,[LOT_DELETE_CODE]
           ,[LOT_DELETE_TIME]
           ,[TRAN_USER_ID]
           ,[TRAN_COMMENT]
           ,[OLD_PRODUCT_CODE]
           ,[OLD_OPERATION_CODE]
           ,[OLD_STORE_CODE]
           ,[OLD_LOT_QTY])
select s.[LOT_ID]		
	  ,s.[LAST_HIST_SEQ]
      ,s.[LAST_TRAN_TIME]
      ,s.[LAST_TRAN_CODE]
      ,s.[LOT_DESC]
      ,s.[PRODUCT_CODE]
      ,s.[OPERATION_CODE]
      ,s.[STORE_CODE]
      ,s.[LOT_QTY]
      ,s.[CREATE_QTY]
      ,s.[OPER_IN_QTY]
      ,s.[START_FLAG]
      ,s.[START_QTY]
      ,s.[START_TIME]
      ,s.[START_EQUIPMENT_CODE]
      ,s.[END_FLAG]
      ,s.[END_TIME]
      ,s.[END_EQUIPMENT_CODE]
      ,s.[SHIP_FLAG]
      ,s.[SHIP_CODE]
      ,s.[SHIP_TIME]
      ,s.[PRODUCTION_TIME]
      ,s.[CREATE_TIME]
      ,s.[OPER_IN_TIME]
      ,s.[WORK_ORDER_ID]
      ,s.[LOT_DELETE_FLAG]
      ,s.[LOT_DELETE_CODE]
      ,s.[LOT_DELETE_TIME]
      ,s.[LAST_TRAN_USER_ID]
      ,s.[LAST_TRAN_COMMENT]
	  ,s.[PRODUCT_CODE]
      ,s.[OPERATION_CODE]
      ,s.[STORE_CODE]
      ,s.[LOT_QTY]
from [dbo].[LOT_STS] s
where s.LOT_ID = @LOT_ID

insert [BARCODE]
(Barcode_ID, PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TIME, LOT_QTY)
select 
@SALES_ORDER_ID,@PRODUCT_CODE,@PRODUCT_NAME,SHIP_TIME,@LOT_QTY
From LOT_STS
where LOT_ID = @LOT_ID

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
                    cmd.Parameters.AddWithValue("@LOT_ID", updateVO.LOT_ID);
                    cmd.Parameters.AddWithValue("@SHIP_FLAG", updateVO.SHIP_FLAG);
                    cmd.Parameters.AddWithValue("@SHIP_CODE", updateVO.SHIP_CODE);
                    //cmd.Parameters.AddWithValue("@SHIP_TIME", updateVO.SHIP_TIME); getdate()
                    //cmd.Parameters.AddWithValue("@PRODUCTION_TIME", updateVO.PRODUCTION_TIME);
                    //cmd.Parameters.AddWithValue("@OPER_IN_TIME", updateVO.OPER_IN_TIME);
                    cmd.Parameters.AddWithValue("@LOT_DELETE_FLAG", updateVO.LOT_DELETE_FLAG);
                    cmd.Parameters.AddWithValue("@LOT_DELETE_CODE", updateVO.LOT_DELETE_CODE);
                    //cmd.Parameters.AddWithValue("@LOT_DELETE_TIME", updateVO.LAST_TRAN_USER_ID); getdate()
                    cmd.Parameters.AddWithValue("@LAST_TRAN_CODE", updateVO.LAST_TRAN_CODE);
                    //cmd.Parameters.AddWithValue("@LAST_TRAN_TIME", updateVO.LAST_TRAN_TIME); getdate()
                    cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", updateVO.LAST_TRAN_USER_ID);
                    cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", updateVO.LAST_TRAN_COMMENT);
                    cmd.Parameters.AddWithValue("@LAST_HIST_SEQ", updateVO.LAST_HIST_SEQ);
                    cmd.Parameters.AddWithValue("@SALES_ORDER_ID", updateVO.SALES_ORDER_ID);
                    cmd.Parameters.AddWithValue("@LOT_QTY", updateVO.LOT_QTY);
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", updateVO.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@PRODUCT_NAME", updateVO.PRODUCT_NAME);

                    if ((updateVO.PRODUCTION_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@PRODUCTION_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PRODUCTION_TIME", updateVO.PRODUCTION_TIME);
                    if ((updateVO.OPER_IN_TIME == default(DateTime)))
                        cmd.Parameters.AddWithValue("@OPER_IN_TIME", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OPER_IN_TIME", updateVO.OPER_IN_TIME);


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

        public DataTable GetBarcodeList()
        {
            string sql = @"SELECT [Barcode_ID]
      ,[PRODUCT_CODE]
      ,[PRODUCT_NAME]
      ,[PRODUCT_TIME]
      ,[LOT_QTY]
  FROM [team3].[dbo].[BARCODE]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable ExportBarcode(string strChkBarCodes)
        {
            string sql = @"SELECT [Barcode_ID]
      ,[PRODUCT_CODE]
      ,[PRODUCT_NAME]
      ,[PRODUCT_TIME]
      ,[LOT_QTY]
  FROM [team3].[dbo].[BARCODE]
  where Barcode_ID in ('" + strChkBarCodes + "')";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}

