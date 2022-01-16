using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;

namespace NiceWEB.Models.DAC
{
	public class DefectDAC
	{
		SqlConnection conn;
		public DefectDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}

		public List<DefectProperty> GetData(string from, string to,string productCode,string op_code, int page, int pagesize)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = "SP_DEFFECT";
				cmd.CommandType = CommandType.StoredProcedure;

				if (!string.IsNullOrWhiteSpace(productCode))
				{
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
				}
				else
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", DBNull.Value);
				if (!string.IsNullOrWhiteSpace(op_code))
				{
					cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				}
				else
				cmd.Parameters.AddWithValue("@OPERATION_CODE", DBNull.Value);

				if (!string.IsNullOrWhiteSpace(from))
					cmd.Parameters.AddWithValue("@from", from);
				else
					cmd.Parameters.AddWithValue("@from", DBNull.Value);

				if(!string.IsNullOrWhiteSpace(to))
					cmd.Parameters.AddWithValue("@to", to);
				else
					cmd.Parameters.AddWithValue("@to", DBNull.Value);


				cmd.Parameters.AddWithValue("@PAGE_NO", page);
				cmd.Parameters.AddWithValue("@PAGE_SIZE", pagesize);

				SqlDataReader reader = cmd.ExecuteReader();

				List<DefectProperty> list = Helper.DataReaderMapToList<DefectProperty>(reader);
				reader.Close();
				return list;
			}
		}


		public int GetProductTotalCount(string from, string to, string productCode, string op_code)
		{
			using (SqlCommand cmd = new SqlCommand())
			{

				cmd.Connection = conn;
				StringBuilder sb = new StringBuilder();
				sb.Append(@"SELECT COUNT(*) FROM LOT_DEFECT_HIS where 1=1 ");
				if (!string.IsNullOrWhiteSpace(productCode))
				{
					sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE ");
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
				}
				if (!string.IsNullOrWhiteSpace(productCode))
				{
					sb.Append(" and OPERATION_CODE = @OPERATION_CODE");
					cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				}
				//datetime을 어떻게 두면좋을까?
				if (from != null && to != null)
				{
					sb.Append(" and TRAN_TIME between @from and @to ");
					cmd.Parameters.AddWithValue("@from", from);
					cmd.Parameters.AddWithValue("@to", to);
				}
				
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