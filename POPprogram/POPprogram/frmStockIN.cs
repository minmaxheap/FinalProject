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
                //txtWorkOrderID.Text = dr.Cells["WORK_ORDER_ID"].Value.ToString();
                //txtCustID.Text = dr.Cells["CUSTOMER_CODE"].Value.ToString();
                //txtCustName.Text = dr.Cells["CUSTOMER_NAME"].Value.ToString();
                //txtProdCode.Text = dr.Cells["PRODUCT_CODE"].Value.ToString();
                //txtProdName.Text = dr.Cells["PRODUCT_NAME"].Value.ToString();
                //lblStatus.Text = dr.Cells["ORDER_STATUS"].Value.ToString();
                //lblOrderQty.Text = dr.Cells["ORDER_QTY"].Value.ToString();
                //lblProdQty.Text = dr.Cells["PRODUCT_QTY"].Value.ToString();
                //lblDefectQty.Text = dr.Cells["DEFECT_QTY"].Value.ToString();
                //txtOperCode.Text = dr.Cells["OPERATION_CODE"].Value.ToString();
                //txtOperName.Text = dr.Cells["OPERATION_NAME"].Value.ToString();

            }
        }
    }
}
