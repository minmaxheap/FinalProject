using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class EndDAC : IDisposable
    {
        SqlConnection conn;
        public EndDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }
        public List<string> GetLotList()
        {
            string sql = @"select LOT_ID, s.PRODUCT_CODE
from LOT_STS s inner
join WORK_ORDER_MST w on s.WORK_ORDER_ID = w.WORK_ORDER_ID
left join OPERATION_MST o  on s.OPERATION_CODE = o.OPERATION_CODE
WHERE  LEFT(s.PRODUCT_CODE, 2) = 'pd' AND ORDER_STATUS<>'CLOSE' and o.CHECK_MATERIAL_FLAG='Y'
 ";
            // AND lot.SHIP_FLAG is null
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<string> List = new List<string>();
            using (SqlDataReader da = cmd.ExecuteReader())
            {
                while (da.Read())
                {
                    List.Add(da["LOT_ID"].ToString());

                }
            }
            return List;
        }
        public List<EndProperty> GetStatusList(EndProperty vo)
        {
            StringBuilder sb = new StringBuilder();
  
            sb.Append(@"select c.DATA_1 CUSTOMER_NAME,lot.LOT_QTY, lot.LOT_DESC,lot.PRODUCT_CODE as PRODUCT_CODE,lot.OPERATION_CODE as OPERATION_CODE,p.PRODUCT_NAME as PRODUCT_NAME,o.OPERATION_NAME, lot.WORK_ORDER_ID, work.CUSTOMER_CODE,work.ORDER_STATUS,work.ORDER_QTY,work.PRODUCT_QTY,work.DEFECT_QTY 
   from LOT_STS lot
   left join WORK_ORDER_MST work on lot.WORK_ORDER_ID = work.WORK_ORDER_ID
   left join PRODUCT_MST p on lot.PRODUCT_CODE = p.PRODUCT_CODE
   left join OPERATION_MST o on lot.OPERATION_CODE = o.OPERATION_CODE
   left join CODE_DATA_MST c on work.CUSTOMER_CODE = c.KEY_1
   where LOT_ID = @LOT_ID");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.LOT_ID))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", vo.LOT_ID);
                }

                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndProperty>(cmd.ExecuteReader());
            }

        }
        public List<EndPropertyUse> GetBomChildList(EndPropertyPrdCode vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT CHILD_PRODUCT_CODE, prod.PRODUCT_NAME CHILD_PRODUCT_NAME, REQUIRE_QTY, sum(LOT_QTY) SUM_QTY
  FROM LOT_STS lot
left join BOM_MST bom on bom.CHILD_PRODUCT_CODE=lot.PRODUCT_CODE
left join PRODUCT_MST prod on prod.PRODUCT_CODE=lot.PRODUCT_CODE

  WHERE lot.STORE_CODE != 'FS_STORE' AND lot.STORE_CODE is not null
  	AND bom.PRODUCT_CODE=@PRODUCT_CODE
	Group BY CHILD_PRODUCT_CODE,prod.PRODUCT_NAME, REQUIRE_QTY
");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }

                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndPropertyUse>(cmd.ExecuteReader());
            }

        }

        public List<EndProperty> GetRMLotList(EndProperty vo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT LOT_ID, lot.PRODUCT_CODE
  FROM LOT_STS lot
left join BOM_MST bom on bom.CHILD_PRODUCT_CODE=lot.PRODUCT_CODE
left join PRODUCT_MST prod on prod.PRODUCT_CODE=lot.PRODUCT_CODE

  WHERE lot.STORE_CODE != 'FS_STORE' AND lot.STORE_CODE is not null
  	AND bom.PRODUCT_CODE=@LOT_ID AND CHILD_PRODUCT_CODE=@PRODUCT_CODE ");
            // AND lot.SHIP_FLAG is null
            using (SqlCommand cmd = new SqlCommand())
            {
                if (!string.IsNullOrWhiteSpace(vo.LOT_ID))
                {
                    cmd.Parameters.AddWithValue("@LOT_ID", vo.LOT_ID);
                }
                if (!string.IsNullOrWhiteSpace(vo.PRODUCT_CODE))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                }
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;

                return Helper.DataReaderMapToList<EndProperty>(cmd.ExecuteReader());
            }

        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}

