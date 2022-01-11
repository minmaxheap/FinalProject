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
	public class StoreDAC
	{
		SqlConnection conn;
		public StoreDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}
		public List<StoreProperty> GetData()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				//cmd.CommandText = @"select convert(varchar,TRAN_TIME,120) as TRAN_TIME,PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE,sum(convert(int,INPUT_QTY)) from LOT_MATERIAL_HIS
				//group by convert(varchar,TRAN_TIME,120),PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE";

				cmd.CommandText = @"select CONVERT(varchar,OPER_IN_TIME,120) as OPER_IN_TIME,LOT_ID,PRODUCT_CODE,STORE_CODE,LOT_QTY from LOT_STS
where LOT_DELETE_FLAG <> 'y'and STORE_CODE is not  null
order by STORE_CODE,OPER_IN_TIME,LOT_ID";

				cmd.Connection.Open();

				List<StoreProperty> list = Helper.DataReaderMapToList<StoreProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;
			}
		}
		public List<string> GetProductCode()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				List<string> list = new List<string>();
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				cmd.CommandText = @"SELECT DISTINCT PRODUCT_CODE as Data
FROM [dbo].[WORK_ORDER_MST]";
				
				cmd.Connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					list.Add(reader["Data"].ToString());
				}

				reader.Close();
				return list;
			}
		}
	}
}