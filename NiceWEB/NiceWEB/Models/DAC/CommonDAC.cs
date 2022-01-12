﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NiceWEB.Models
{
    public class CommonDAC : IDisposable
    {
        SqlConnection conn;
        public CommonDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
    

        public List<TableData> GetWorkOrder()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT WORK_ORDER_ID as Data
FROM [dbo].[WORK_ORDER_MST]";
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<TableData> list = Helper.DataReaderMapToList<TableData>(reader);
                reader.Close();
                return list;
            }
        }

        public List<TableData> GetProductCode()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
                cmd.CommandText = @"SELECT DISTINCT PRODUCT_CODE as Data
FROM [dbo].[WORK_ORDER_MST]";
                DataTable dt = new DataTable();
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<TableData> list = Helper.DataReaderMapToList<TableData>(reader);
                reader.Close();
                return list;
            }
        }
    }
}