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

		public List<DefectProperty> GetData()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				

				cmd.CommandText = @"select CONVERT(varchar,TRAN_TIME,23) TRAN_DATE,PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE, sum(DEFECT_QTY) as DEFECT_QTY
from LOT_DEFECT_HIS
group by  CONVERT(varchar,TRAN_TIME,23),PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE";

				cmd.Connection.Open();

				List<DefectProperty> list = Helper.DataReaderMapToList<DefectProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;
			}
		}

		public List<DefectProperty> GetSearch(string from ,string to,string product,string op_code)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				StringBuilder sb = new StringBuilder();
				sb.Append(@"select CONVERT(varchar,TRAN_TIME,23) TRAN_DATE,PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE, sum(DEFECT_QTY) as DEFECT_QTY
from LOT_DEFECT_HIS");

				if (!string.IsNullOrWhiteSpace(product))
				{
					sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE");
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", product);
				}
				if (!string.IsNullOrWhiteSpace(op_code))
				{
					sb.Append(" and OPERATION_CODE and @PRODOPERATION_CODEUCT_CODE");
					cmd.Parameters.AddWithValue("@OPERATION_CODE", op_code);
				}
				if (!string.IsNullOrWhiteSpace(from) && !string.IsNullOrWhiteSpace(to))
				{
					sb.Append("");
					cmd.Parameters.AddWithValue("@from", from);
					cmd.Parameters.AddWithValue("@to",to);

				}
				//if (from != null & to != null)  
				//{
				//	sb.Append(" 
				//}
				sb.Append(" group by  CONVERT(varchar,TRAN_TIME,23),PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE");
				cmd.CommandText = sb.ToString();

				List<DefectProperty> list = Helper.DataReaderMapToList<DefectProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;


			}
		}
	}
}