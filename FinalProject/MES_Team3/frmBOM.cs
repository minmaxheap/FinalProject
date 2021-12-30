﻿using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmBOM : MES_Team3.BaseForms.Base4_1
    {
        DataTable mdtAll;
        //string msUserID;
        //List<int> iSearchedList;
        //List<int> iSelectedRow;

        public frmBOM()
        {
            InitializeComponent();
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");
            //iSearchedList = new List<int>();
            //iSelectedRow = new List<int>();


            DataGridViewUtil.SetInitGridView(csDataGridView2);
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "자 품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "자 품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "단위 수량", "PRODUCT_TYPE");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView2, "대체 품번", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = false;
            //pgProperty.SelectedObject = vo;

            //pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void LoadData()
        {
            ProductServ serv = new ProductServ();
            mdtAll = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = mdtAll;
            csDataGridView1.Focus();


            ProductProperty search = new ProductProperty();
            search.IsSearchPanel = true;
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            //csDataGridView1.Rows[0].Selected = true;
        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {
            if (pgSearch.SelectedObject != null)
            {
                ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
                ProductServ serv = new ProductServ();
                List<ProductProperty> list = serv.GetProductSearch(search);
                search.IsSearchPanel = false;

                csDataGridView1.DataSource = null;
                csDataGridView1.DataSource = list;


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
