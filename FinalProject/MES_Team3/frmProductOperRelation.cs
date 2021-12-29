using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmProductOperRelation : MES_Team3.Base3_1
    {
        List<ProductProperty> mAllList;
        string msprodCode;
        public frmProductOperRelation()
        {
            InitializeComponent();
        }

        private void frmProductOperRelation_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvProducts);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "변경 사용자", "UPDATE_USER_ID");

            DataGridViewUtil.SetInitGridView(dgvAdd);
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "순번", "FLOW_SEQ", width: 80);
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "공정", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "공정명", "OPERATION_NAME", width: 300);

            DataGridViewUtil.SetInitGridView(dgvAll);
            DataGridViewUtil.AddGridTextColumn(dgvAll, "공정",  "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvAll, "공정명","OPERATION_NAME",width: 300);

            List<ProductProperty> list = new List<ProductProperty>();

            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = false;
            //BIsSearchPanel = false;
            pgdSearch.SelectedObject = vo;
            

           pgdSearch.PropertySort = PropertySort.NoSort;
        }
        private void LoadData()
        {
            ProductServ serv = new ProductServ();
            mAllList = serv.GetProductsList();
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = mAllList;

        }

        private void btnSearchPnl_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            OperationServ operServ = new OperationServ();
            DataTable dtAll = operServ.GetOperationList();
            dgvAll.DataSource = null;
            dgvAll.DataSource = dtAll;

            ProductServ prodServ = new ProductServ();
            DataTable dtAdd = prodServ.GetOperRelation(dgvProducts["PRODUCT_CODE",e.RowIndex].Value.ToString());
            dgvAdd.DataSource = null;
            dgvAdd.DataSource = dtAdd;

            dgvAdd.Columns["FLOW_SEQ"].ReadOnly = false;
            msprodCode = dgvProducts["PRODUCT_CODE", e.RowIndex].Value.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {
            if (pgdSearch.SelectedObject != null)
            {
                ProductProperty search = (ProductProperty)pgdSearch.SelectedObject;
                ProductServ serv = new ProductServ();
                List<ProductProperty> list = serv.GetProductSearch(search);
                search.IsSearchPanel = false;

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = list;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
          
            foreach (DataGridViewRow dr in dgvAll.SelectedRows)
            {
                list.Add(dr.Cells["OPERATION_CODE"].Value.ToString());

            }
            ProductServ serv = new ProductServ();
            bool bResult = serv.SetOpertation(msprodCode,list); //이미 들어갔던 공정 못 들어가게 막기 & 한 번에 여러개 넣도록 수정하기
            if(bResult)
            {
                //dgvadd 재로딩
                GetDgvAddData();
            }
            else
            {
                //메시지 박스
                MessageBox.Show("오류가 발생했습니다.");
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow dr in dgvAll.SelectedRows)
            {
                list.Add(dr.Cells["OPERATION_CODE"].Value.ToString());

            }
            ProductServ serv = new ProductServ();
            bool bResult = serv.DeleteOperation(msprodCode, list);
            if (bResult)
            {
                //dgvadd 재로딩
                GetDgvAddData();
            }
            else
            {
                //메시지 박스
                MessageBox.Show("오류가 발생했습니다.");
            }
        }

        private void GetDgvAddData()
        {
            ProductServ prodServ = new ProductServ();
            DataTable dtAdd = prodServ.GetOperRelation(msprodCode);
            dgvAdd.DataSource = null;
            dgvAdd.DataSource = dtAdd;
        }
    }
}
