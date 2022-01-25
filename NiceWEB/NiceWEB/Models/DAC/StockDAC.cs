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
				cmd.CommandText = @"select DISTINCT LOT_ID, LOT_DESC, PRODUCT_CODE, OPERATION_CODE, LOT_QTY, START_FLAG, START_TIME, START_EQUIPMENT_CODE
from
(
select s.LOT_ID, LOT_DESC, s.PRODUCT_CODE, m.OPERATION_CODE, LOT_QTY, START_FLAG, START_TIME, START_EQUIPMENT_CODE,
row_number() over(order by START_FLAG DESC) as RowNum
from LOT_STS S
right join LOT_MATERIAL_HIS m on s.LOT_ID = m.LOT_ID
where LOT_DELETE_FLAG is null and LOT_DELETE_FLAG <> 'Y' and (M.OPERATION_CODE is not null or S.PRODUCT_CODE is not null)
and m.OPERATION_CODE = isnull(@OPERATION_CODE,m.OPERATION_CODE) and m.PRODUCT_CODE = isnull(@PRODUCT_CODE, m.PRODUCT_CODE)
)A
where RowNum between ((@PAGE_NO - 1) * @PAGE_SIZE) + 1 and (@PAGE_NO * @PAGE_SIZE)
order by OPERATION_CODE, START_FLAG DESC, A.LOT_ID 
";


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
				sb.Append(@"SELECT COUNT(*) from LOT_STS S
right join LOT_MATERIAL_HIS m on s.LOT_ID = m.LOT_ID
where s.LOT_DELETE_FLAG is null and (m.OPERATION_CODE is not null or m.PRODUCT_CODE is not null) ");

				if (!string.IsNullOrWhiteSpace(op_code))
				{
					sb.Append(" and m.OPERATION_CODE = @OPERATION_CODE");
					cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				}
				if (!string.IsNullOrWhiteSpace(productCode))
				{
					sb.Append(" and m.PRODUCT_CODE = @PRODUCT_CODE ");
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
				cmd.CommandText = @"select distinct PRODUCT_CODE as Code from PRODUCT_MST
where PRODUCT_CODE<> 'HB_Mixed'and PRODUCT_TYPE = 'FERT'";

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