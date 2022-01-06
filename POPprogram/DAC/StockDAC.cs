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
    public class StockDAC : IDisposable
    {
        SqlConnection conn;
        public StockDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        //        public DataTable GetPurchaseList()
        //        {
        //            string sql = @"select PURCHASE_ORDER_ID, SALES_ORDER_ID, ORDER_DATE, O.VENDOR_CODE,V.DATA_1 VENDOR_NAME, MATERIAL_CODE,  P.PRODUCT_NAME PRODUCT_NAME,ORDER_QTY, STOCK_IN_FLAG, STOCK_IN_STORE_CODE, STOCK_IN_LOT_ID
        //from [dbo].[PURCHASE_ORDER_MST] O, PRODUCT_MST P, CODE_DATA_MST V
        //WHERE  P.PRODUCT_CODE = O.MATERIAL_CODE AND V.CODE_TABLE_NAME ='CM_VENDOR' AND V.KEY_1=O.VENDOR_CODE
        //";
        //            DataTable dt = new DataTable();
        //            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
        //            {
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }
//        public DataTable GetPurchaseList()
//        {
//            string sql = @" select distinct  PURCHASE_ORDER_ID, O.SALES_ORDER_ID, SA.PRODUCT_CODE, PM.PRODUCT_NAME, O.ORDER_DATE, O.VENDOR_CODE,V.DATA_1 VENDOR_NAME, O.ORDER_QTY
//from [dbo].[PURCHASE_ORDER_MST] O, SALES_ORDER_MST SA,PRODUCT_MST P, CODE_DATA_MST V, SALES_ORDER_MST S
//LEFT OUTER JOIN PRODUCT_MST PM ON S.PRODUCT_CODE = PM.PRODUCT_CODE
//WHERE O.SALES_ORDER_ID = SA.SALES_ORDER_ID 
//AND  P.PRODUCT_CODE = O.MATERIAL_CODE AND V.CODE_TABLE_NAME ='CM_VENDOR' AND V.KEY_1=O.VENDOR_CODE
//";
//            DataTable dt = new DataTable();
//            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
//            {
//                da.Fill(dt);
//                return dt;
//            }
//        }

        public DataTable GetPurchaseList()
        {
            string sql = @" select distinct PURCHASE_ORDER_ID, SA.PRODUCT_CODE, PM.PRODUCT_NAME, V.KEY_1 CUSTOMER_CODE, V.DATA_1 CUSTOMER_NAME, sa.ORDER_QTY
from [dbo].[PURCHASE_ORDER_MST] O, SALES_ORDER_MST SA,PRODUCT_MST P, CODE_DATA_MST V, SALES_ORDER_MST S
LEFT OUTER JOIN PRODUCT_MST PM ON S.PRODUCT_CODE = PM.PRODUCT_CODE
WHERE O.SALES_ORDER_ID = SA.SALES_ORDER_ID 
AND  P.PRODUCT_CODE = O.MATERIAL_CODE AND V.CODE_TABLE_NAME ='CM_CUSTOMER' AND V.KEY_1=sa.CUSTOMER_CODE
";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }


        //      public DataTable Purchase_warehousing(string Code)
        //      {
        //          string sql = @" select ROW_NUMBER() over(order by(select 1)) as RowNum,b.CHILD_PRODUCT_CODE,p.PRODUCT_NAME, b.REQUIRE_QTY, (b.REQUIRE_QTY *po.ORDER_QTY) as 수량 ,po.STOCK_IN_LOT_ID
        //from	[dbo].[PURCHASE_ORDER_MST] po 
        //left join [dbo].[PRODUCT_MST] p on po.MATERIAL_CODE = p.PRODUCT_CODE
        //left join [dbo].[BOM_MST] b on p.PRODUCT_CODE = b.PRODUCT_CODE
        // where po.PURCHASE_ORDER_ID = @PURCHASE_ORDER_ID";

        //          using (SqlCommand cmd = new SqlCommand(sql, conn))
        //          {
        //              cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", Code);
        //              SqlDataAdapter da = new SqlDataAdapter(cmd);
        //              DataTable dt = new DataTable();
        //              da.Fill(dt);
        //              return dt;

        //          }

        //      }
        //        public DataTable Purchase_warehousing(string Code, string vendorCode, string prodCode)
        //        {
        //            string sql = @" select ROW_NUMBER() over(order by(select 1)) as RowNum,PURCHASE_ORDER_ID, SALES_ORDER_ID, ORDER_DATE, O.MATERIAL_CODE, 
        // P.PRODUCT_NAME AS MATERIAL_NAME,ORDER_QTY, B.REQUIRE_QTY,b.REQUIRE_QTY * o.ORDER_QTY QTY, STOCK_IN_FLAG, STOCK_IN_STORE_CODE, STOCK_IN_LOT_ID
        //from [dbo].[PURCHASE_ORDER_MST] O, PRODUCT_MST P, CODE_DATA_MST V, BOM_MST B
        //WHERE  P.PRODUCT_CODE = O.MATERIAL_CODE AND V.CODE_TABLE_NAME ='CM_VENDOR' AND V.KEY_1=O.VENDOR_CODE and o.VENDOR_CODE =@VENDOR_CODE and o.PURCHASE_ORDER_ID = @PURCHASE_ORDER_ID
        // AND B.CHILD_PRODUCT_CODE = O.MATERIAL_CODE and b.PRODUCT_CODE=@PRODUCT_CODE
        //";

        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", Code);
        //                cmd.Parameters.AddWithValue("@VENDOR_CODE", vendorCode);
        //                cmd.Parameters.AddWithValue("@PRODUCT_CODE", prodCode);
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                return dt;

        //            }

        //        }

        public DataTable Purchase_warehousing(string Code)
        {
            string sql = @"with BOM as
(
    select CHILD_PRODUCT_CODE,[PRODUCT_CODE] , REQUIRE_QTY, 0 levels
	from BOM_MST 
	where PRODUCT_CODE = @PRODUCT_CODE
       union all
	select A.CHILD_PRODUCT_CODE, A.[PRODUCT_CODE], A.REQUIRE_QTY, (b.levels + 1) levels
	from BOM_MST A join BOM B on A.[PRODUCT_CODE] = B.CHILD_PRODUCT_CODE
)
select ROW_NUMBER() over(order by(select 1)) as RowNum, b.CHILD_PRODUCT_CODE AS MATERIAL_CODE, P.PRODUCT_NAME AS MATERIAL_NAME, B.REQUIRE_QTY, (b.REQUIRE_QTY*m.ORDER_QTY) QTY,STOCK_IN_FLAG, STOCK_IN_STORE_CODE, STOCK_IN_LOT_ID,  B.PRODUCT_CODE, levels
from bom b 
join PRODUCT_MST P on b.CHILD_PRODUCT_CODE = P.PRODUCT_CODE
join PURCHASE_ORDER_MST M on m.MATERIAL_CODE = b.CHILD_PRODUCT_CODE
";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", Code);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }

        }


        public List<string> GetStore_Code()
        {
            string sql = "select STORE_CODE FROM [dbo].STORE_MST";

            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> List = new List<string>();
            using (SqlDataReader da = cmd.ExecuteReader())
            {
                while (da.Read())
                {
                    List.Add(da["STORE_CODE"].ToString());

                }
            }
            return List;
        }

        public bool SaveStockLot(List<string> lotlist, string storeID, string msUserID)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                foreach(string lotId in lotlist)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @" UPDATE LOT_STS SET 
                            STORE_CODE =@STORE_CODE, PRODUCTION_TIME = getdate(),
                            CREATE_TIME=getdate(),OPER_IN_TIME=getdate(), 
                            LAST_TRAN_CODE = 'move' , LAST_TRAN_TIME = getdate(),
                            LAST_TRAN_USER_ID = @LAST_TRAN_USER_ID, 
                            LAST_TRAN_COMMENT = @LAST_TRAN_COMMENT, 
                            LAST_HIST_SEQ = LAST_HIST_SEQ+1
                            where LOT_ID = @LOT_ID";

                        cmd.Parameters.AddWithValue("@LOT_ID", lotId);
                        cmd.Parameters.AddWithValue("@STORE_CODE", storeID);
                        cmd.Parameters.AddWithValue("@LAST_TRAN_USER_ID", msUserID);
                        cmd.Parameters.AddWithValue("@LAST_TRAN_COMMENT", "자재 LOT 창고 이동");

                        cmd.Transaction = trans;

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"insert LOT_HIS
(LOT_ID, LOT_DESC, PRODUCT_CODE, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY, 
PRODUCTION_TIME, CREATE_TIME, OPER_IN_TIME, TRAN_CODE, TRAN_TIME, TRAN_USER_ID, TRAN_COMMENT,HIST_SEQ,
OLD_PRODUCT_CODE,OLD_OPERATION_CODE,OLD_LOT_QTY)
select 
s.LOT_ID ,s.LOT_DESC ,s.PRODUCT_CODE, @STORE_CODE, s.LOT_QTY, s.CREATE_QTY, s.OPER_IN_QTY,
s.PRODUCTION_TIME, s.CREATE_TIME,s.OPER_IN_TIME, s.LAST_TRAN_CODE, s.LAST_TRAN_TIME, s.LAST_TRAN_USER_ID, s.LAST_TRAN_COMMENT, s.LAST_HIST_SEQ,
h.PRODUCT_CODE, h.OPERATION_CODE, h.LOT_QTY
from LOT_STS S left join LOT_HIS h on s.LOT_ID = h.LOT_ID
where s.LOT_ID =@LOT_ID and h.HIST_SEQ = s.LAST_HIST_SEQ-1";

                        cmd.Parameters.AddWithValue("@LOT_ID", lotId);
                        cmd.Parameters.AddWithValue("@STORE_CODE", storeID);
                        cmd.Transaction = trans;

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "update PURCHASE_ORDER_MST set STOCK_IN_FLAG=@STOCK_IN_FLAG where STOCK_IN_LOT_ID = @STOCK_IN_LOT_ID";

                        cmd.Parameters.AddWithValue("@STOCK_IN_FLAG", "Y");
                        cmd.Parameters.AddWithValue("@STOCK_IN_LOT_ID", lotId);
                        cmd.Transaction = trans;

                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                return true;
            }
            catch(Exception err)
            {
                trans.Rollback();
                return false;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}

