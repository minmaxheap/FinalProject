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
            CodeList = lotserv.GetCode();
            CodeList.Insert(0, "");
            comboBox1.ValueMember = "EQUIPMENT_CODE";
            comboBox1.DisplayMember = "EQUIPMENT_CODE";
            comboBox1.DataSource = CodeList
                ;
		}

		private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
		{
            //textbox마다 보여주기 
            if (cboLOTID.SelectedIndex < 1) return;
			string Value = cboLOTID.SelectedValue.ToString();

            StarWorkProperty pr = new StarWorkProperty();

            Value = (cboLOTID.SelectedValue == null) ? "" : cboLOTID.SelectedValue.ToString();

            swlist = serv.GetData(Value);


            txtProdCode.Text = swlist[0].PRODUCT_CODE;
            txtCustID.Text = swlist[0].CUSTOMER_CODE;
            txtOperCode.Text = swlist[0].OPERATION_CODE;
            txtOperName.Text = swlist[0].OPERATION_NAME;
            txtProdName.Text = swlist[0].PRODUCT_NAME;
            txtWorkOrder.Text = swlist[0].WORK_ORDER_ID;
            lblOrderQty.Text = swlist[0].ORDER_QTY.ToString();
            lblDefectQty.Text = swlist[0].DEFECT_QTY.ToString();
            lblProdQty.Text = swlist[0].PRODUCT_QTY.ToString();


        }

		private void btnExecute_Click(object sender, EventArgs e)
		{

		}
	}
}
