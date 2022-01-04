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
    public partial class frmLOTInspect : POPprogram.Base6
    {
        StarWorkServ serv;
        List<string> list;
        List<StarWorkProperty> swlist;
        LOTinspectServ lotserv;

        public frmLOTInspect()
        {
            InitializeComponent();
        }

        private void frmLOTInspect_Load(object sender, EventArgs e)
        {
            serv = new StarWorkServ();
            list = serv.GetLotCode();
            list.Insert(0, "");
            //cboLOTID.Items.Insert(0, " ");
            //cboLOTID.ValueMember = "LOT_ID";
            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;

            //ir.OPERATION_CODE,ir.INSPECT_ITEM_CODE,i.INSPECT_ITEM_NAME,i.VALUE_TYPE,i.SPEC_LSL,i.SPEC_TARGET,i.SPEC_USL
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정코드", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사항목", "INSPECT_ITEM_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사항목 명", "INSPECT_ITEM_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "값 타입", "VALUE_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LSL", "SPEC_LSL");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "TARGET", "SPEC_TARGET");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "USL", "SPEC_USL");
           // DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사데이터", "검사데이터");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "유효값", "유효값");


      
            LoadData();

            this.csDataGridView1.Columns.Add("검사데이터", "검사데이터");
            this.csDataGridView1.Columns.Add("유효값", "유효값");




            // 컬럼의 폭을 지정할 수 있다.
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
        private void LoadData()
        {
            //공정아이디로 보여주기
            string Code = "1000";
            lotserv = new LOTinspectServ();
            DataTable dt = lotserv.GetInspec(Code);
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;

        }

		private void csDataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
            
		}

		private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
          
		}

		private void csDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{

            int rowindex = csDataGridView1.CurrentCell.ColumnIndex;
            if (csDataGridView1.Columns[rowindex].HeaderText == "검사데이터")
            {

                int row = csDataGridView1.CurrentRow.Index;
                int LSL = Convert.ToInt32(csDataGridView1.Rows[row].Cells[4].Value.ToString());
                int USL = Convert.ToInt32(csDataGridView1.Rows[row].Cells[6].Value.ToString());
                int a = Convert.ToInt32(csDataGridView1.Rows[row].Cells[7].Value.ToString());

                if (LSL < a && a < USL)
                {
                    MessageBox.Show("성공");
                    csDataGridView1.Rows[row].Cells[8].Value = "OK";
                    csDataGridView1.Columns["유효값"].DefaultCellStyle.ForeColor = Color.Green;
                    csDataGridView1.Rows[row].Selected = false;
                    return;
                }
                else
                {
                    csDataGridView1.Rows[row].Cells[8].Value = "NG";
                    csDataGridView1.Columns["유효값"].DefaultCellStyle.ForeColor = Color.Red;
                    csDataGridView1.Columns["유효값"].DefaultCellStyle.BackColor = Color.DarkRed;
                    csDataGridView1.Rows[row].Selected = false;
                    //csDataGridView1.Columns["유효값"].DefaultCellStyle
                    return;
                }
                

                // if(


            }
        }
	}
}
