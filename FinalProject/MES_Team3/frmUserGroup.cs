using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;
using DAC;

namespace MES_Team3
{
	public partial class frmUserGroup : MES_Team3.BaseForms.Base1_1
	{
		UserGroupServ serv;
		string Code = string.Empty;
		public frmUserGroup()
		{
			InitializeComponent();
		}

		private void frmUserGroup_Load(object sender, EventArgs e)
		{
			//USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID from USER_GROUP_MST
			DataGridViewUtil.SetInitGridView(csDataGridView1);
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "사용자 그룹", "USER_GROUP_CODE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "사용자 그룹명", "USER_GROUP_NAME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "사용자 그룹 유형", "USER_GROUP_TYPE");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성시간", "CREATE_TIME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용지", "CREATE_USER_ID");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경시간", "UPDATE_TIME");
			DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

			

			searchPanel.Visible = false;
			UserGroupVO vo = new UserGroupVO();

			pgProperty.SelectedObject = vo;

			pgProperty.PropertySort = PropertySort.NoSort;

			LoadData();

		}

		private void LoadData()
		{
			serv = new UserGroupServ();
			DataTable dt = serv.GetTable();
			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = dt;
			searchPanel.Visible = false;

		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
            UserGroupVO vo = (UserGroupVO)pgProperty.SelectedObject;
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

		//조회조건으로 조회 

		private void btnRead_Click(object sender, EventArgs e)
		{
			UserGroupVO save = (UserGroupVO)pgSearch.SelectedObject;

			List<UserGroupVO> list = serv.GetSearch(save);
			save.IsSearchPanel = false;

			csDataGridView1.DataSource = list;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UserGroupVO vo = (UserGroupVO)pgProperty.SelectedObject;


			bool result = serv.Update(vo);

			if (result)
			{
				MessageBox.Show("수정하였습니다.");
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
			bool result = serv.Delete(Code);

			if (result)
			{
				MessageBox.Show("삭제하였습니다.");
				LoadData();
				return;
			}
			else
			{
				MessageBox.Show("삭제 중 실패하였습니다.");
				return;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			UserGroupVO vo = new UserGroupVO();
			vo.IsSearchPanel = true;

			pgSearch.SelectedObject = vo;
			pgSearch.PropertySort = PropertySort.NoSort;

		}

		private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//이거 안됨 
			if (e.RowIndex < 0)
			{
				return;
			}

			//아이디
			Code = csDataGridView1["USER_GROUP_CODE", e.RowIndex].Value.ToString();
			MessageBox.Show($"{Code}를 선택하셨습니다.");


			DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
			UserGroupVO vo = new UserGroupVO();
			lblPanel.Text = "▶ 속성";
			vo.IsSearchPanel = false;
			vo.USER_GROUP_CODE = dr.Cells["USER_GROUP_CODE"].Value.ToString();
			vo.USER_GROUP_NAME = dr.Cells["USER_GROUP_NAME"].Value.ToString();
			vo.USER_GROUP_TYPE = dr.Cells["USER_GROUP_TYPE"].Value.ToString();
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

		private void btnClear_Click(object sender, EventArgs e)
		{
			PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
			pd.ResetValue(pgProperty.SelectedObject);

			UserGroupVO search = new UserGroupVO();
			search.IsSearchPanel = false;
			pgProperty.SelectedObject = search;
			pgProperty.PropertySort = PropertySort.NoSort;
		}
	}
}
