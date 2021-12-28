using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmProduct : MES_Team3.BaseForms.Base1_1
    {
        List<ProductProperty> mAllList;
        string msUserID;

        public frmProduct()
        {
           
            InitializeComponent();
          
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            frmMain frm = (frmMain)this.MdiParent;
            msUserID = frm.SUserID;
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");
            List<ProductProperty> list = new List<ProductProperty>();

            LoadData();

            ProductProperty vo = new ProductProperty();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;


        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Insert(save, msUserID);
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

        public void LoadData()
        {
            ProductServ serv = new ProductServ();
             mAllList = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = mAllList;
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
            ProductServ serv = new ProductServ();
            bool bResult = serv.Update(save, msUserID);
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
            ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
            ProductServ serv = new ProductServ();
            List<ProductProperty> list = serv.GetProductSearch(search);
            search.IsSearchPanel = false;

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;

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
                BSearchPanel = true;
                csDataGridView1.DataSource = null;
                csDataGridView1.DataSource = mAllList;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            string txt = txtSearch.Text.ToUpper();
            //List<ProductProperty> txtSearch = allList.FindAll((x) => x.PRODUCT_CODE.Contains(txt) || x.PRODUCT_NAME.Contains(txt)||//x.PRODUCT_TYPE.Contains(txt) || x.CUSTOMER_CODE.Contains(txt)||x.VENDOR_CODE.Contains(txt) || x.CREATE_USER_ID.Contains(txt)||//x.UPDATE_USER_ID.Contains(txt));
            // csDataGridView1.DataSource = txtSearch;
            foreach (DataGridViewRow row in csDataGridView1.Rows)
            {
                // Test if the first column of the current row equals
                // the value in the text box
                if (row.Cells["PRODUCT_CODE"].Value.ToString().Contains(txt) || row.Cells["PRODUCT_NAME"].Value.ToString().ToUpper().Contains(txt) || row.Cells["PRODUCT_TYPE"].Value.ToString().ToUpper().Contains(txt) || row.Cells["CUSTOMER_CODE"].Value.ToString().ToUpper().Contains(txt) || row.Cells["VENDOR_CODE"].Value.ToString().ToUpper().Contains(txt) || row.Cells["CREATE_USER_ID"].Value.ToString().ToUpper().Contains(txt) || row.Cells["UPDATE_USER_ID"].Value.ToString().ToUpper().Contains(txt))
                {
                    // we have a match
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            btnReadBottom.PerformClick();
        }
    }


}
