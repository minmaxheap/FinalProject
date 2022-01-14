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
            //cboLOTID.Items.Insert(0, " ");
            //cboLOTID.ValueMember = "LOT_ID";
            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;

            lotserv = new LOTinspectServ();
            DataTable dt  = lotserv.GetCode();
            //CodeList.Insert(0, "");
            comboBox1.ValueMember = "EQ_CODE";
            comboBox1.DisplayMember = "EQ_CODE";
            comboBox1.DataSource = dt;
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
        }

		private void btnExecute_Click(object sender, EventArgs e)
		{
           //LOTProperty pr = new LOTProperty();
            serv = new StarWorkServ();
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
                CREATE_QTY = Convert.ToDecimal(txtQty.Text),
                OPER_IN_QTY = Convert.ToDecimal(txtQty.Text),
                START_QTY = Convert.ToDecimal(txtQty.Text),
                START_EQUIPMENT_CODE = (comboBox1.SelectedValue.ToString() == "") ? "":comboBox1.SelectedValue.ToString()
            };

            if (mLOT == null)
            {
                MessageBox.Show("해당되는 값이 없습니다.");
                return;
            }

            //if (lblStatus.Text == "PROC")
            //{
            //    MessageBox.Show("proc상태여서 실행을 할수없습니다.");
            //    return;
            //}

            bool result = serv.Insert(mLOT);
            if (result)
            {
                MessageBox.Show("성공");
                LoadData();
                //lblStatus.Text = "PROC";
                return;
            }
            else
            {
                MessageBox.Show("실패");
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
            if (cboLOTID.SelectedIndex < 1) return;

            //List<string> list = new List<string>();
            //list =  serv.GetEqList(comboBox1.SelectedValue.ToString());
            //textBox10.Text = list[0];
        }
	}
}
