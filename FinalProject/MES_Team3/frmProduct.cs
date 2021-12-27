using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmProduct : MES_Team3.BaseForms.Base1_1
    {
        //public List<Bar> barlist;
        
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
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

            LoadData();

            ProductProperty vo = new ProductProperty();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;


        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                LoadData();
            }
            else
            {
                
            }
        }


        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //오류 생김
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            ProductProperty vo = new ProductProperty();
            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_NAME"].Value != null && dr.Cells["PRODUCT_NAME"].Value != DBNull.Value)
                vo.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
            if (dr.Cells["PRODUCT_TYPE"].Value != null && dr.Cells["PRODUCT_TYPE"].Value != DBNull.Value)
                vo.PRODUCT_TYPE = dr.Cells["PRODUCT_TYPE"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["VENDOR_CODE"].Value != null && dr.Cells["VENDOR_CODE"].Value != DBNull.Value)
                vo.VENDOR_CODE = dr.Cells["VENDOR_CODE"].Value.ToString();
            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
                vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
                vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();
            //ProductVO vo = new ProductVO(csDataGridView1.Rows[e.RowIndex]); //데이터그리드뷰 row를 한 개만 선택되는 경우로 상정함

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

            pgProperty.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pk를 받아서 delete 하기 //이거 유틸로 할 수 있지 않을까? 

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Delete(save);
            LoadData();

        }

        public void LoadData()
        {
            ProductServ serv = new ProductServ();
            List<ProductProperty> list = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;
            SearchPanel = false;
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
            bool bResult = serv.Update(save);
            LoadData();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
            ProductServ serv = new ProductServ();
            List<ProductProperty> list = serv.GetProductSearch(search);
            csDataGridView1.DataSource = list;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PropertyDescriptor pd = pgSearch.SelectedGridItem.PropertyDescriptor;
            pd.ResetValue(pgSearch.SelectedObject);
            LoadData();
            ProductProperty search = new ProductProperty();
            search.IsSearchPanel = true;
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            searchPanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            DataTable dt = new DataTable();
            
            
        }
    }


}
