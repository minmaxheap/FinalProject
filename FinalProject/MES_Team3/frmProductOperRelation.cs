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
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "변경 사용자", "UPDATE_USER_ID");
            List<ProductProperty> list = new List<ProductProperty>();

            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = true;
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
            DataGridViewUtil.SetInitGridView(dgvAdd);
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "공정", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "공정명", "PRODUCT_NAME");

            DataGridViewUtil.SetInitGridView(dgvAll);
            DataGridViewUtil.AddGridTextColumn(dgvAll, "공정", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvAll, "공정명", "PRODUCT_NAME");
    
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
    }
}
