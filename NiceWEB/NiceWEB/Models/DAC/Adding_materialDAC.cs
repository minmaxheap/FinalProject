using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
namespace NiceWEB.Models
{
	public class Adding_materialDAC : IDisposable
	{
		SqlConnection conn;
		public Adding_materialDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}

		//조회만 (원 데이터)
		public List<Adding_materialProperty> GetData()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				cmd.CommandText = @"select convert(varchar,TRAN_TIME,120) as TRAN_TIME,PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE,sum(convert(int,INPUT_QTY)) from LOT_MATERIAL_HIS
group by convert(varchar,TRAN_TIME,120),PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE";

				cmd.Connection.Open();

				List<Adding_materialProperty> list = Helper.DataReaderMapToList<Adding_materialProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;

			}
		}
		//조회조건을 달아서 
		public List<Adding_materialProperty> GetSearch(DateTime from, DateTime to, string prd_code, string op_code, string child_code)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(@"select TRAN_TIME,PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE,sum(convert(int,INPUT_QTY)) from LOT_MATERIAL_HIS");

			using (SqlCommand cmd = new SqlCommand())
			{
				conn.Open();
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				//cmd.CommandText = "";
				if (!string.IsNullOrWhiteSpace(prd_code))
				{
					sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE");
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", prd_code);
				}
				if (!string.IsNullOrWhiteSpace(op_code))
				{
					sb.Append(" and OPERATION_CODE = @OPERATION_CODE");
					cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				}
				if (!string.IsNullOrWhiteSpace(child_code))
				{
					sb.Append(" and CHILD_PRODUCT_CODE = @CHILD_PRODUCT_CODE");
					cmd.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", child_code);
				}
				//datetime일떄는 어찌하냐?
				if (from != null && to != null)
				{
					sb.Append(" and TRAN_TIME BETWEEN @from and @to");
					cmd.Parameters.AddWithValue("@from", from);
					cmd.Parameters.AddWithValue("@to", to);
				}
				sb.Append(" group by convert(varchar,TRAN_TIME,120) as TRAN_TIME,PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE");
				cmd.CommandText = sb.ToString();
				//cmd.Connection = conn;

				List<Adding_materialProperty> list = Helper.DataReaderMapToList<Adding_materialProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;
			}
		}

		//바인딩해줄데이터들 품번,자재품번,공정 => 전부 콤보박스로 
		public List<TableData> GetProduct()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				cmd.CommandText = @"select PRODUCT_CODE as Data from PRODUCT_MST";
				DataTable dt = new DataTable();
				cmd.Connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();
				List<TableData> list = Helper.DataReaderMapToList<TableData>(reader);
				reader.Close();
				return list;
			}
		}

		public List<string> GetChildProduct()
		{
			string sql = "select CHILD_PRODUCT_CODE from LOT_MATERIAL_HIS";
			SqlCommand cmd = new SqlCommand(sql, conn);

			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["CHILD_PRODUCT_CODE"].ToString());

				}
			}
			return List;

		}
		public List<string> GetOperationCode()
		{
			string sql = "select OPERATION_CODE from LOT_MATERIAL_HIS";
			SqlCommand cmd = new SqlCommand(sql, conn);

			List<string> List = new List<string>();
			using (SqlDataReader da = cmd.ExecuteReader())
			{
				while (da.Read())
				{
					List.Add(da["OPERATION_CODE"].ToString());

				}
			}
			return List;

		}
	}
}

