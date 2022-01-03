using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmStockIN : POPprogram.Base2
    {
        StockServ serv;
        public frmStockIN()
        {
            InitializeComponent();
        }

		public string name { get; set;}

		private void btnReadTop_Click(object sender, EventArgs e)
        {
            serv = new StockServ();
            DataTable dt = serv.Purchase_warehousing(txtSearch.Text);
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            frmPrurchaseDialog dlg = new frmPrurchaseDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow dr = dlg.SelectedRow;
                txtSearch.Text = dr.Cells["PURCHASE_ORDER_ID"].Value.ToString();
                txtCode1.Text = dr.Cells["MATERIAL_CODE"].Value.ToString();
                txtName1.Text = dr.Cells["PRODUCT_NAME"].Value.ToString();
                txtCode2.Text = dr.Cells["VENDOR_CODE"].Value.ToString();
                txtName2.Text = dr.Cells["VENDOR_NAME"].Value.ToString();
                txtCode3.Text = dr.Cells["ORDER_QTY"].Value.ToString();

            }
        }

        private void frmStockIN_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 품번", "CHILD_PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "단위 수량", "REQUIRE_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "수량", "수량");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재LOTID", "STOCK_IN_LOT_ID");
        }
    }
}
