﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAC;

namespace MES_Team3
{
	public partial class frmUserGroup : MES_Team3.BaseForms.Base1_1
	{
		UserGroupServ serv;
		string Code = string.Empty;
		string ID = frmLogin.userID;
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

			

			pnlSearch.Visible = false;
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
			pnlSearch.Visible = false;

		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
            UserGroupVO vo = (UserGroupVO)pgProperty.SelectedObject;
			vo.CREATE_USER_ID = ID;

			if (string.IsNullOrWhiteSpace(vo.USER_GROUP_CODE) || string.IsNullOrWhiteSpace(vo.USER_GROUP_NAME) || string.IsNullOrWhiteSpace(vo.USER_GROUP_NAME))
			{
				MessageBox.Show("필요한 정보가 없습니다.");
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

		//조회조건으로 조회 

		private void btnRead_Click(object sender, EventArgs e)
		{
			UserGroupVO save = (UserGroupVO)pgSearch.SelectedObject;

			if (save == null)
			{
				MessageBox.Show("검색조건을 키시고 조회 클릭하세요");
				return;
			}

			List<UserGroupVO> list = serv.GetSearch(save);
			save.IsSearchPanel = false;

			csDataGridView1.DataSource = list;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UserGroupVO vo = (UserGroupVO)pgProperty.SelectedObject;
			vo.UPDATE_USER_ID = ID;

			if (string.IsNullOrWhiteSpace(vo.USER_GROUP_CODE) || string.IsNullOrWhiteSpace(vo.USER_GROUP_NAME) || string.IsNullOrWhiteSpace(vo.USER_GROUP_NAME))
			{
				MessageBox.Show("필요한 정보가 없습니다.");
				return;
			}
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
			if (string.IsNullOrWhiteSpace(Code))
			{
				MessageBox.Show("해당 코드(아이디가 존재하지 않습니다.");
				return;
			}
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

		

		private void btnClear_Click(object sender, EventArgs e)
		{
			PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
			pd.ResetValue(pgProperty.SelectedObject);

			UserGroupVO search = new UserGroupVO();
			search.IsSearchPanel = false;
			pgProperty.SelectedObject = search;
			pgProperty.PropertySort = PropertySort.NoSort;
		}

		private void btnPanel_Click(object sender, EventArgs e)
		{

			UserGroupVO vo = new UserGroupVO();
			vo.IsSearchPanel = true;

			pgSearch.SelectedObject = vo;

			pgSearch.PropertySort = PropertySort.NoSort;
		}

		private void btnReadTop_Click(object sender, EventArgs e)
		{
			UserGroupVO save = (UserGroupVO)pgSearch.SelectedObject;

			if (save == null)
			{
				MessageBox.Show("검색조건을 키시고 조회 클릭하세요");
				return;
			}

			List<UserGroupVO> list = serv.GetSearch(save);
			save.IsSearchPanel = false;

			csDataGridView1.DataSource = list;
		}

		private void csDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
			BIsSearchPanel = false;
			vo.IsSearchPanel = false;
			//lblPanel.Text = "▶ 속성";
			//lblPanel.BackColor = Color.FromArgb(82, 152, 216);
			//btnPanel.BackColor = lblPanel.BackColor;
			//vo.IsSearchPanel = false;
			if (dr.Cells["USER_GROUP_CODE"].Value != null && dr.Cells["USER_GROUP_CODE"].Value != DBNull.Value)
				vo.USER_GROUP_CODE = dr.Cells["USER_GROUP_CODE"].Value.ToString();

			if (dr.Cells["USER_GROUP_NAME"].Value != null && dr.Cells["USER_GROUP_NAME"].Value != DBNull.Value)
				vo.USER_GROUP_NAME = dr.Cells["USER_GROUP_NAME"].Value.ToString();
			vo.USER_GROUP_TYPE = dr.Cells["USER_GROUP_TYPE"].Value.ToString();

			if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
				vo.CREATE_USER_ID = dr.Cells["CREATE_USER_ID"].Value.ToString();

			if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
				vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString(); ;

			if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
				vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);


			if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
				vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);


			pgProperty.SelectedObject = vo;

			pgProperty.PropertySort = PropertySort.NoSort;


			pnlProperty.Visible = true;
			pnlSearch.Visible = false;
		}
	}
}
