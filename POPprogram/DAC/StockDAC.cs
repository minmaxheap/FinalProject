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

