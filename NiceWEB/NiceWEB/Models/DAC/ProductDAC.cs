using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCShoppingMall.Models;

namespace NiceWEB.Models
{
    public class ProductDAC : IDisposable
    {
        SqlConnection conn;

        public ProductDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public List<Product> GetProducts(int page, int pageSize, string category)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "GetProductList";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PAGE_NO", page); 
                cmd.Parameters.AddWithValue("@PAGE_SIZE", pageSize);

                //DB에 null값을 전달하려면, DBNull.Value
                cmd.Parameters.AddWithValue("@CATEGORY", 
                    (category.Length > 0) ? (object)category : DBNull.Value);

                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> list = Helper.DataReaderMapToList<Product>(reader);
                reader.Close();
                return list;
            }
        }

        public List<string> GetCategoryList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                List<string> list = new List<string>();

                cmd.Connection = conn;
                cmd.CommandText = "select distinct Category from Products";

                SqlDataReader reader = cmd.ExecuteReader();                
                while(reader.Read())
                {
                    list.Add(reader["Category"].ToString());
                }
                return list;
            }
        }

        public int GetProductTotalCount(string category)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from Products where 1=1 ";

                if (category.Length > 0)
                {
                    cmd.CommandText += " and Category = @category";
                    cmd.Parameters.AddWithValue("@category", category);
                }

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Product GetProductInfo(int proID)
        {
            string sql = @"select Name, Price, Category, ProductID 
from Products
where ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", proID);

                List<Product> list = Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());

                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return null;

                //SqlDataReader reader = cmd.ExecuteReader();
                //if (reader.Read())
                //{
                //    return new Product
                //    {
                //        ProductID = Convert.ToInt32(reader["ProductID"]),
                //        Name = reader["Name"].ToString(),
                //        Price = Convert.ToInt32(reader["Price"]),
                //        Category = reader["Category"].ToString()
                //    };
                //}
                //else
                //{
                //    return null;
                //}
            }
        }


        public List<OrderStat> GetChartData(string from, string to)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
                cmd.CommandText = "Best3ProductMonthAmt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);

                cmd.Connection.Open();
                List<OrderStat> list = Helper.DataReaderMapToList<OrderStat>(cmd.ExecuteReader());
                cmd.Connection.Close();

                return list;
            }
        }
    }
}