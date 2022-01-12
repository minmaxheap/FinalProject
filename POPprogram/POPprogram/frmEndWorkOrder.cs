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
    public partial class frmEndWorkOrder : POPprogram.Base6
    {
        List<string> list;
        bool searchflag = false;
        public frmEndWorkOrder()
        {
            InitializeComponent();

        }

        private void frmEndWorkOrder_Load(object sender, EventArgs e)
        {
            searchflag = true;
            MatServ serv = new MatServ();
            list = serv.GetLotList();

            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;
            cboLOTID.Text = null;
        }

        private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLOTID.SelectedIndex < 0 || cboLOTID.Text == "" || searchflag)
            {
                searchflag = false;
                return;
            }
            EndProperty vo = new EndProperty();
            EndServ serv = new EndServ();
            vo.LOT_ID = cboLOTID.Text;
            if (vo.LOT_ID == "") return;
            List<EndProperty> list = serv.GetStatusList(vo);
            txtLOTDescription.Text = list[0].LOT_DESC;
            txtQty.Text = list[0].LOT_QTY.ToString();
            txtProdCode.Text = list[0].PRODUCT_CODE;
            txtCustID.Text = list[0].CUSTOMER_CODE;
            txtOperCode.Text = list[0].OPERATION_CODE;
            txtOperName.Text = list[0].OPERATION_NAME;
            txtProdName.Text = list[0].PRODUCT_NAME;
            txtWorkOrder.Text = list[0].WORK_ORDER_ID;
            lblOrderQty.Text = list[0].ORDER_QTY.ToString();
            lblDefectQty.Text = list[0].DEFECT_QTY.ToString();
            lblProdQty.Text = list[0].PRODUCT_QTY.ToString();
            txtCustName.Text = list[0].CUSTOMER_NAME;
            lblStatus.Text = list[0].ORDER_STATUS;

            MatPropertyPrdCode usevo = new MatPropertyPrdCode();
            usevo.PRODUCT_CODE = txtProdCode.Text;

        }
    }
}
