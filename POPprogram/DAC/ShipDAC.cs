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
  WHERE w.PRODUCT_CODE=pm.PRODUCT_CODE AND w.CUSTOMER_CODE=cd.KEY_1";
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
      ,lot.LOT_QTY
      ,OPER_IN_TIME
  FROM (SELECT lot.PRODUCT_CODE 
      ,sum(LOT_QTY) LOT_QTY
  FROM LOT_STS lot, SALES_ORDER_MST s 
  WHERE 1=1 AND STORE_CODE='FS_STORE' and lot.PRODUCT_CODE =@PRODUCT_CODE
  group by lot.PRODUCT_CODE) as new, LOT_STS lot, SALES_ORDER_MST s
  WHERE 1=1 AND STORE_CODE='FS_STORE' and lot.PRODUCT_CODE =@PRODUCT_CODE
  and new.LOT_QTY>=s.ORDER_QTY");


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
        public void Dispose()
        {
            conn.Close();
        }
    }
}

