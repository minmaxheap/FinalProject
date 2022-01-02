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

namespace MES_Team3
{
    public partial class frmBOM : Base4_1
    {
        DataTable mdtAll;
        string prodCode;
        DataTable mdtAdd;
        string msUserID = frmLogin.userID;
        //string msUserID;
        //List<int> iSearchedList;
        //List<int> iSelectedRow;

        public frmBOM()
        {
            InitializeComponent();
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(dgvProduct);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "변경 사용자", "UPDATE_USER_ID");
            //iSearchedList = new List<int>();
            //iSelectedRow = new List<int>();


            DataGridViewUtil.SetInitGridView(dgvBOM);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "자 품번", "CHILD_PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "자 품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "단위 수량", "REQUIRE_QTY");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView2, "대체 품번", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = false;

            BomVO bvo = new BomVO();
            pgProperty.SelectedObject = bvo;
            pgProperty.PropertySort = PropertySort.NoSort;
            //pgProperty.SelectedObject = vo;

            //pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void LoadData()
        {
            ProductServ serv = new ProductServ();
            mdtAll = serv.GetProductsList();
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = mdtAll;
            dgvProduct.Focus();


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

                dgvProduct.DataSource = null;
                dgvProduct.DataSource = list;


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

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow dr = dgvProduct.Rows[e.RowIndex];
            BomVO vo = new BomVO();

            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

            pgProperty.Visible = true;

            prodCode = dgvProduct["PRODUCT_CODE", e.RowIndex].Value.ToString();

            BOMServ bomServ = new BOMServ();
            DataTable dtAll = bomServ.GetBOMList1();
            dgvBOM.DataSource = null;
            dgvBOM.DataSource = dtAll;

            GetDgvAddData();
        }
        private void GetDgvAddData()
        {
            BOMServ bomServ = new BOMServ();
            mdtAdd = bomServ.GetOperRelation(prodCode);
            dgvBOM.DataSource = null;
            dgvBOM.DataSource = mdtAdd;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            BomVO save = (BomVO)pgProperty.SelectedObject;
            save.CREATE_USER_ID = msUserID;
            BOMServ serv = new BOMServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("등록 중 실패하였습니다.");
                return;
            }
        }

        private void dgvBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow dr = dgvBOM.Rows[e.RowIndex];
            BomVO vo = new BomVO();


            //if (dr.Cells["STORE_CODE"].Value != null && dr.Cells["STORE_CODE"].Value != DBNull.Value)
            //    vo.STORE_CODE = dr.Cells["STORE_CODE"].Value.ToString();
            //if (dr.Cells["STORE_NAME"].Value != null && dr.Cells["STORE_NAME"].Value != DBNull.Value)
            //    vo.STORE_NAME = dr.Cells["STORE_NAME"].Value.ToString();
            //if (dr.Cells["STORE_TYPE"].Value != null && dr.Cells["STORE_TYPE"].Value != DBNull.Value)
            //    vo.STORE_TYPE = dr.Cells["STORE_TYPE"].Value.ToString();
            //if (dr.Cells["FIFO_FLAG"].Value != null && dr.Cells["FIFO_FLAG"].Value != DBNull.Value)
            //    vo.FIFO_FLAG = dr.Cells["FIFO_FLAG"].Value.ToString();
            //if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
            //    vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            //if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
            //    vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            //if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
            //    vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            //if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
            //    vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();


            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

            pgProperty.Visible = true;

        }
    }
}
