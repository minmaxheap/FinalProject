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
			list = serv.GetLotOpCode();
			list.Insert(0, "");
			//cboLOTID.Items.Insert(0, " ");
			//cboLOTID.ValueMember = "LOT_ID";
			cboLOTID.DisplayMember = "LOT_ID";
			cboLOTID.DataSource = list;




			//ir.OPERATION_CODE,ir.INSPECT_ITEM_CODE,i.INSPECT_ITEM_NAME,i.VALUE_TYPE,i.SPEC_LSL,i.SPEC_TARGET,i.SPEC_USL
			DataGridViewUtil.SetInitGridView(csDataGridView1);
			//DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정코드", "OPERATION_CODE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사항목", "INSPECT_ITEM_CODE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사항목 명", "INSPECT_ITEM_NAME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "값 타입", "VALUE_TYPE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LSL", "SPEC_LSL");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "TARGET", "SPEC_TARGET");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "USL", "SPEC_USL");
			// DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사데이터", "InspectValue");
			//DataGridViewUtil.AddGridTextColumn(csDataGridView1, "유효값", "InspectResult");
			//
			this.csDataGridView1.Columns.Add("InspectValue", "검사데이터");
			this.csDataGridView1.Columns.Add("InspectResult", "유효값");
			this.csDataGridView1.Columns["InspectResult"].ReadOnly = true;

			this.csDataGridView1.RowTemplate.Height = 20;
			this.csDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			// this.csDataGridView1.Columns.Add(



			// 컬럼의 폭을 지정할 수 있다.
		}

		private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
		{
			//textbox마다 보여주기 
			if (cboLOTID.SelectedIndex < 1) return;
			string Value = cboLOTID.SelectedValue.ToString();

			StarWorkProperty pr = new StarWorkProperty();

			Value = (cboLOTID.SelectedValue == null) ? "" : cboLOTID.SelectedValue.ToString();

			//swlist = serv.GetData(Value);

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

			LoadData();
		}
		private void LoadData()
		{
			//공정아이디로 보여주기
			string Code = txtOperCode.Text;
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
			//this.csDataGridView1.ClearSelection();
			int rowindex = csDataGridView1.CurrentCell.ColumnIndex;
			if (csDataGridView1.Columns[rowindex].HeaderText == "검사데이터")
			{

				int row = csDataGridView1.CurrentRow.Index;
				
				int LSL = Convert.ToInt32(csDataGridView1.Rows[row].Cells["SPEC_LSL"].Value.ToString());
				int USL = Convert.ToInt32(csDataGridView1.Rows[row].Cells["SPEC_USL"].Value.ToString());
				int a = Convert.ToInt32(csDataGridView1.Rows[row].Cells["InspectValue"].Value.ToString());

				if (LSL < a && a < USL)
				{
					//MessageBox.Show("성공");
					csDataGridView1.Rows[row].Cells["InspectResult"].Value = "OK";
					csDataGridView1.Rows[row].Cells["InspectResult"].Style.ForeColor = Color.Green;
				}
				else
				{
					csDataGridView1.Rows[row].Cells["InspectResult"].Value = "NG";
					csDataGridView1.Rows[row].Cells["InspectResult"].Style.ForeColor = Color.Red;
					//csDataGridView1.Columns["유효값"].DefaultCellStyle
					// return;
				}
				//엔터치면 됨 tab은 안됨 왜일까?

				csDataGridView1.ClearSelection();
				btnExecute.Focus();
			}
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			//foreach 문을써서 다 넣는지 아니면 다 넣지않고 하나의 셀만 넣는건지 궁금합니다.
			// 데이터그리드 안에잇는 유효값이     


			//datagridview 컬럼
			//
			DataTable dt = new DataTable();
			dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("InspectCode", typeof(string));
			dt.Columns.Add("InspectName", typeof(string));
			dt.Columns.Add("ValueType", typeof(string));
			dt.Columns.Add("LSL", typeof(string));
			dt.Columns.Add("SPEC_Target", typeof(string));
			dt.Columns.Add("USL", typeof(string));
			dt.Columns.Add("INSPECT_DATA", typeof(string));
			dt.Columns.Add("effectiveness", typeof(string));
		


			//행을 추가 
			for (int i = 0; i < csDataGridView1.Rows.Count; i++)
			{

				DataRow dr = dt.NewRow();
				// OK NG 
				// "" OR 이상한값 

				if (csDataGridView1.Rows[i].Cells["InspectResult"].Value != null)
				{
					if (csDataGridView1.Rows[i].Cells["InspectResult"].Value.ToString() == "OK" || csDataGridView1.Rows[i].Cells["InspectResult"].Value.ToString() == "NG")
					{
						//여기서는 코드이름을 넣어야할까 아니면 그 부분을 넣어야할까?
						dr["ID"] = Convert.ToInt32(i);
						dr["InspectCode"] = csDataGridView1.Rows[i].Cells["INSPECT_ITEM_CODE"].Value.ToString();
						dr["InspectName"] = csDataGridView1.Rows[i].Cells["INSPECT_ITEM_NAME"].Value.ToString();
						dr["ValueType"] = csDataGridView1.Rows[i].Cells["VALUE_TYPE"].Value.ToString();
						dr["LSL"] = csDataGridView1.Rows[i].Cells["SPEC_LSL"].Value.ToString();
						dr["SPEC_Target"] = csDataGridView1.Rows[i].Cells["SPEC_TARGET"].Value.ToString();
						dr["USL"] = csDataGridView1.Rows[i].Cells["SPEC_USL"].Value.ToString();
						dr["INSPECT_DATA"] = csDataGridView1.Rows[i].Cells["InspectValue"].Value.ToString();
						dr["effectiveness"] = csDataGridView1.Rows[i].Cells["InspectResult"].Value.ToString();

						dt.Rows.Add(dr);
					}
				}	
			}

			if (cboLOTID.SelectedValue.ToString() == "")
			{
				MessageBox.Show("lot 상태가 없습니다.");
				return;
			}

			if (dt == null)
			{
				MessageBox.Show("검사를 하지않아 검사데이터가 없습니다.");
				return;
			}
			dt.AcceptChanges();
			//string msuerID = 
			
			bool result = lotserv.insert(frmLogin.userID, txtComment.Text, cboLOTID.SelectedValue.ToString(), dt);
			if (result)
			{
				MessageBox.Show("성공");
				return;
			}
			else
			{
				MessageBox.Show("실패");
				return;
			}
		}
	}
}
	

