using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAC;
namespace POPprogram
{
    public partial class frmStartWorkOrder : POPprogram.Base6
    {
        StarWorkServ serv;
        List<string> list;
        List<StarWorkProperty> swlist;
        List<string> CodeList;

        bool searchflag = false;
        string titleName;
        public string TitleName { get { return titleName; } set { } }
        List<EndPropertyEQ> listEQ;
        LOTinspectServ lotserv;
        public frmStartWorkOrder()
        {
            InitializeComponent();
        }

		private void frmStartWorkOrder_Load(object sender, EventArgs e)
		{
            serv = new StarWorkServ();
            list  = serv.GetLotCode();
            list.Insert(0, "");
            titleName = frmMain.TitleName;
            lblUpTitle.Text = "   " + titleName;
            //cboLOTID.ValueMember = "LOT_ID";
            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;

        
            lotserv = new LOTinspectServ();
            CodeList  = lotserv.GetCode();
            CodeList.Insert(0, "");
            cboEQList.ValueMember = "EQ_CODE";
            cboEQList.DisplayMember = "EQ_CODE";
            cboEQList.DataSource = CodeList;
        }

		private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
		{
            //textbox마다 보여주기 
            if (cboLOTID.SelectedIndex < 1) return;

			//string Value = cboLOTID.SelectedValue.ToString();

         

   //         Value = (cboLOTID.SelectedValue == null) ? "" : cboLOTID.SelectedValue.ToString();

   //         swlist = serv.GetData(Value);

   //          txtLOTDescription.Text = swlist[0].LOT_DESC;
   //           txtQty.Text = swlist[0].LOT_QTY.ToString();
   //         txtProdCode.Text = swlist[0].PRODUCT_CODE;
   //         txtCustID.Text = swlist[0].CUSTOMER_CODE;
   //         txtOperCode.Text = swlist[0].OPERATION_CODE;
   //         txtOperName.Text = swlist[0].OPERATION_NAME;
   //         txtProdName.Text = swlist[0].PRODUCT_NAME;
   //         txtWorkOrder.Text = swlist[0].WORK_ORDER_ID;
   //         lblOrderQty.Text = swlist[0].ORDER_QTY.ToString();
   //         lblDefectQty.Text = swlist[0].DEFECT_QTY.ToString();
   //         lblProdQty.Text = swlist[0].PRODUCT_QTY.ToString();
   //         txtCustName.Text = swlist[0].DATA_1;
   //         lblStatus.Text = swlist[0].ORDER_STATUS;

            LoadData();

        }

		private void LoadData()
		{
            string Value = cboLOTID.SelectedValue.ToString();
            
            Value = (cboLOTID.SelectedValue == null) ? "" : cboLOTID.SelectedValue.ToString();

            swlist = serv.GetData(Value);

            txtLOTDescription.Text = swlist[0].LOT_DESC;
            txtQty.Text = swlist[0].LOT_QTY.ToString();
            txtProdCode.Text = swlist[0].PRODUCT_CODE;
            txtCustID.Text = swlist[0].CUSTOMER_CODE;
            txtOperCode.Text = swlist[0].OPERATION_CODE;
            txtOperName.Text = swlist[0].OPERATION_NAME;
            txtProdName.Text = swlist[0].PRODUCT_NAME;
            txtWorkOrder.Text = swlist[0].WORK_ORDER_ID;
            lblOrderQty.Text = swlist[0].ORDER_QTY.ToString();
            lblDefectQty.Text = swlist[0].DEFECT_QTY.ToString();
            lblProdQty.Text = swlist[0].PRODUCT_QTY.ToString();
            txtCustName.Text = swlist[0].DATA_1;
            lblStatus.Text = swlist[0].ORDER_STATUS;
            if (txtOperCode.Text == "1000") cboEQList.SelectedIndex = 1;
            if (txtOperCode.Text == "1100") cboEQList.SelectedIndex = 2;
            if (txtOperCode.Text == "1200") cboEQList.SelectedIndex = 3;
            if (txtOperCode.Text == "1300") cboEQList.SelectedIndex = 4;
            if (txtOperCode.Text == "1400") cboEQList.SelectedIndex = 5;
            if (txtOperCode.Text == "1500") cboEQList.SelectedIndex = 6;
            if (txtOperCode.Text == "1600") cboEQList.SelectedIndex = 7;
        }

		private void btnExecute_Click(object sender, EventArgs e)
		{
           //LOTProperty pr = new LOTProperty();
            serv = new StarWorkServ();

            // 유효값 처리 어떻게 하면 좋을까 
            if (string.IsNullOrWhiteSpace(cboLOTID.SelectedValue.ToString()))
            {
                MessageBox.Show("LOT아이디가 존재하지않습니다.");
                return;
            }
            LOTProperty mLOT = new LOTProperty()
            {
                LOT_ID = cboLOTID.SelectedValue.ToString(),
                LOT_DESC = txtLOTDescription.Text,
                PRODUCT_CODE = txtProdCode.Text,
                OPERATION_CODE = txtOperCode.Text,
                WORK_ORDER_ID = txtWorkOrder.Text,
                LOT_QTY = Convert.ToDecimal(txtQty.Text),
                LAST_TRAN_COMMENT = txtComment.Text,
                LAST_TRAN_USER_ID = frmLogin.userID,
                CREATE_QTY = Convert.ToDecimal(txtQty.Text) + Convert.ToDecimal(lblDefectQty.Text),
                OPER_IN_QTY = Convert.ToDecimal(txtQty.Text),
                START_QTY = Convert.ToDecimal(txtQty.Text),
                START_EQUIPMENT_CODE = string.IsNullOrWhiteSpace(cboEQList.Text) ? "":cboEQList.SelectedValue.ToString()
            };

           

           
            bool result = serv.Insert(mLOT);
            if (result)
            {
                MessageBox.Show("작업이 정상적으로 시작되었습니다.");
                LoadData();
                //lblStatus.Text = "PROC";
                return;
            }
            else
            {
                MessageBox.Show("작업 시작 중 문제가 발생했습니다.");
                return;
            }
		}

		private void comboBox1_RightToLeftChanged(object sender, EventArgs e)
		{

		}

        // 나중구현
        //어찌하면 좋을까 
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (cboEQList.SelectedIndex < 1)
            {
                txtEQ_NAME.Text = "";
                return;

            }
            serv = new StarWorkServ();
            List<EndPropertyEQ> list = serv.GetEqList(cboEQList.SelectedValue.ToString());
            txtEQ_NAME.Text = list[0].EQ_NAME;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStartWorkOrder_Activated(object sender, EventArgs e)
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
            frmStartWorkOrder_Load(null, null);        
        }
    }
}
