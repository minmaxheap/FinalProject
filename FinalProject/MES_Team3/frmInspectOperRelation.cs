using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmInspectOperRelation : MES_Team3.Base3_1
    {
        INSPECT_OPServ serv = null;
        public frmInspectOperRelation()
        {
            InitializeComponent();
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

			LoadData();

			INSPECT_OPERATIONProperty pr = new INSPECT_OPERATIONProperty();

			pgdSearch.SelectedObject = pr;

			pgdSearch.PropertySort = PropertySort.NoSort;
		}

		private void LoadData()
		{
			serv = new INSPECT_OPServ();
			DataTable dt = serv.Op_GetTable();
			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = dt;

		}

		//조회조건
		private void btnReadBottom_Click(object sender, EventArgs e)
		{
			INSPECT_OPERATIONProperty pr = (INSPECT_OPERATIONProperty)pgdSearch.SelectedObject;

			List<INSPECT_OPERATIONProperty> list = serv.GetSearch(pr);
			//pr.IsSearchPanel = false;

			csDataGridView1.DataSource = null;
			csDataGridView1.DataSource = list;
		}
	}
}
