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
		}

		private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
		{
            //textbox마다 보여주기 
            if (cboLOTID.SelectedIndex < 1) return;
			string Value = cboLOTID.SelectedValue.ToString();

            StarWorkProperty pr = new StarWorkProperty();

            Value = (cboLOTID.SelectedValue == null) ? "" : cboLOTID.SelectedValue.ToString();
            
            swlist = serv.GetData(Value);




        }

		private void btnExecute_Click(object sender, EventArgs e)
		{

		}
	}
}
