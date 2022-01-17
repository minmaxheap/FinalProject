using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using NiceWEB.Models;

namespace NiceWEB.Models.DAC
{
	public class StockDAC:IDisposable
	{
		SqlConnection conn;
		public StockDAC()
		{

			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}


		public List<Product> GetData(string opCode, string productCode,int page,int pagesize)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				StringBuilder sb = new StringBuilder();
				cmd.Connection = conn;
				cmd.CommandText = @"select  LOT_ID, LOT_DESC, PRODUCT_CODE, OPERATION_CODE, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY, START_FLAG, START_QTY, START_TIME, START_EQUIPMENT_CODE, END_FLAG, END_TIME, END_EQUIPMENT_CODE, SHIP_FLAG, SHIP_CODE, SHIP_TIME, PRODUCTION_TIME, CREATE_TIME, OPER_IN_TIME, WORK_ORDER_ID, LOT_DELETE_FLAG, LOT_DELETE_CODE, LOT_DELETE_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME, LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ
from
(
select LOT_ID, LOT_DESC, PRODUCT_CODE, OPERATION_CODE, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY, START_FLAG, START_QTY, START_TIME, START_EQUIPMENT_CODE, END_FLAG, END_TIME, END_EQUIPMENT_CODE, SHIP_FLAG, SHIP_CODE, SHIP_TIME, PRODUCTION_TIME, CREATE_TIME, OPER_IN_TIME, WORK_ORDER_ID, LOT_DELETE_FLAG, LOT_DELETE_CODE, LOT_DELETE_TIME, LAST_TRAN_CODE, LAST_TRAN_TIME, LAST_TRAN_USER_ID, LAST_TRAN_COMMENT, LAST_HIST_SEQ,
row_number() over(order by CONVERT(varchar,LOT_ID ,120)) as RowNum
from LOT_STS
where LOT_DELETE_FLAG is null and (OPERATION_CODE is not null or PRODUCT_CODE is not null) 
and (@OPERATION_CODE is null or OPERATION_CODE = @OPERATION_CODE) and(@PRODUCT_CODE is null  or PRODUCT_CODE  = @PRODUCT_CODE)
)A
where RowNum between ((@PAGE_NO - 1) * @PAGE_SIZE) + 1 and (@PAGE_NO * @PAGE_SIZE)
order by OPERATION_CODE, START_FLAG DESC, LOT_ID";


				if (!string.IsNullOrWhiteSpace(opCode))
				{
					cmd.Parameters.AddWithValue("@OPERATION_CODE", opCode);
				}
				else
					cmd.Parameters.AddWithValue("@OPERATION_CODE", DBNull.Value);

				if (!string.IsNullOrWhiteSpace(productCode))
				{
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
				}
				else
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);

				cmd.Parameters.AddWithValue("@PAGE_NO", page);
				cmd.Parameters.AddWithValue("@PAGE_SIZE", pagesize);


				SqlDataReader reader = cmd.ExecuteReader();

				List<Product> list = Helper.DataReaderMapToList<Product>(reader);
				reader.Close();
				return list;
			}
		}

		public int GetProductTotalCount(string op_code , string productCode)
		{
			using (SqlCommand cmd = new SqlCommand())
			{

				cmd.Connection = conn;
				StringBuilder sb = new StringBuilder();
				sb.Append(@"SELECT COUNT(*) FROM LOT_STS where LOT_DELETE_FLAG is null and (OPERATION_CODE is not null or PRODUCT_CODE is not null) ");

				if (!string.IsNullOrWhiteSpace(op_code))
				{
					sb.Append(" and OPERATION_CODE = @OPERATION_CODE");
					cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				}
				if (!string.IsNullOrWhiteSpace(productCode))
				{
					sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE ");
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
				}
				
				//datetime을 어떻게 두면좋을까?

				cmd.CommandText = sb.ToString();

				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}

		public List<ComboItem> GetProduct()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = @"select distinct PRODUCT_CODE as Code from PRODUCT_MST";

				SqlDataReader reader = cmd.ExecuteReader();
				List<ComboItem> list = Helper.DataReaderMapToList<ComboItem>(reader);
				reader.Close();

				return list;

			}
		}

		public List<ComboItem> GetOperation()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = @"select distinct OPERATION_CODE as Code from OPERATION_MST";

				SqlDataReader reader = cmd.ExecuteReader();
				List<ComboItem> list = Helper.DataReaderMapToList<ComboItem>(reader);
				reader.Close();

				return list;

			}
		}
	}
}