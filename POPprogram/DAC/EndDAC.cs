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
    public class EndDAC : IDisposable
    {
        SqlConnection conn;
        public EndDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }
        public List<string> GetLotList()
        {
            string sql = @"select LOT_ID, s.PRODUCT_CODE
from LOT_STS s inner
join WORK_ORDER_MST w on s.WORK_ORDER_ID = w.WORK_ORDER_ID
left join OPERATION_MST o  on s.OPERATION_CODE = o.OPERATION_CODE
WHERE  LEFT(s.PRODUCT_CODE, 2) = 'pd' AND ORDER_STATUS<>'CLOSE' AND END_FLAG is null
AND LOT_DELETE_FLAG is null
 ";
            // AND lot.SHIP_FLAG is null
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> List = new List<string>();
            using (SqlDataReader da = cmd.ExecuteReader())
            {
                while (da.Read())
                {
                    List.Add(da["LOT_ID"].ToString());

                }
            }
            return List;
        }
        public List<EndProperty> GetStatusList(EndProperty vo)
        {
            StringBuilder sb = new StringBuilder();
  
            sb.Append(@"select c.DATA_1 CUSTOMER_NAME,lot.LOT_QTY, lot.LOT_DESC,lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY, lot.LOT_QTY PRODUCT_QTY, work.ORDER_QTY-lot.LOT_QTY DEFECT_QTY
, o.CHECK_DEFECT_FLAG, o.CHECK_INSPECT_FLAG, o.CHECK_MATERIAL_FLAG
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   left join CODE_DATA_MST c on work.CUSTOMER_CODE = c.KEY_1
   where LOT_ID = @LOT_ID AND o.OPERATION_CODE=lot.OPERATION_CODE");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.LOT_ID))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", vo.LOT_ID);
                }

                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndProperty>(cmd.ExecuteReader());
            }

        }
        public List<EndPropertyUse> GetBomChildList(EndPropertyPrdCode vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT CHILD_PRODUCT_CODE, prod.PRODUCT_NAME CHILD_PRODUCT_NAME, REQUIRE_QTY, sum(LOT_QTY) SUM_QTY
  FROM LOT_STS lot
left join BOM_MST bom on bom.CHILD_PRODUCT_CODE=lot.PRODUCT_CODE
left join PRODUCT_MST prod on prod.PRODUCT_CODE=lot.PRODUCT_CODE

  WHERE lot.STORE_CODE != 'FS_STORE' AND lot.STORE_CODE is not null
  	AND bom.PRODUCT_CODE=@PRODUCT_CODE
	Group BY CHILD_PRODUCT_CODE,prod.PRODUCT_NAME, REQUIRE_QTY
");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }

                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndPropertyUse>(cmd.ExecuteReader());
            }

        }

        public List<EndProperty> GetRMLotList(EndProperty vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT LOT_ID, lot.PRODUCT_CODE
  FROM LOT_STS lot
left join BOM_MST bom on bom.CHILD_PRODUCT_CODE=lot.PRODUCT_CODE
left join PRODUCT_MST prod on prod.PRODUCT_CODE=lot.PRODUCT_CODE

  WHERE lot.STORE_CODE != 'FS_STORE' AND lot.STORE_CODE is not null
  	AND bom.PRODUCT_CODE=@LOT_ID AND CHILD_PRODUCT_CODE=@PRODUCT_CODE ");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.LOT_ID))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", vo.LOT_ID);
                }
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndProperty>(cmd.ExecuteReader());
            }

        }

        public List<EndPropertyLOTHis> GetOperCheckList(EndPropertyLOTHis vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT LOT_ID
      ,TRAN_CODE
      ,PRODUCT_CODE
      ,his.OPERATION_CODE
	  ,op.CHECK_DEFECT_FLAG
	  ,op.CHECK_INSPECT_FLAG
	  ,op.CHECK_MATERIAL_FLAG
  FROM LOT_HIS his, OPERATION_MST op
  where his.OPERATION_CODE=op.OPERATION_CODE AND lot_id=@LOT_ID AND his.OPERATION_CODE=@OPERATION_CODE ");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.LOT_ID))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", vo.LOT_ID);
                }
                if (!string.IsNullOrWhiteSpace(vo.OPERATION_CODE))
                {
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", vo.OPERATION_CODE);
                }
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndPropertyLOTHis>(cmd.ExecuteReader());
            }

        }

        public bool EndLOT_Update(EndPropertyUpdate updateVO)
        {
            try
            {
                string sql = null;
                string sql_under1700 = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

UPDATE[dbo].[LOT_STS]
         SET
		 OPERATION_CODE = @OPERATION_CODE
		 ,OPER_IN_QTY =@OPER_IN_QTY
		 ,OPER_IN_TIME = getdate()
		 ,START_FLAG=NULL
		 ,START_QTY=NULL
		 ,START_TIME=NULL
		 ,END_FLAG='Y'
		 ,END_TIME=getdate()
		 ,END_EQUIPMENT_CODE=@END_EQUIPMENT_CODE
		 ,LAST_TRAN_CODE='END'
		 ,LAST_TRAN_TIME=getdate()
		 ,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
		 ,LAST_TRAN_COMMENT='생산 LOT 작업 완료'
		 ,LAST_HIST_SEQ=LAST_HIST_SEQ+1
         WHERE LOT_ID = @LOT_ID


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
      ,@OLD_OPERATION_CODE
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

INSERT INTO [dbo].[LOT_END_HIS]
           ([LOT_ID]
           ,[HIST_SEQ]
           ,[TRAN_TIME]
           ,[TRAN_CODE]
           ,[PRODUCT_CODE]
           ,[OPERATION_CODE]
           ,[EQUIPMENT_CODE]
           ,[TRAN_USER_ID]
           ,[TRAN_COMMENT]
           ,[TO_OPERATION_CODE]
           ,[OPER_IN_QTY]
           ,[START_QTY]
           ,[END_QTY]
           ,[OPER_IN_TIME]
           ,[START_TIME]
           ,[PROC_TIME]
           ,[WORK_ORDER_ID])
     select s.[LOT_ID]		
	  ,s.[LAST_HIST_SEQ]
      ,s.[LAST_TRAN_TIME]
      ,s.[LAST_TRAN_CODE]
      ,s.[PRODUCT_CODE]
      ,@OLD_OPERATION_CODE
      ,@END_EQUIPMENT_CODE
      ,s.[LAST_TRAN_USER_ID]
      ,s.[LAST_TRAN_COMMENT]
      ,s.[OPERATION_CODE]
      ,s.[OPER_IN_QTY]
      ,s.[START_QTY]
      ,s.[LOT_QTY]
	  ,s.[LAST_TRAN_TIME]
      ,s.[START_TIME]
      ,s.[LAST_HIST_SEQ]
	  ,s.[WORK_ORDER_ID]
from [dbo].[LOT_STS] s
where s.LOT_ID = @LOT_ID

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
                string sql_end = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

UPDATE[dbo].[LOT_STS]
         SET
		 OPERATION_CODE = @OPERATION_CODE
		 ,OPER_IN_QTY =@OPER_IN_QTY
		 ,OPER_IN_TIME = getdate()
		 ,START_FLAG=NULL
		 ,START_QTY=NULL
		 ,START_TIME=NULL
		 ,END_FLAG='Y'
		 ,END_TIME=getdate()
		 ,END_EQUIPMENT_CODE=@END_EQUIPMENT_CODE
		 ,LAST_TRAN_CODE='END'
		 ,LAST_TRAN_TIME=getdate()
		 ,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
		 ,LAST_TRAN_COMMENT='생산 LOT 작업 완료'
		 ,LAST_HIST_SEQ=LAST_HIST_SEQ+1
         WHERE LOT_ID = @LOT_ID


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
      ,@OLD_OPERATION_CODE
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

UPDATE[dbo].[LOT_STS]
         SET
		 OPERATION_CODE = NULL
         ,STORE_CODE='FS_STORE'
		 ,OPER_IN_TIME = getdate()
		 ,START_FLAG=NULL
		 ,START_QTY=NULL
		 ,START_TIME=NULL
         ,START_EQUIPMENT_CODE = NULL
		 ,END_FLAG=NULL
		 ,END_TIME=NULL
		 ,END_EQUIPMENT_CODE=NULL
         ,PRODUCTION_TIME = GETDATE()
		 ,LAST_TRAN_CODE='MOVE'
		 ,LAST_TRAN_TIME=getdate()
		 ,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
		 ,LAST_TRAN_COMMENT='제품 창고 이동'
		 ,LAST_HIST_SEQ=LAST_HIST_SEQ+1
         WHERE LOT_ID = @LOT_ID

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
      ,@OLD_OPERATION_CODE
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

  UPDATE WORK_ORDER_MST SET
ORDER_STATUS='CLOSE',
PRODUCT_QTY=lot.LOT_QTY,
DEFECT_QTY=lot.CREATE_QTY-lot.LOT_QTY,
WORK_START_TIME=(SELECT TRAN_TIME FROM LOT_HIS WHERE WORK_ORDER_ID=@WORK_ORDER_ID AND OPERATION_CODE='1000' AND TRAN_CODE='Start' ),
WORK_CLOSE_TIME=(SELECT TRAN_TIME FROM LOT_HIS WHERE WORK_ORDER_ID=@WORK_ORDER_ID AND OPERATION_CODE='1600' AND TRAN_CODE='END' ),
WORK_CLOSE_USER_ID = (SELECT TRAN_USER_ID FROM LOT_HIS WHERE WORK_ORDER_ID=@WORK_ORDER_ID AND OPERATION_CODE='1600' AND TRAN_CODE='END' )
FROM (SELECT * FROM LOT_STS) lot
WHERE WORK_ORDER_MST.WORK_ORDER_ID=lot.WORK_ORDER_ID AND lot.WORK_ORDER_ID=@WORK_ORDER_ID

INSERT INTO [dbo].[LOT_END_HIS]
           ([LOT_ID]
           ,[HIST_SEQ]
           ,[TRAN_TIME]
           ,[TRAN_CODE]
           ,[PRODUCT_CODE]
           ,[OPERATION_CODE]
           ,[EQUIPMENT_CODE]
           ,[TRAN_USER_ID]
           ,[TRAN_COMMENT]
           ,[TO_OPERATION_CODE]
           ,[OPER_IN_QTY]
           ,[START_QTY]
           ,[END_QTY]
           ,[OPER_IN_TIME]
           ,[START_TIME]
           ,[PROC_TIME]
           ,[WORK_ORDER_ID])
     select s.[LOT_ID]		
	  ,s.[LAST_HIST_SEQ]
      ,s.[LAST_TRAN_TIME]
      ,s.[LAST_TRAN_CODE]
      ,s.[PRODUCT_CODE]
      ,@OLD_OPERATION_CODE
      ,@END_EQUIPMENT_CODE
      ,s.[LAST_TRAN_USER_ID]
      ,s.[LAST_TRAN_COMMENT]
      ,s.[OPERATION_CODE]
      ,s.[OPER_IN_QTY]
      ,s.[START_QTY]
      ,s.[LOT_QTY]
	  ,s.[LAST_TRAN_TIME]
      ,s.[START_TIME]
      ,s.[LAST_HIST_SEQ]
	  ,s.[WORK_ORDER_ID]
from [dbo].[LOT_STS] s
where s.LOT_ID = @LOT_ID


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

                if (Convert.ToInt32(updateVO.OPERATION_CODE) < 1700) sql = sql_under1700;
                else sql = sql_end;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", updateVO.LOT_ID);
                    cmd.Parameters.AddWithValue("@OPERATION_CODE", updateVO.OPERATION_CODE);
                    cmd.Parameters.AddWithValue("@OPER_IN_QTY", updateVO.OPER_IN_QTY);
                    cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", updateVO.LAST_TRAN_USER_ID);
                    cmd.Parameters.AddWithValue("@END_EQUIPMENT_CODE", updateVO.END_EQUIPMENT_CODE);
                    cmd.Parameters.AddWithValue("@OLD_OPERATION_CODE", updateVO.OLD_OPERATION_CODE);
                    cmd.Parameters.AddWithValue("@WORK_ORDER_ID", updateVO.WORK_ORDER_ID);
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
 
        public DataTable GetEQList()
        {
            string sql = @"SELECT KEY_1 EQ_CODE, DATA_1 EQ_NAME
FROM CODE_DATA_MST
WHERE CODE_TABLE_NAME='CM_MACHINE' ";
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

