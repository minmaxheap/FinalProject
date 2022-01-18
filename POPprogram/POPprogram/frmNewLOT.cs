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
        string titleName;
        public string TitleName { get { return titleName; } set { } }
        public frmNewLOT()
        {
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        private void frmNewLOT_Load(object sender, EventArgs e)
        {
            titleName = frmMain.TitleName;
            lblUpTitle.Text = "   " + titleName;
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
                if(dr!=null)
                { txtWorkOrderID.Text = dr.Cells["WORK_ORDER_ID"].Value.ToString();
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

        private void txtLOTID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLOTID_Click(object sender, EventArgs e)
        {
            StringBuilder strb = new StringBuilder();
            //LOT 제조일자
            string time = DateTime.Now.ToString("yyMMdd");
            strb.Append(time);
            //LOT 제품별 품목 구분
            if (txtProdCode.Text == "")
                return;
            string lotMiddle = txtProdCode.Text;
            lotMiddle = lotMiddle.Substring(3, 1);
            if (lotMiddle == "L") strb.Append("-PD-LC");
            if (lotMiddle == "R") strb.Append("-PD-RC");
            if (lotMiddle == "S") strb.Append("-PD-SP");
            //LOT품목별 용량
            string prdNum = txtProdCode.Text;
            prdNum = prdNum.Substring(prdNum.Length - 4, 3);
            strb.Append(prdNum);
            strb.Append("-");
            string preLot = strb.ToString();

            LOTServ serv = new LOTServ();
            string getLotMax = serv.GetLotMax(preLot);
            string numLot = null;
            //if (getLotMax == "" || getLotMax==null) numLot = "001";
            //else
            //{
            //    int temp = Convert.ToInt32(getLotMax);
            //    temp = temp + 1;
            //    getLotMax = Convert.ToString(temp);
            //    numLot = "00" + getLotMax;
            //}
            string worknum = txtWorkOrderID.Text;
            worknum = worknum.Substring(worknum.Length - 3, 3); 
            strb.Append(worknum);
            txtLOTID.Text = strb.ToString();
            txtLOTDescription.Text =txtCustName.Text +' '+txtProdName.Text;
        }

        private void frmNewLOT_Activated(object sender, EventArgs e)
        {
            lblOrderQty.Text = null;
            lblDefectQty.Text = null;
            lblProdQty.Text = null;
            lblStatus.Text = null;
            ////////////////////////////////////////////////////////////////////////////
            foreach (Control ctl1 in this.Controls)
            {
                foreach (Control ctl2 in this.Controls[this.Controls.IndexOf(ctl1)].Controls)
                    if (typeof(TextBox) == ctl2.GetType())
                    {
                        ctl2.Text = null;
                    }
                    else if (typeof(NumTextBox) == ctl2.GetType())
                    {
                        ctl2.Text = null;
                    }
                    else if (typeof(ComboBox) == ctl2.GetType())
                    {
                        ComboBox dd = (ComboBox)ctl2;
                        if (dd != null)
                        {
                            dd.Text = string.Empty;
                            dd.SelectedIndex = -1;
                        }
                    }
                    else if (typeof(csDataGridView) == ctl2.GetType())
                    {
                        csDataGridView dd = (csDataGridView)ctl2;
                        if (dd != null)
                        {
                            dd.DataSource = null;
                        }
                    }
            }
            ////////////////////////////////////////////////////////////////////////////
            
        }
    }
}
