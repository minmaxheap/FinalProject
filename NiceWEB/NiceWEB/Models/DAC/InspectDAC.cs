using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace NiceWEB.Models
{
    public class InspectDAC : IDisposable
    {
        SqlConnection conn;
        public InspectDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        public DataTable GetData(string from, string to,  string prdCode, string operCode, string lotID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                StringBuilder sb = new StringBuilder();

                sb.Append(@" SELECT TRAN_TIME,LOT_ID,  H.PRODUCT_CODE, PRODUCT_NAME, H.OPERATION_CODE, OPERATION_NAME, INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, 
 SPEC_LSL, SPEC_TARGET, SPEC_USL, INSPECT_VALUE,  TRAN_CODE,TRAN_USER_ID
 FROM [dbo].[LOT_INSPECT_HIS] H, PRODUCT_MST P, OPERATION_MST O
 WHERE H.PRODUCT_CODE = P.PRODUCT_CODE AND H.OPERATION_CODE = O.OPERATION_CODE
 ORDER BY TRAN_TIME, LOT_ID");

                if (!(string.IsNullOrWhiteSpace(from)) && !(string.IsNullOrWhiteSpace(to)))
                {
                    sb.Append(" and ");
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                }

                if (!(string.IsNullOrWhiteSpace(operCode)))
                {
                    sb.Append(" and ");
                    cmd.Parameters.AddWithValue("@operCode", operCode);
                }

                if (!(string.IsNullOrWhiteSpace(lotID)))
                {
                    sb.Append(" and ");
                    cmd.Parameters.AddWithValue("@lotID", lotID);
                }


                cmd.CommandText = sb.ToString();

                DataTable dt = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();

                //List<StoreProperty> list = Helper.DataReaderMapToList<StoreProperty>(cmd.ExecuteReader());
                //return list;



                return dt;
            }
        }
    
    }
}