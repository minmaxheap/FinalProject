using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
    public class ComparePlanDAC
    {
        public List<string> GetChartData(string from, string to)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["order"].ConnectionString);
                cmd.CommandText = "Best3ProductMonthAmt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);

                cmd.Connection.Open();
                List<string> list = Helper.DataReaderMapToList<string>(cmd.ExecuteReader());
                cmd.Connection.Close();

                return list;
            }
        }
    }
}