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
    }
}
