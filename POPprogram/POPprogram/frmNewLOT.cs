using DAC;
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
        string msUserID;
        public frmNewLOT()
        {
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        private void frmNewLOT_Load(object sender, EventArgs e)
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
                txtCustName.Text = dr.Cells["CUSTOMER_NAME"].Value.ToString();
                txtProdCode.Text = dr.Cells["PRODUCT_CODE"].Value.ToString();
                txtProdName.Text = dr.Cells["PRODUCT_NAME"].Value.ToString();
                lblStatus.Text = dr.Cells["ORDER_STATUS"].Value.ToString();
                lblOrderQty.Text = dr.Cells["ORDER_QTY"].Value.ToString();
                lblProdQty.Text = dr.Cells["PRODUCT_QTY"].Value.ToString();
                lblDefectQty.Text = dr.Cells["DEFECT_QTY"].Value.ToString();
                txtOperCode.Text = dr.Cells["OPERATION_CODE"].Value.ToString();
                txtOperName.Text = dr.Cells["OPERATION_NAME"].Value.ToString();

            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLOTID.Text)) { MessageBox.Show("LOT ID를 반드시 입력해주세요."); return; }
            if (string.IsNullOrWhiteSpace(txtQty.Text)) { MessageBox.Show("수량을 반드시 입력해주세요."); return; }
            LOTProperty mLOT = new LOTProperty()
            {
                LOT_ID = txtLOTID.Text,
                LOT_DESC = txtLOTDescription.Text,
                PRODUCT_CODE = txtProdCode.Text,
                OPERATION_CODE = txtOperCode.Text,
                WORK_ORDER_ID = txtWorkOrderID.Text,
                LOT_QTY = Convert.ToInt32(txtQty.Text),
                LAST_TRAN_COMMENT = txtComment.Text,
                LAST_TRAN_USER_ID = msUserID

            };
            //입력한 정보로 status & history에 insert
            LOTServ serv = new LOTServ();
            bool bResult = serv.SetNewLOT(mLOT);
            if(bResult)
            {
                MessageBox.Show("성공적으로 생산 LOT를 생성했습니다.");
            }
            else
            {
                MessageBox.Show("LOT 생성 중 오류가 발생했습니다.");
            }
        }

      
    }
}
