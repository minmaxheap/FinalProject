﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class ProductDAC : IDisposable
    {
        SqlConnection conn;

        public ProductDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }

        public DataTable GetProductsList()
        {
            string sql = @"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[PRODUCT_MST]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(ProductVO vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[PRODUCT_MST]
           ([PRODUCT_CODE]
           ,[PRODUCT_NAME]
           ,[PRODUCT_TYPE]
           ,[CUSTOMER_CODE]
           ,[VENDOR_CODE]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID]
        )
     VALUES
           (@PRODUCT_CODE,
            @PRODUCT_NAME,
            @PRODUCT_TYPE,
            @CUSTOMER_CODE,
            @VENDOR_CODE,
            getdate(),
            @CREATE_USER_ID
    ) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@PRODUCT_NAME", vo.PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@PRODUCT_TYPE", vo.PRODUCT_TYPE);
                    cmd.Parameters.AddWithValue("@CUSTOMER_CODE", vo.CUSTOMER_CODE);
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", vo.VENDOR_CODE);
                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    int row = cmd.ExecuteNonQuery();
                    return row > 0;

                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message); //log에 찍게 해야하나?
                return false;
            }
        }

        public bool Delete(ProductVO vo)
        {
            try
            {
                string sql = @"delete from [dbo].[PRODUCT_MST]
where PRODUCT_CODE = @PRODUCT_CODE ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", vo.PRODUCT_CODE);
                    int row = cmd.ExecuteNonQuery();
                    return row > 0;

                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
