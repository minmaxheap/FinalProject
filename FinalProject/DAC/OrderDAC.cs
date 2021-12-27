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
    public class OrderDAC : IDisposable
    {
        SqlConnection conn;

        public OrderDAC()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            conn.Open();

        }
        public DataTable GetOrderList()
        {
            string sql = @"select STORE_CODE, STORE_NAME, STORE_TYPE, FIFO_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from [dbo].[STORE_MST]";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(ProductProperty vo)
        {
            try
            {
                string sql = @"INSERT INTO [dbo].[STORE_MST]
           ([STORE_CODE]
           ,[STORE_NAME]
           ,[STORE_TYPE]
           ,[FIFO_FLAG]
           ,[CREATE_TIME]
           ,[CREATE_USER_ID]
           ,[UPDATE_TIME]
           ,[UPDATE_USER_ID]
        )
     VALUES
           (@STORE_CODE,
            @STORE_NAME,
            @STORE_TYPE,
            @FIFO_FLAG,
            @CREATE_TIME,
            @CREATE_USER_ID,
            @UPDATE_TIME,
            @UPDATE_USER_ID,
    ) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@STORE_CODE", vo.STORE_CODE);
                    cmd.Parameters.AddWithValue("@STORE_NAME", vo.STORE_NAME);
                    cmd.Parameters.AddWithValue("@STORE_TYPE", vo.STORE_TYPE);
                    cmd.Parameters.AddWithValue("@FIFO_FLAG", vo.FIFO_FLAG);
                    cmd.Parameters.AddWithValue("@CREATE_TIME", vo.CREATE_TIME);
                    cmd.Parameters.AddWithValue("@CREATE_USER_ID", vo.CREATE_USER_ID);
                    cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
                    cmd.Parameters.AddWithValue("@UPDATE_USER_ID", vo.UPDATE_USER_ID);
                    //cmd.Parameters.AddWithValue("@CREATE_TIME",vo.CREATE_TIME);
                    //cmd.Parameters.AddWithValue("@UPDATE_TIME", vo.UPDATE_TIME);
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

        public void Dispose()
        {
            conn.Close();
        }
    }

}
