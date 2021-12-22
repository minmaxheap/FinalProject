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
    public class OrderDAC : IDisposable
    {
        SqlConnection conn;

        public OrderDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }
        public DataTable GetOrderList()
        {
            string sql = @"select SALES_ORDER_ID, ORDER_DATE, CUSTOMER_CODE, PRODUCT_CODE, ORDER_QTY, CONFIRM_FLAG, SHIP_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[SALES_ORDER_MST]";
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
