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
    public class StockDAC : IDisposable
    {
        SqlConnection conn;
        public StockDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public DataTable GetPurchaseList()
        {
            string sql = @"select PURCHASE_ORDER_ID, SALES_ORDER_ID, ORDER_DATE, O.VENDOR_CODE,V.DATA_1 VENDOR_NAME, MATERIAL_CODE,  P.PRODUCT_NAME PRODUCT_NAME,ORDER_QTY, STOCK_IN_FLAG, STOCK_IN_STORE_CODE, STOCK_IN_LOT_ID
from [dbo].[PURCHASE_ORDER_MST] O, PRODUCT_MST P, CODE_DATA_MST V
WHERE  P.PRODUCT_CODE = O.MATERIAL_CODE AND V.CODE_TABLE_NAME ='CM_VENDOR' AND V.KEY_1=O.VENDOR_CODE
";
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

        public DataTable Purchase_warehousing(string Code)
        {
            string sql = @" select ROW_NUMBER() over(order by(select 1)) as RowNum,b.CHILD_PRODUCT_CODE,p.PRODUCT_NAME, b.REQUIRE_QTY, (b.REQUIRE_QTY *po.ORDER_QTY) as 수량 ,po.STOCK_IN_LOT_ID
  from	[dbo].[PURCHASE_ORDER_MST] po 
  left join [dbo].[PRODUCT_MST] p on po.MATERIAL_CODE = p.PRODUCT_CODE
  left join [dbo].[BOM_MST] b on p.PRODUCT_CODE = b.PRODUCT_CODE
   where po.PURCHASE_ORDER_ID =@po.PURCHASE_ORDER_ID";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@po.PURCHASE_ORDER_ID", Code);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }

        }
    }
}

