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
	public class StartWorkDAC:IDisposable
	{

		SqlConnection conn;
		public StartWorkDAC()
		{
			//conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();

		}

		public void Dispose()
		{
			conn.Close();
		}

		public DataTable GetCode()
		{
			string sql = "select LOT_ID from LOT_STS";

			using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}

		public List<StarWorkProperty>  GetData(string Code)
		{
			string sql = @"   select lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   where LOT_ID = @LOT_ID";

			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@LOT_ID", Code);

				return Helper.DataReaderMapToList<StarWorkProperty>(cmd.ExecuteReader());
			}
		}
	}
}
