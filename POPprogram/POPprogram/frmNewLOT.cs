using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmNewLOT : POPprogram.Base5
    {
        public frmNewLOT()
        {
            InitializeComponent();
        }

        private void frmNewLot1_Load(object sender, EventArgs e)
        {

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmWorkOrderDialog dlg = new frmWorkOrderDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow dr = dlg.SelectedRow;
                txtWorkOrderID.Text = dr.Cells["WORK_ORDER_ID"].Value.ToString();
                txtCustID.Text = dr.Cells["CUSTOMER_CODE"].Value.ToString();
                txtCustName.Text = dr.Cells["CUSTOMER_NAME_JOIN"].Value.ToString();
                txtProdCode.Text = dr.Cells["PRODUCT_CODE"].Value.ToString();
                txtProdName.Text = dr.Cells["PRODUCT_CODE_JOIN"].Value.ToString();
                lblStatus.Text = dr.Cells["ORDER_STATUS"].Value.ToString();
                lblOrderQty.Text = dr.Cells["ORDER_QTY"].Value.ToString();
                lblProdQty.Text = dr.Cells["PRODUCT_QTY"].Value.ToString();
                lblDefectQty.Text = dr.Cells["DEFECT_QTY"].Value.ToString();
                //txtOperName.Text = dr.Cells["공정 불러오기"].Value.ToString();
                //선택한 작업저시 정보 텍스트박스에 보여주기

            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //생산 LOT 생성 
        }
    }
}
