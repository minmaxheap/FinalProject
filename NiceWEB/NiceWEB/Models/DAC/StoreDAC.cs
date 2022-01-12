﻿using System;
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

				cmd.CommandText = @"
select CONVERT(varchar,OPER_IN_TIME,120) as OPER_IN_TIME,LOT_ID,PRODUCT_CODE,STORE_CODE,LOT_QTY from LOT_STS
where LOT_DELETE_FLAG is null  and STORE_CODE is not  null
order by STORE_CODE,OPER_IN_TIME,LOT_ID";

				cmd.Connection.Open();

				List<StoreProperty> list = Helper.DataReaderMapToList<StoreProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;
			}
		}

		public List<StoreProperty> GetSearch(string store_code, string prdID)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				StringBuilder sb = new StringBuilder();
				sb.Append(@"select CONVERT(varchar,OPER_IN_TIME,120) as OPER_IN_TIME,LOT_ID,PRODUCT_CODE,STORE_CODE,LOT_QTY,LOT_DELETE_FLAG  from LOT_STS
where LOT_DELETE_FLAG <> 'Y' OR LOT_DELETE_FLAG IS NULL  and STORE_CODE is not  null ");
				if (!string.IsNullOrWhiteSpace(store_code))
				{
					sb.Append(" and STORE_CODE = @STORE_CODE ");
					cmd.Parameters.AddWithValue("@STORE_CODE", store_code);
				}
				if (!string.IsNullOrWhiteSpace(prdID))
				{
					sb.Append(" and PRODUCT_CODE = @PRODUCT_CODE ");
					cmd.Parameters.AddWithValue("@PRODUCT_CODE", prdID);
				}
				sb.Append(" order by STORE_CODE,OPER_IN_TIME,LOT_ID ");
				cmd.CommandText = sb.ToString();

				SqlDataReader reader = cmd.ExecuteReader();

				List<StoreProperty> list = Helper.DataReaderMapToList<StoreProperty>(reader);
				  reader.Close();
				return list;
			}
		}

		public List<ComboItem> GetCode()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = @"select STORE_CODE as Code from STORE_MST";

				SqlDataReader reader = cmd.ExecuteReader();
				List<ComboItem> list = Helper.DataReaderMapToList<ComboItem>(reader);
				reader.Close();

				return list;

			}
		}

		public List<ComboItem> GetProductCode()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				cmd.CommandText = @"select PRODUCT_CODE as Code from LOT_STS";

				cmd.Connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();
				List<ComboItem> list = Helper.DataReaderMapToList<ComboItem>(reader);
				reader.Close();

				return list;
			}
		}
	}
}