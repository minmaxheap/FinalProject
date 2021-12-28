using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAC;
namespace MES_Team3
{
	public partial class frmUser_MST : MES_Team3.BaseForms.Base1_1
	{
		User_MSTServ serv;
		string Code = string.Empty;
		public frmUser_MST()
		{
			InitializeComponent();
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



			searchPanel.Visible = false;
			User_MST_Property vo  = new User_MST_Property();

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

			List<User_MST_Property> list = serv.GetSearch(pr);
			pr.IsSearchPanel = false;

			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = list;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			User_MST_Property pr = (User_MST_Property)pgProperty.SelectedObject;
			if (string.IsNullOrWhiteSpace(pr.UPDATE_USER_ID))
			{
				MessageBox.Show("변경사용자를 입력해주세요");
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
			User_MST_Property pr = (User_MST_Property)pgSearch.SelectedObject;

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

		private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

			if (e.RowIndex < 0)
			{
				return;
			}

			//아이디
			Code = csDataGridView1["USER_ID", e.RowIndex].Value.ToString();
			MessageBox.Show($"{Code}를 선택하셨습니다.");


			DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
			User_MST_Property vo = new User_MST_Property();
			lblPanel.Text = "▶ 속성";
			vo.IsSearchPanel = false;
			vo.USER_ID = dr.Cells["USER_ID"].Value.ToString();
			vo.USER_NAME = dr.Cells["USER_NAME"].Value.ToString();
			vo.USER_GROUP_CODE = dr.Cells["USER_GROUP_CODE"].Value.ToString();
			vo.USER_PASSWORD = dr.Cells["USER_PASSWORD"].Value.ToString();
			vo.USER_DEPARTMENT = dr.Cells["USER_DEPARTMENT"].Value.ToString();

			vo.CREATE_USER_ID = dr.Cells["CREATE_TIME"].Value.ToString();
			vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

			if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
				vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);


			if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
				vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);


			pgProperty.SelectedObject = vo;

			pgProperty.PropertySort = PropertySort.NoSort;


			propertyPanel.Visible = true;
			searchPanel.Visible = false;
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
			String searchValue = textBox1.Text;
			int rowIndex = -1;
			foreach (DataGridViewRow row in csDataGridView1.Rows)
			{
				if (row.Cells[2].Value.ToString().Equals(textBox1.Text))
				{
					rowIndex = row.Index;
					break;
				}
			}

			csDataGridView1.Rows[rowIndex].Selected = true;
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
	}
}
