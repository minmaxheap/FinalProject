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
    public partial class frmProduct : MES_Team3.BaseForms.Base1_1
    {
       DataTable mdtAll;
        string msUserID;
        List<int> iSearchedList;
        List<int> iSelectedRow;
        public frmProduct()
        {
           
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        private void frmProduct1_Load(object sender, EventArgs e)
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
             iSearchedList = new List<int>();
            iSelectedRow = new List<int>();


            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = false;
            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

            BIsSearchPanel = false;
     
        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            //if (save.PRODUCT_TYPE != null)
            //    save.PRODUCT_TYPE = save.PRODUCT_TYPE.Split('(')[0];
            //if (save.CUSTOMER_CODE != null)
            //    save.CUSTOMER_CODE = save.CUSTOMER_CODE.Split('(')[0];
            //if (save.VENDOR_CODE != null)
            //    save.VENDOR_CODE = save.VENDOR_CODE.Split('(')[0];
            save.CREATE_USER_ID = msUserID;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("등록 중 실패하였습니다.");
            }

          
        }


        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0)
            {
                return;
            }
       
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            ProductProperty pr = new ProductProperty();
            BIsSearchPanel = false;
            pr.IsSearchPanel = false;

            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                pr.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_NAME"].Value != null && dr.Cells["PRODUCT_NAME"].Value != DBNull.Value)
                pr.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
            if (dr.Cells["PRODUCT_TYPE"].Value != null && dr.Cells["PRODUCT_TYPE"].Value != DBNull.Value)
                pr.PRODUCT_TYPE = dr.Cells["PRODUCT_TYPE"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                pr.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["VENDOR_CODE"].Value != null && dr.Cells["VENDOR_CODE"].Value != DBNull.Value)
                pr.VENDOR_CODE = dr.Cells["VENDOR_CODE"].Value.ToString();
            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                pr.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
                pr.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                pr.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
                pr.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();


            pgProperty.SelectedObject = pr;

            pgProperty.PropertySort = PropertySort.NoSort;

            pgProperty.Visible = true;


            
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pk를 받아서 delete 하기 //이거 유틸로 할 수 있지 않을까? 

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Delete(save);
            if (bResult)
            {
                MessageBox.Show("삭제되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("삭제 중 실패하였습니다.");
            }

        }

        private void LoadData()
        {
            ProductServ serv = new ProductServ();
             mdtAll = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = mdtAll;
            csDataGridView1.Focus();
            //csDataGridView1.Rows[0].Selected = true;
            BSearchPanel = false;
        }

		private void button3_Click(object sender, EventArgs e)
		{

            ProductProperty search = new ProductProperty();
            search.IsSearchPanel = true;
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            // propertyPanel.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            //if (save.PRODUCT_TYPE != null)
            //    save.PRODUCT_TYPE = save.PRODUCT_TYPE.Split('(')[0];
            //if(save.CUSTOMER_CODE!=null)
            //    save.CUSTOMER_CODE = save.CUSTOMER_CODE.Split('(')[0];
            //if (save.VENDOR_CODE != null)
            //    save.VENDOR_CODE = save.VENDOR_CODE.Split('(')[0];
            save.UPDATE_USER_ID = msUserID;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Update(save);
            if (bResult)
            {
                MessageBox.Show("수정되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("수정 중 실패하였습니다.");
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (pgSearch.SelectedObject != null)
            { ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
                ProductServ serv = new ProductServ();
                List<ProductProperty> list = serv.GetProductSearch(search);
                search.IsSearchPanel = false;

                csDataGridView1.DataSource = null;
                csDataGridView1.DataSource = list;
                    
                   
            }

            //ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
            //var searchList = (from pr in allList
            //                  where (!string.IsNullOrWhiteSpace(search.PRODUCT_CODE)) ? (pr.PRODUCT_CODE == search.PRODUCT_CODE) : 1 == 1
            //                 && (!string.IsNullOrWhiteSpace(search.PRODUCT_TYPE)) ? (pr.PRODUCT_TYPE == search.PRODUCT_TYPE) : 1 == 1
            //                 && (!string.IsNullOrWhiteSpace(search.CUSTOMER_CODE)) ? (pr.CUSTOMER_CODE == search.CUSTOMER_CODE) : 1 == 1
            //                 && (!string.IsNullOrWhiteSpace(search.VENDOR_CODE)) ?) (pr.VENDOR_CODE == search.VENDOR_CODE): 1==1
            //                  select pr
            //                 ).ToList();
            //csDataGridView1.DataSource = null;
            //csDataGridView1.DataSource = searchList;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            if (pgProperty.SelectedGridItem != null)
            {
                PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
                pd.ResetValue(pgProperty.SelectedObject);

                ProductProperty pr = new ProductProperty();
                pr.IsSearchPanel = false;
                pgProperty.SelectedObject = pr;
                pgProperty.PropertySort = PropertySort.NoSort;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            KeyEventArgs enter = new KeyEventArgs(Keys.Enter);

            
            txtSearch_KeyDown(null, enter );


            //if (mbFirst && mbSearch)
            //{

            //    //List<ProductProperty> txtSearch = allList.FindAll((x) => x.PRODUCT_CODE.Contains(txt) || x.PRODUCT_NAME.Contains(txt)||//x.PRODUCT_TYPE.Contains(txt) || x.CUSTOMER_CODE.Contains(txt)||x.VENDOR_CODE.Contains(txt) || x.CREATE_USER_ID.Contains(txt)||//x.UPDATE_USER_ID.Contains(txt));
            //    // csDataGridView1.DataSource = txtSearch;

            //    mFindIndex = new List<int>();
            //    foreach (DataGridViewRow row in csDataGridView1.Rows)
            //    {

            //        if ((row.Cells["PRODUCT_CODE"].Value != null && row.Cells["PRODUCT_CODE"].Value.ToString().ToUpper().Contains(txt)) ||
            //        (row.Cells["PRODUCT_NAME"].Value != null && row.Cells["PRODUCT_NAME"].Value.ToString().ToUpper().Contains(txt)) ||
            //        (row.Cells["PRODUCT_TYPE"].Value != null && row.Cells["PRODUCT_TYPE"].Value.ToString().ToUpper().Contains(txt)) ||
            //        (row.Cells["CUSTOMER_CODE"].Value != null && row.Cells["CUSTOMER_CODE"].Value.ToString().ToUpper().Contains(txt)) ||
            //        (row.Cells["VENDOR_CODE"].Value != null && row.Cells["VENDOR_CODE"].Value.ToString().ToUpper().Contains(txt)) ||
            //        (row.Cells["CREATE_USER_ID"].Value != null && row.Cells["CREATE_USER_ID"].Value.ToString().ToUpper().Contains(txt)) ||
            //        (row.Cells["UPDATE_USER_ID"].Value != null && row.Cells["UPDATE_USER_ID"].Value.ToString().ToUpper().Contains(txt)))
            //        {

            //           // row.Selected = true;
            //            mFindIndex.Add(row.Index);
            //        }
            //        else
            //        {
            //            //row.Selected = false;
            //        }
            //    }
            //    mbFirst = false;

            //    if (mFindIndex == null) { return; }
            //    if (mirowIndex == mFindIndex.Count) { MessageBox.Show("검색한 값이 포함된 마지막 행입니다."); return; }
            //    if (mFindIndex.Count > 0 && mbFirst == false) { mirowIndex = 0; mbFirst = true; }
            //    if (mFindIndex[mirowIndex] == 0)
            //    { csDataGridView1.Rows[0].Selected = false; }
            //    else { csDataGridView1.Rows[mFindIndex[mirowIndex] - 1].Selected = false; }
            //    if (mbFirst)
            //    {

            //        csDataGridView1.Rows[mFindIndex[mirowIndex]].Selected = true;
            //        mirowIndex++;

            //    }
            //    mbFirst = true;
            //    mbSearch = false;
            //}


        }


        private void btnReadTop_Click(object sender, EventArgs e)
        {
            btnReadBottom.PerformClick();
        }

        private void frmProduct_Shown(object sender, EventArgs e)
        {
            csDataGridView1.ClearSelection();// shown이벤트일 때만 clearSelection()이 먹힌다 Load이벤트일 때는 안 먹힌다
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (iSearchedList.Count == 0)
                {
                    DataTable copy_dt = mdtAll;
                    IEnumerable<DataRow> linq_row = null;
                    if (txtSearch.Text == "")
                    {
                        csDataGridView1.DataSource = copy_dt;
                    }
                    else
                    {
                        foreach (DataRow row in copy_dt.Rows)
                        {
                            linq_row = from item in row.ItemArray
                                       where item.ToString().ToLower().Contains(txtSearch.Text.ToLower())
                                       select row;
                            foreach (DataRow dt in linq_row)
                            {
                                int iCntSearch = copy_dt.Rows.IndexOf(row);
                                iSearchedList.Add(iCntSearch);
                                break;
                            }
                        }
                        iSelectedRow = iSearchedList.ToList();
                    }
                }
                if (iSearchedList.Count > 0)
                {
                    int iTestNum = iSelectedRow.Count(n => n == -1);
                    if (iTestNum == iSearchedList.Count)
                        iSelectedRow = iSearchedList.ToList();
                    for (int i = 0; i < iSearchedList.Count; i++)
                    {
                        if (iSelectedRow[i] == iSearchedList[i])
                        {
                            csDataGridView1.CurrentCell = csDataGridView1.Rows[iSearchedList[i]].Cells[0];
                            iSelectedRow[i] = -1;
                            break;
                        }
                    }
                }
            }
            else
            {
                iSearchedList.Clear();
                iSelectedRow.Clear();
            }
        }
    }


}
