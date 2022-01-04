using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAC;

namespace MES_Team3
{
    public partial class frmInspectOperRelation : MES_Team3.Base3_1
    {
        INSPECT_OPServ serv = null;
		InspecServ inserv = null;

		string inspec_op_Code = string.Empty; // 공정코드
		string inspect_Code = string.Empty; // 검사 항목 코드
		string CreateID = frmLogin.userID;
		string updateID = frmLogin.userID;

		DataTable mOp_dt;


		List<string> MstList = null;


		DataTable dt;
		List<int> iSearchedList;
		List<int> iSelectedRow;

		public frmInspectOperRelation()
        {
            InitializeComponent();
        }

		private void ResetCount()
		{
			iSearchedList.Clear();
			iSelectedRow.Clear();
		}


		private void frmInspectOperRelation_Load(object sender, EventArgs e)
        {
			//OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
			DataGridViewUtil.SetInitGridView(csDataGridView1);
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정", "OPERATION_CODE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정명", "OPERATION_NAME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "불량입력", "CHECK_DEFECT_FLAG");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사 데이터 입력", "CHECK_INSPECT_FLAG");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 사용", "CHECK_MATERIAL_FLAG");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성시간", "CREATE_TIME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경시간", "UPDATE_TIME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");


			OP_Grid();
			INSPECT_Grid();


			iSearchedList = new List<int>();
			iSelectedRow = new List<int>();

			LoadData();

		
			INSPECT_OPERATIONProperty pr = new INSPECT_OPERATIONProperty();

			pgSearch .SelectedObject = pr;

