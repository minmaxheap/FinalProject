using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NiceWEB.Models.DAC
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
				cmd.CommandText = @"select LOT_ID, HIST_SEQ, MATERIAL_LOT_ID, MATERIAL_LOT_HIST_SEQ, INPUT_QTY, CHILD_PRODUCT_CODE, MATERIAL_STORE_CODE, TRAN_TIME, 
TRAN_CODE, PRODUCT_CODE, OPERATION_CODE, EQUIPMENT_CODE, TRAN_USER_ID, TRAN_COMMENT 
from LOT_MATERIAL_HIS
-- 조회조건 where 
group by PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE
order by TRAN_TIME desc,PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE";

				return Helper.DataReaderMapToList<Adding_materialProperty>(cmd.ExecuteReader());
			}
		}
			//조회조건을 달아서 
			public List<Adding_materialProperty> GetSearch(DateTime from,DateTime to,string prd_code,string op_code,string child_code)
			{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				cmd.CommandText = @"select LOT_ID, HIST_SEQ, MATERIAL_LOT_ID, MATERIAL_LOT_HIST_SEQ, INPUT_QTY, CHILD_PRODUCT_CODE, MATERIAL_STORE_CODE, TRAN_TIME, 
TRAN_CODE, PRODUCT_CODE, OPERATION_CODE, EQUIPMENT_CODE, TRAN_USER_ID, TRAN_COMMENT 
from LOT_MATERIAL_HIS
-- 조회조건 where 
//where 1=1 
group by PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE
order by TRAN_TIME desc,PRODUCT_CODE,OPERATION_CODE,CHILD_PRODUCT_CODE"; //쿼리 다시 짜기=>이거물어보기 

				//cmd.Parameters.AddWithValue


				return Helper.DataReaderMapToList<Adding_materialProperty>(cmd.ExecuteReader());
			}

			}
		}

	}
