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
       
        public frmNewLOT()
        {
            InitializeComponent();
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
            //LOT ID랑 수량 입력 안 하면 RETURN 되도록 해야함(아직 안 함)
            LOTProperty mLOT = new LOTProperty()
            {
                LOT_ID = txtLOTID.Text,
                LOT_DESC = txtLOTDescription.Text,
                PRODUCT_CODE = txtProdCode.Text,
                OPERATION_CODE = txtOperID.Text,
                WORK_ORDER_ID = txtWorkOrderID.Text,
                LOT_QTY = Convert.ToInt32(txtQty.Text),
                LAST_TRAN_COMMENT = txtComment.Text

            };
            //입력한 정보로 status & history에 insert
            LOTServ serv = new LOTServ();
            bool bResult = serv.SetNewLOT(mLOT);
            if(bResult)
            {
                MessageBox.Show("LOT 생성을 성공적으로 실행했습니다.");
            }
            else
            {
                MessageBox.Show("LOT 생성 중 오류가 발생했습니다.");
            }
        }

      
    }
}
