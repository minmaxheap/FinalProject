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
	public partial class frmUser_MST : MES_Team3.BaseForms.Base1_1
	{
		User_MSTServ serv;
		string Code = string.Empty;
		string ID = frmLogin.userID;

		DataTable dt;
		List<int> iSearchedList;
		List<int> iSelectedRow;

		public frmUser_MST()
		{
			InitializeComponent();
		}

		private void ResetCount()
		{
			iSearchedList.Clear();
			iSelectedRow.Clear();
		}

		private void frmUser_MST_Load(object sender, EventArgs e)
		{
			//			USER_ID
			//USER_NAME
			//USER_GROUP_CODE
			//USER_PASSWORD
			//USER_DEPARTMENT
			//CREATE_TIME
			//CREATE_USER_ID
			//UPDATE_TIME
			//UPDATE_USER_ID


			DataGridViewUtil.SetInitGridView(csDataGridView1);
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "사용자 아이디", "USER_ID");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "사용자 이름", "USER_NAME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "사용자 그룹", "USER_GROUP_CODE");

			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "비밀번호", "USER_PASSWORD");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "부서", "USER_DEPARTMENT");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성시간", "CREATE_TIME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경시간", "UPDATE_TIME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

			iSearchedList = new List<int>();
			iSelectedRow = new List<int>();

			pnlSearch.Visible = false;
			User_MST_Property vo = new User_MST_Property();

			pgProperty.SelectedObject = vo;

			pgProperty.PropertySort = PropertySort.NoSort;

			LoadData();
		}

		private void LoadData()
		{
			serv = new User_MSTServ();
			DataTable dt = serv.GetTable();
			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = dt;

		}

		//검색조건
		private void button3_Click(object sender, EventArgs e)
		{
			User_MST_Property vo = new User_MST_Property();
			vo.IsSearchPanel = true;

			pgSearch.SelectedObject = vo;
			pgSearch.PropertySort = PropertySort.NoSort;
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			User_MST_Property vo = (User_MST_Property)pgProperty.SelectedObject;
			vo.CREATE_USER_ID = ID;

			if (string.IsNullOrWhiteSpace(vo.USER_ID) || string.IsNullOrWhiteSpace(vo.USER_NAME) || string.IsNullOrWhiteSpace(vo.USER_PASSWORD) || string.IsNullOrWhiteSpace(vo.USER_DEPARTMENT))
			{
				MessageBox.Show("필요한 정보가 없으니 다시 확인해주세요.");
				return;
			}

			bool result = serv.Insert(vo);

			if (result)
			{
				MessageBox.Show("등록하였습니다.");
				LoadData();
				return;
			}
			else
			{
				MessageBox.Show("등록 중 실패하였습니다.");
				return;
			}

		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			User_MST_Property pr = (User_MST_Property)pgSearch.SelectedObject;

			if (pr == null)
			{
				MessageBox.Show("검색조건을 키시고 조회 클릭하세요");
				return;
			}

			List<User_MST_Property> list = serv.GetSearch(pr);
			pr.IsSearchPanel = false;

			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = list;

			ResetCount();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			User_MST_Property pr = (User_MST_Property)pgProperty.SelectedObject;
			pr.UPDATE_USER_ID = ID;

		
			if (string.IsNullOrWhiteSpace(pr.UPDATE_USER_ID))
			{
				MessageBox.Show("변경사용자를 입력해주세요");
				return;
			}
			if ( string.IsNullOrWhiteSpace(pr.USER_ID) || string.IsNullOrWhiteSpace(pr.USER_NAME) || string.IsNullOrWhiteSpace(pr.USER_PASSWORD) || string.IsNullOrWhiteSpace(pr.USER_DEPARTMENT))
			{
				MessageBox.Show("필요한 정보가 없으니 다시 확인해주세요.");
				return;
			}
			bool result = serv.Update(pr);
			if (result)
			{
				MessageBox.Show("수정되었습니다.");
				LoadData();
				return;
			}
			else
			{
				MessageBox.Show("수정 중 실패하였습니다.");
				return;
			}

		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			//User_MST_Property pr = (User_MST_Property)pgSearch.SelectedObject;'

			if (string.IsNullOrWhiteSpace(Code))
			{
				MessageBox.Show("삭제할 아이디가 존재하지 않습니다.");
				return;
			}

			bool result = serv.Delete(Code);
			if (result)
			{
				MessageBox.Show("삭제되었습니다.");
				LoadData();
				return;
			}
			else
			{
				MessageBox.Show("삭제 중 실패하였습니다.");
				return;
			}
		}

		

		private void panel6_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
			pd.ResetValue(pgProperty.SelectedObject);

			User_MST_Property search = new User_MST_Property();
			search.IsSearchPanel = false;
			pgProperty.SelectedObject = search;
			pgProperty.PropertySort = PropertySort.NoSort;
		}

		//아래로 내려가듯이
		private void button2_Click(object sender, EventArgs e)
		{
		
		}

		private DataGridViewCell GetCellWhereTextExistsInGridView(string searchText, DataGridView dataGridView, int columnIndex)
		{
			DataGridViewCell cellWhereTextIsMet = null;

			// For every row in the grid (obviously)
			foreach (DataGridViewRow row in csDataGridView1.Rows)
			{
				// I did not test this case, but cell.Value is an object, and objects can be null
				// So check if the cell is null before using .ToString()
				if (row.Cells[columnIndex].Value != null && searchText == row.Cells[columnIndex].Value.ToString())
				{
					// the searchText is equals to the text in this cell.
					cellWhereTextIsMet = row.Cells[columnIndex];
					//break;
				}
			}
			

			return cellWhereTextIsMet;
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

		private void btnReadTop_Click(object sender, EventArgs e)
		{
			User_MST_Property pr = (User_MST_Property)pgSearch.SelectedObject;

			if (pr == null)
			{
				MessageBox.Show("검색조건을 키시고 조회 클릭하세요");
				return;
			}

			List<User_MST_Property> list = serv.GetSearch(pr);
			pr.IsSearchPanel = false;

			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = list;

			ResetCount();
		}

		private void btnClear_Click_1(object sender, EventArgs e)
		{
			PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
			pd.ResetValue(pgProperty.SelectedObject);

			User_MST_Property search = new User_MST_Property();
			search.IsSearchPanel = false;
			pgProperty.SelectedObject = search;
			pgProperty.PropertySort = PropertySort.NoSort;
		}

		private void btnPanel_Click(object sender, EventArgs e)
		{
			User_MST_Property vo = new User_MST_Property();
			vo.IsSearchPanel = true;

			pgSearch.SelectedObject = vo;

			pgSearch.PropertySort = PropertySort.NoSort;

			ResetCount();
		}

		private void csDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			//아이디
			Code = csDataGridView1["USER_ID", e.RowIndex].Value.ToString();
			MessageBox.Show($"{Code}를 선택하셨습니다.");


			DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
			User_MST_Property vo = new User_MST_Property();
			BIsSearchPanel = false;
			vo.IsSearchPanel = false;

			if (dr.Cells["USER_ID"].Value != null && dr.Cells["USER_ID"].Value != DBNull.Value)
				vo.USER_ID = dr.Cells["USER_ID"].Value.ToString();

			if (dr.Cells["USER_NAME"].Value != null && dr.Cells["USER_NAME"].Value != DBNull.Value)
				vo.USER_NAME = dr.Cells["USER_NAME"].Value.ToString();

			if (dr.Cells["USER_GROUP_CODE"].Value != null && dr.Cells["USER_GROUP_CODE"].Value != DBNull.Value)
				vo.USER_GROUP_CODE = dr.Cells["USER_GROUP_CODE"].Value.ToString();

			if (dr.Cells["USER_PASSWORD"].Value != null && dr.Cells["USER_PASSWORD"].Value != DBNull.Value)
				vo.USER_PASSWORD = dr.Cells["USER_PASSWORD"].Value.ToString();

			if (dr.Cells["USER_DEPARTMENT"].Value != null && dr.Cells["USER_DEPARTMENT"].Value != DBNull.Value)
				vo.USER_DEPARTMENT = dr.Cells["USER_DEPARTMENT"].Value.ToString();

			if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
				vo.CREATE_USER_ID = dr.Cells["CREATE_USER_ID"].Value.ToString();

			if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
				vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

			if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
				vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);


			if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
				vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);


			pgProperty.SelectedObject = vo;

			pgProperty.PropertySort = PropertySort.NoSort;


			pnlProperty.Visible = true;
			pnlSearch.Visible = false;
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
	}
}
