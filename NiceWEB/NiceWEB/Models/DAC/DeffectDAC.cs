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
	public class DeffectDAC
	{
		SqlConnection conn;
		public DeffectDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}

		public List<DeffectProperty> GetData()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
				

				cmd.CommandText = @"select CONVERT(varchar,TRAN_TIME,23) TRAN_DATE,PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE, sum(DEFECT_QTY) as DEFECT_QTY
from LOT_DEFECT_HIS
group by  CONVERT(varchar,TRAN_TIME,23),PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE";

				cmd.Connection.Open();

				List<DeffectProperty> list = Helper.DataReaderMapToList<DeffectProperty>(cmd.ExecuteReader());
				cmd.Connection.Close();
				return list;
			}
		}
	}
}