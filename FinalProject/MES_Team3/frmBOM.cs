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
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "자 품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "자 품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "단위 수량", "PRODUCT_TYPE");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView2, "대체 품번", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "변경 사용자", "UPDATE_USER_ID");

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

    }
}
