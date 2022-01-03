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
        public frmStockIN()
        {
            InitializeComponent();
        }

        private void btnReadTop_Click(object sender, EventArgs e)
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
    }
}
