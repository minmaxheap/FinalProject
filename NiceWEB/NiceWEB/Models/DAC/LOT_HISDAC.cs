using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using NiceWEB.Models;
namespace NiceWEB.Models.DAC
{
	public class LOT_HISDAC:IDisposable
	{
		SqlConnection conn;
		public LOT_HISDAC()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
			conn.Open();
		}
		public void Dispose()
		{
			conn.Dispose();
		}
		public List<LOT_HIS> GetData(string LotID,int page,int pagesize)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				StringBuilder sb = new StringBuilder();
				cmd.Connection = conn;
				cmd.CommandText = @"select HIST_SEQ,CONVERT(CHAR(19),TRAN_TIME,20) AS TRAN_TIME,TRAN_CODE, LOT_DESC, PRODUCT_CODE,OPERATION_NAME, STORE_CODE, LOT_QTY, CREATE_QTY, OPER_IN_QTY,  START_QTY, convert(char(19),START_TIME,20) as START_TIME, START_EQUIPMENT_CODE
	from 
(
	select HIST_SEQ,CONVERT(CHAR(19),TRAN_TIME,20) AS TRAN_TIME,TRAN_CODE, LOT_DESC, PRODUCT_CODE,o.OPERATION_NAME, STORE_CODE,LOT_QTY, CREATE_QTY, OPER_IN_QTY,START_QTY, convert(char(19),START_TIME,20) as START_TIME, START_EQUIPMENT_CODE,
	row_number() over(order by HIST_SEQ desc) as RowNum
	from LOT_HIS L left join OPERATION_MST o on l.OPERATION_CODE = o.OPERATION_CODE
	where 1=1 and LOT_ID = iSNULL(@LOT_ID,LOT_ID)
) A
where RowNum between ((@PAGE_NO - 1) * @PAGE_SIZE) + 1 and (@PAGE_NO * @PAGE_SIZE)
order by HIST_SEQ desc";
	

				if (!string.IsNullOrWhiteSpace(LotID))
				{
					cmd.Parameters.AddWithValue("@LOT_ID", LotID);
				}
				else
					cmd.Parameters.AddWithValue("@LOT_ID", DBNull.Value);


				cmd.Parameters.AddWithValue("@PAGE_NO", page);
				cmd.Parameters.AddWithValue("@PAGE_SIZE", pagesize);
				

				SqlDataReader reader = cmd.ExecuteReader();

				List<LOT_HIS> list = Helper.DataReaderMapToList<LOT_HIS>(reader);
				reader.Close();
				return list;
			}
		}

		public int GetProductTotalCount(string LotID)
		{
			using (SqlCommand cmd = new SqlCommand())
			{

				cmd.Connection = conn;
				StringBuilder sb = new StringBuilder();
				sb.Append(@"SELECT COUNT(*) FROM LOT_HIS where 1=1");
				if (!string.IsNullOrWhiteSpace(LotID))
				{
					sb.Append(" and LOT_ID = @LOT_ID ");
					cmd.Parameters.AddWithValue("@LOT_ID", LotID);
				}
				
				//sb.Append(" order by STORE_CODE,OPER_IN_TIME,LOT_ID ");
				cmd.CommandText = sb.ToString();
				cmd.CommandText = sb.ToString();

				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}

		public List<ComboItem> GetCode()
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = @"
 select LOT_ID as Code,PRODUCT_CODE
 from LOT_STS
WHERE LEFT(PRODUCT_CODE, 2) = 'pd'";

				SqlDataReader reader = cmd.ExecuteReader();

				List<ComboItem> list = Helper.DataReaderMapToList<ComboItem>(reader);
				reader.Close();
				return list;


			}
		}
	}
}