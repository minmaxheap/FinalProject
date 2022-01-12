﻿using System;
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
    public class MatDAC : IDisposable
    {
        SqlConnection conn;
        public MatDAC()
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
WHERE  LEFT(s.PRODUCT_CODE, 2) = 'pd' AND ORDER_STATUS<>'CLOSE' and o.CHECK_MATERIAL_FLAG='Y'
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
        public List<MatProperty> GetStatusList(MatProperty vo)
        {
            StringBuilder sb = new StringBuilder();
  
            sb.Append(@"select c.DATA_1 CUSTOMER_NAME,lot.LOT_QTY, lot.LOT_DESC,lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   left join CODE_DATA_MST c on work.CUSTOMER_CODE = c.KEY_1
   where LOT_ID = @LOT_ID");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.LOT_ID))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", vo.LOT_ID);
                }

                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<MatProperty>(cmd.ExecuteReader());
            }

        }
        public List<MatPropertyUse> GetBomChildList(MatPropertyPrdCode vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT CHILD_PRODUCT_CODE, prod.PRODUCT_NAME CHILD_PRODUCT_NAME, REQUIRE_QTY, sum(LOT_QTY) SUM_QTY
  FROM LOT_STS lot
left join BOM_MST bom on bom.CHILD_PRODUCT_CODE=lot.PRODUCT_CODE
left join PRODUCT_MST prod on prod.PRODUCT_CODE=lot.PRODUCT_CODE

  WHERE lot.STORE_CODE != 'FS_STORE' AND lot.STORE_CODE is not null
  	AND (bom.PRODUCT_CODE=@PRODUCT_CODE or bom.PRODUCT_CODE='HB_MIXED')
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

                return Helper.DataReaderMapToList<MatPropertyUse>(cmd.ExecuteReader());
            }

        }

        public List<MatProperty> GetRMLotList(MatProperty vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT LOT_ID
  FROM LOT_STS lot
left join BOM_MST bom on bom.CHILD_PRODUCT_CODE=lot.PRODUCT_CODE
left join PRODUCT_MST prod on prod.PRODUCT_CODE=lot.PRODUCT_CODE

  WHERE 
  lot.STORE_CODE != 'FS_STORE'
  AND lot.STORE_CODE is not null
  AND lot.LOT_QTY>=0
  AND (lot.LOT_DELETE_FLAG ='N' OR lot.LOT_DELETE_FLAG is null)
   AND CHILD_PRODUCT_CODE=@PRODUCT_CODE
group by lot.PRODUCT_CODE,LOT_ID
");
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

                return Helper.DataReaderMapToList<MatProperty>(cmd.ExecuteReader());
            }

        }

        public bool SetUseLOT(MatPropertyUpdate updateVO)
        {

            try
            {
                string sql;
                string sql_oper_1100 = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

UPDATE[dbo].[LOT_STS]
         SET  LOT_QTY=@BOM_LOT_QTY_1
,LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
,LOT_DELETE_FLAG	='Y'
,LOT_DELETE_CODE	='EMPTY'	
,LOT_DELETE_TIME=GETDATE()
WHERE LOT_ID=@BOM_LOT_ID_1

UPDATE[dbo].[LOT_STS]
         SET  LOT_QTY=@BOM_LOT_QTY_2
,LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
,LOT_DELETE_FLAG	='Y'
,LOT_DELETE_CODE	='EMPTY'	
,LOT_DELETE_TIME=GETDATE()
WHERE LOT_ID=@BOM_LOT_ID_2

UPDATE[dbo].[LOT_STS]
         SET  LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
WHERE LOT_ID=@LOT_ID

UPDATE[dbo].[LOT_STS]
         SET  LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
,LOT_QTY=@BOM_LOT_QTY_1
WHERE PRODUCT_CODE='HB_Mixed' AND LOT_QTY=0

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
where s.LOT_ID = @BOM_LOT_ID_1

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
where s.LOT_ID = @BOM_LOT_ID_2

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

INSERT [dbo].[LOT_MATERIAL_HIS]
           ([MATERIAL_LOT_ID]
      ,[MATERIAL_LOT_HIST_SEQ]
	  ,[LOT_ID]
      ,[HIST_SEQ]
      ,[INPUT_QTY]
      ,[MATERIAL_STORE_CODE]
      ,[TRAN_TIME]
      ,[TRAN_CODE]
      ,[PRODUCT_CODE]
      ,[OPERATION_CODE]
      ,[EQUIPMENT_CODE]
      ,[TRAN_USER_ID]
      ,[TRAN_COMMENT])
     SELECT
	   new.PRODUCT_CODE
      ,new.LAST_HIST_SEQ
      ,s.LOT_ID
      ,s.LAST_HIST_SEQ
      ,s.LOT_QTY
      ,s.STORE_CODE
      ,s.LAST_TRAN_TIME
      ,s.LAST_TRAN_CODE
      ,s.PRODUCT_CODE
      ,s.OPERATION_CODE
      ,s.END_EQUIPMENT_CODE
      ,s.LAST_TRAN_USER_ID
      ,s.LAST_TRAN_COMMENT
	  FROM LOT_STS s, (SELECT
	   lot.PRODUCT_CODE
      ,lot.LAST_HIST_SEQ
	  FROM LOT_STS lot
	  left join BOM_MST bom on bom.PRODUCT_CODE = lot.PRODUCT_CODE
	  WHERE lot.LOT_ID=@BOM_LOT_ID_1) new
	  WHERE s.LOT_ID=@LOT_ID

INSERT [dbo].[LOT_MATERIAL_HIS]
           ([MATERIAL_LOT_ID]
      ,[MATERIAL_LOT_HIST_SEQ]
	  ,[LOT_ID]
      ,[HIST_SEQ]
      ,[INPUT_QTY]
      ,[MATERIAL_STORE_CODE]
      ,[TRAN_TIME]
      ,[TRAN_CODE]
      ,[PRODUCT_CODE]
      ,[OPERATION_CODE]
      ,[EQUIPMENT_CODE]
      ,[TRAN_USER_ID]
      ,[TRAN_COMMENT])
     SELECT
	   new.PRODUCT_CODE
      ,new.LAST_HIST_SEQ
      ,s.LOT_ID
      ,s.LAST_HIST_SEQ
      ,s.LOT_QTY
      ,s.STORE_CODE
      ,s.LAST_TRAN_TIME
      ,s.LAST_TRAN_CODE
      ,s.PRODUCT_CODE
      ,s.OPERATION_CODE
      ,s.END_EQUIPMENT_CODE
      ,s.LAST_TRAN_USER_ID
      ,s.LAST_TRAN_COMMENT
	  FROM LOT_STS s, (SELECT
	   lot.PRODUCT_CODE
      ,lot.LAST_HIST_SEQ
	  FROM LOT_STS lot
	  left join BOM_MST bom on bom.PRODUCT_CODE = lot.PRODUCT_CODE
	  WHERE lot.LOT_ID=@BOM_LOT_ID_2) new
	  WHERE s.LOT_ID=@LOT_ID

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
                string sql_item_1 = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

UPDATE[dbo].[LOT_STS]
         SET  LOT_QTY=@BOM_LOT_QTY_1
,LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
,LOT_DELETE_FLAG	='Y'
,LOT_DELETE_CODE	='EMPTY'	
,LOT_DELETE_TIME=GETDATE()
WHERE LOT_ID=@BOM_LOT_ID_1

UPDATE[dbo].[LOT_STS]
         SET  LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
WHERE LOT_ID=@LOT_ID

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
where s.LOT_ID = @BOM_LOT_ID_1

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

INSERT [dbo].[LOT_MATERIAL_HIS]
           ([MATERIAL_LOT_ID]
      ,[MATERIAL_LOT_HIST_SEQ]
	  ,[LOT_ID]
      ,[HIST_SEQ]
      ,[INPUT_QTY]
      ,[MATERIAL_STORE_CODE]
      ,[TRAN_TIME]
      ,[TRAN_CODE]
      ,[PRODUCT_CODE]
      ,[OPERATION_CODE]
      ,[EQUIPMENT_CODE]
      ,[TRAN_USER_ID]
      ,[TRAN_COMMENT])
     SELECT
	   new.PRODUCT_CODE
      ,new.LAST_HIST_SEQ
      ,s.LOT_ID
      ,s.LAST_HIST_SEQ
      ,s.LOT_QTY
      ,s.STORE_CODE
      ,s.LAST_TRAN_TIME
      ,s.LAST_TRAN_CODE
      ,s.PRODUCT_CODE
      ,s.OPERATION_CODE
      ,s.END_EQUIPMENT_CODE
      ,s.LAST_TRAN_USER_ID
      ,s.LAST_TRAN_COMMENT
	  FROM LOT_STS s, (SELECT
	   lot.PRODUCT_CODE
      ,lot.LAST_HIST_SEQ
	  FROM LOT_STS lot
	  left join BOM_MST bom on bom.PRODUCT_CODE = lot.PRODUCT_CODE
	  WHERE lot.LOT_ID=@BOM_LOT_ID_1) new
	  WHERE s.LOT_ID=@LOT_ID

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
                string sql_item_2 = @"SET XACT_ABORT ON;  

BEGIN TRY  
    BEGIN TRANSACTION;  

UPDATE[dbo].[LOT_STS]
         SET  LOT_QTY=@BOM_LOT_QTY_1
,LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
,LOT_DELETE_FLAG	='Y'
,LOT_DELETE_CODE	='EMPTY'	
,LOT_DELETE_TIME=GETDATE()
WHERE LOT_ID=@BOM_LOT_ID_1

UPDATE[dbo].[LOT_STS]
         SET  LOT_QTY=@BOM_LOT_QTY_2
,LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
,LOT_DELETE_FLAG	='Y'
,LOT_DELETE_CODE	='EMPTY'	
,LOT_DELETE_TIME=GETDATE()
WHERE LOT_ID=@BOM_LOT_ID_2

UPDATE[dbo].[LOT_STS]
         SET  LAST_TRAN_CODE='INPUT'
,LAST_TRAN_TIME=GETDATE()
,LAST_TRAN_USER_ID=@LAST_TRAN_USER_ID
,LAST_TRAN_COMMENT='자재 사용'
,LAST_HIST_SEQ	 = LAST_HIST_SEQ+1
WHERE LOT_ID=@LOT_ID

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
where s.LOT_ID = @BOM_LOT_ID_1

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
where s.LOT_ID = @BOM_LOT_ID_2

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

INSERT [dbo].[LOT_MATERIAL_HIS]
           ([MATERIAL_LOT_ID]
      ,[MATERIAL_LOT_HIST_SEQ]
	  ,[LOT_ID]
      ,[HIST_SEQ]
      ,[INPUT_QTY]
      ,[MATERIAL_STORE_CODE]
      ,[TRAN_TIME]
      ,[TRAN_CODE]
      ,[PRODUCT_CODE]
      ,[OPERATION_CODE]
      ,[EQUIPMENT_CODE]
      ,[TRAN_USER_ID]
      ,[TRAN_COMMENT])
     SELECT
	   new.PRODUCT_CODE
      ,new.LAST_HIST_SEQ
      ,s.LOT_ID
      ,s.LAST_HIST_SEQ
      ,s.LOT_QTY
      ,s.STORE_CODE
      ,s.LAST_TRAN_TIME
      ,s.LAST_TRAN_CODE
      ,s.PRODUCT_CODE
      ,s.OPERATION_CODE
      ,s.END_EQUIPMENT_CODE
      ,s.LAST_TRAN_USER_ID
      ,s.LAST_TRAN_COMMENT
	  FROM LOT_STS s, (SELECT
	   lot.PRODUCT_CODE
      ,lot.LAST_HIST_SEQ
	  FROM LOT_STS lot
	  left join BOM_MST bom on bom.PRODUCT_CODE = lot.PRODUCT_CODE
	  WHERE lot.LOT_ID=@BOM_LOT_ID_1) new
	  WHERE s.LOT_ID=@LOT_ID

INSERT [dbo].[LOT_MATERIAL_HIS]
           ([MATERIAL_LOT_ID]
      ,[MATERIAL_LOT_HIST_SEQ]
	  ,[LOT_ID]
      ,[HIST_SEQ]
      ,[INPUT_QTY]
      ,[MATERIAL_STORE_CODE]
      ,[TRAN_TIME]
      ,[TRAN_CODE]
      ,[PRODUCT_CODE]
      ,[OPERATION_CODE]
      ,[EQUIPMENT_CODE]
      ,[TRAN_USER_ID]
      ,[TRAN_COMMENT])
     SELECT
	   new.PRODUCT_CODE
      ,new.LAST_HIST_SEQ
      ,s.LOT_ID
      ,s.LAST_HIST_SEQ
      ,s.LOT_QTY
      ,s.STORE_CODE
      ,s.LAST_TRAN_TIME
      ,s.LAST_TRAN_CODE
      ,s.PRODUCT_CODE
      ,s.OPERATION_CODE
      ,s.END_EQUIPMENT_CODE
      ,s.LAST_TRAN_USER_ID
      ,s.LAST_TRAN_COMMENT
	  FROM LOT_STS s, (SELECT
	   lot.PRODUCT_CODE
      ,lot.LAST_HIST_SEQ
	  FROM LOT_STS lot
	  left join BOM_MST bom on bom.PRODUCT_CODE = lot.PRODUCT_CODE
	  WHERE lot.LOT_ID=@BOM_LOT_ID_2) new
	  WHERE s.LOT_ID=@LOT_ID

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
                if (updateVO.OPERATION_CODE=="1100")
                {
                    sql = sql_oper_1100;
                }
                else
                {
                    if (updateVO.BOM_LOT_ID_2 == null) sql = sql_item_1; // bom item list 1
                    else sql = sql_item_2;
                }


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", updateVO.LOT_ID); //product LOT_ID

                    cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", updateVO.LAST_TRAN_USER_ID);//

                    cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", updateVO.LAST_TRAN_COMMENT);

                    cmd.Parameters.AddWithValue("@LOT_QTY", updateVO.LOT_QTY);
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", updateVO.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@PRODUCT_NAME", updateVO.PRODUCT_NAME);

                    cmd.Parameters.AddWithValue("@BOM_LOT_ID_1", updateVO.BOM_LOT_ID_1);
                    cmd.Parameters.AddWithValue("@BOM_LOT_QTY_1", updateVO.BOM_LOT_QTY_1);
                    cmd.Parameters.AddWithValue("@BOM_CHILD_ID_1", updateVO.BOM_CHILD_ID_1);
                    cmd.Parameters.AddWithValue("@BOM_LOT_ID_2", updateVO.BOM_LOT_ID_2);
                    cmd.Parameters.AddWithValue("@BOM_CHILD_ID_2", updateVO.BOM_CHILD_ID_2);

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

        public void Dispose()
        {
            conn.Close();
        }
    }
}