			pgSearch.PropertySort = PropertySort.NoSort;
		}

		

		private void LoadData()
		{
			serv = new INSPECT_OPServ();
			DataTable dt = serv.Op_GetTable();
			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = dt;

			inserv = new InspecServ();
			MstList = inserv.GetINSPECT_Code();
			MstList.Insert(0, "");
			//MstList.Insert(0,
			comboBox1.ValueMember = "KEY_1";
			comboBox1.DisplayMember = "KEY_1";
			comboBox1.DataSource = MstList;

			ResetCount();

		}
		//조회조건
		private void btnReadBottom_Click(object sender, EventArgs e)
		{
		}

		private void btnReadBottom_Click_1(object sender, EventArgs e)
		{

			
			INSPECT_OPERATIONProperty pr = (INSPECT_OPERATIONProperty)pgSearch.SelectedObject;

			DataTable dt = serv.GetSearch(pr);
			//pr.IsSearchPanel = false;

			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = dt;

			ResetCount();

		}

		private void csDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			//공정 아이디
			inspec_op_Code = csDataGridView1["OPERATION_CODE", e.RowIndex].Value.ToString();
			MessageBox.Show($"{inspec_op_Code}를 선택하셨습니다.");

			Op_LoadData();
		}

		private void btnReadTop_Click(object sender, EventArgs e)
		{

			INSPECT_OPERATIONProperty pr = (INSPECT_OPERATIONProperty)pgSearch.SelectedObject;

			DataTable dt = serv.GetSearch(pr);
			//pr.IsSearchPanel = false;

			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = dt;

			ResetCount();

		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			//장바구니?
			//선택된 datagrid를 할당시켜줘야함
			//insert 시켜야함
			// 메뉴권한 
			List<string> list = new List<string>();


			foreach (DataGridViewRow dr in csDataGridView2.SelectedRows)
			{
				DataRow[] drArray = mOp_dt.Select($"INSPECT_ITEM_CODE='{dr.Cells["INSPECT_ITEM_CODE"].Value.ToString()}'");
				if (!(drArray.Length > 0))
					list.Add(dr.Cells["INSPECT_ITEM_CODE"].Value.ToString());

			}

			if (string.IsNullOrWhiteSpace(inspec_op_Code) || string.IsNullOrWhiteSpace(inspect_Code))
			{
				MessageBox.Show("공정코드 혹은 검사 항목이 존재 하지 않습니다.");
				return;
			}

			if (list.Count > 0)
			{

				bool result = serv.Op_Insert(inspec_op_Code, inspect_Code, CreateID, updateID);
				if (result)
				{
					MessageBox.Show("등록되었습니다.");
					Op_LoadData();
					return;
				}
				else
				{
					MessageBox.Show("등록실패");
					return;
				}
			}
			else
			{
				MessageBox.Show("이미 할당되었습니다.");
				return;
			}

			
		}

		private void btnSubtract_Click(object sender, EventArgs e)
		{
			//delete 시켜야함 (관계 table)에서 
			// 왜 false가 나올까

			if (string.IsNullOrWhiteSpace(inspec_op_Code) || string.IsNullOrWhiteSpace(inspect_Code))
			{
				MessageBox.Show("공정코드가 없거나 검사항목이 존재하지 않습니다.");
				return;
			}
			bool result = serv.Op_Delete(inspec_op_Code,inspect_Code);
			if (result)
			{
				MessageBox.Show("할당 제거");
				Op_LoadData();
				inspect_Code = string.Empty;
				inspec_op_Code = string.Empty;
				return;
			}
			else
			{
				MessageBox.Show("삭제 실패");
				return;
			}
		}

		private void Op_LoadData()
		{
			serv = new INSPECT_OPServ();
			DataTable mOp_dt = serv.GetOp_Table(inspec_op_Code);
			csDataGridView2.DataSource = null;
			csDataGridView2.DataSource = mOp_dt;
		}

		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			//List<string> list = serv.GetAll(comboBox1.SelectedValue.ToString());
			//csDataGridView3.DataSource = null;
			//csDataGridView3.DataSource = list;
			////MessageBox.Show(comboBox1.SelectedValue.ToString());
		}


		private void INSPECT_Grid()
		{
			//RowNum,[INSPECT_ITEM_CODE],[INSPECT_ITEM_NAME]
			DataGridViewUtil.SetInitGridView(csDataGridView3);

			DataGridViewUtil.AddGridTextColumn(csDataGridView3, "순번", "RowNum");
			DataGridViewUtil.AddGridTextColumn(csDataGridView3, "검사항목", "INSPECT_ITEM_CODE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView3, "검사항목명", "INSPECT_ITEM_NAME");
		}

		private void OP_Grid()
		{
			//OPERATION_CODE, i.INSPECT_ITEM_CODE , i.INSPECT_ITEM_NAME,
			DataGridViewUtil.SetInitGridView(csDataGridView2);
			DataGridViewUtil.AddGridTextColumn(csDataGridView2, "순번", "RowNum");
			DataGridViewUtil.AddGridTextColumn(csDataGridView2, "공정", "OPERATION_CODE", visibility: false);
			DataGridViewUtil.AddGridTextColumn(csDataGridView2, "검사항목", "INSPECT_ITEM_CODE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView2, "검사항목명", "INSPECT_ITEM_NAME");
			//DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum");


		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex < 1) return;
			string Value = comboBox1.SelectedValue.ToString();
			MessageBox.Show(Value);

			
			Value = (comboBox1.SelectedValue == null) ? "" : comboBox1.SelectedValue.ToString();

			serv = new INSPECT_OPServ();
			DataTable dt = serv.GetAll(Value);
			csDataGridView3.DataSource = null;
			csDataGridView3.DataSource = dt;



		}

		private void csDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			inspect_Code = csDataGridView3["INSPECT_ITEM_CODE", e.RowIndex].Value.ToString();
			MessageBox.Show($"{inspect_Code}를 선택하셨습니다.");
		}

		

		private void csDataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnTxtSearch.PerformClick();
			}
			else
			{
				ResetCount();
			}
		}

		public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
		{
			try
			{
				if (_DataGridView.ColumnCount == 0)
					return null;
				DataTable dtSource = new DataTable();
				//////create columns
				foreach (DataGridViewColumn col in _DataGridView.Columns)
				{
					if (col.ValueType == null)
						dtSource.Columns.Add(col.Name, typeof(string));
					else
						dtSource.Columns.Add(col.Name, col.ValueType);
					dtSource.Columns[col.Name].Caption = col.HeaderText;
				}
				///////insert row data
				foreach (DataGridViewRow row in _DataGridView.Rows)
				{
					DataRow drNewRow = dtSource.NewRow();
					foreach (DataColumn col in dtSource.Columns)
					{
						drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
					}
					dtSource.Rows.Add(drNewRow);
				}
				return dtSource;
			}
			catch (Exception err)
			{
				Debug.WriteLine(err.Message);
				return null;
			}
		}

		private void btnTxtSearch_Click(object sender, EventArgs e)
		{
			if (iSearchedList.Count == 0)
			{
				DataTable copy_dt = GetDataGridViewAsDataTable(csDataGridView1);
				IEnumerable<DataRow> linq_row = null;
				if (txtSearch.Text == "")
				{
					csDataGridView1.DataSource = copy_dt;
				}
				else
				{
					foreach (DataRow row in copy_dt.Rows)
					{
						linq_row = from item in row.ItemArray
								   where item.ToString().ToLower().Contains(txtSearch.Text.ToLower())
								   select row;
						foreach (DataRow dt in linq_row)
						{
							int iCntSearch = copy_dt.Rows.IndexOf(row);
							iSearchedList.Add(iCntSearch);
							break;
						}
					}
					iSelectedRow = iSearchedList.ToList();
				}
			}
			if (iSearchedList.Count > 0)
			{
				int iTestNum = iSelectedRow.Count(n => n == -1);
				if (iTestNum == iSearchedList.Count)
					iSelectedRow = iSearchedList.ToList();
				for (int i = 0; i < iSearchedList.Count; i++)
				{
					if (iSelectedRow[i] == iSearchedList[i])
					{
						csDataGridView1.CurrentCell = csDataGridView1.Rows[iSearchedList[i]].Cells[0];
						iSelectedRow[i] = -1;
						break;
					}
				}
			}
		}

		private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			//공정 아이디
			inspec_op_Code = csDataGridView1["OPERATION_CODE", e.RowIndex].Value.ToString();
			MessageBox.Show($"{inspec_op_Code}를 선택하셨습니다.");

			Op_LoadData();
		}

		private void csDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			inspect_Code = csDataGridView2["INSPECT_ITEM_CODE", e.RowIndex].Value.ToString();
			inspec_op_Code = csDataGridView2["OPERATION_CODE", e.RowIndex].Value.ToString();
			MessageBox.Show($"{inspect_Code} , {inspec_op_Code}를 선택하셨습니다.");
		}

		private void csDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			inspect_Code = csDataGridView3["INSPECT_ITEM_CODE", e.RowIndex].Value.ToString();
			MessageBox.Show($"{inspect_Code}를 선택하셨습니다.");
		}
	}
}
