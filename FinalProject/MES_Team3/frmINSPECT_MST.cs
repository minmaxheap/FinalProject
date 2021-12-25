using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmINSPECT_MST : MES_Team3.BaseForms.Base1_1
    {
        InspecServ serv = null;
        public frmINSPECT_MST()
        {
            InitializeComponent();
        }

		private void frmINSPECT_MST_Load(object sender, EventArgs e)
		{

            //INSPECT_ITEM_CODE
            //,[INSPECT_ITEM_NAME]
            //    ,[VALUE_TYPE]
            //    ,[SPEC_LSL]
            //    ,[SPEC_TARGET]
            //    ,[SPEC_USL]
            //    ,[CREATE_TIME]
            //    ,[CREATE_USER_ID]
            //    ,[UPDATE_TIME]
            //    ,[UPDATE_USER_ID]

            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사항목", "INSPECT_ITEM_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사항목명", "INSPECT_ITEM_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "값 유형", "VALUE_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LSL", "SPEC_LSL");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "Target", "SPEC_USL");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "USL", "SPEC_USL");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            SearchPanel = false;
            INSPECT_MSTVO vo = new INSPECT_MSTVO();

            pgGrid.SelectedObject = vo;

            pgGrid.PropertySort = PropertySort.NoSort;
        }

		private void Search_Grid_Click(object sender, EventArgs e)
		{

        }

        //검색조건 
		private void button3_Click(object sender, EventArgs e)
		{
            SearchVo vo = new SearchVo();

            pgSearch.SelectedObject = vo;

            pgSearch.PropertySort = PropertySort.NoSort;
        }

		private void btnInsert_Click(object sender, EventArgs e)
		{
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgGrid.SelectedObject;
            InspecServ serv = new InspecServ();
            bool bResult = serv.insert(save);
            if (bResult)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("등록중 실패");
                return;
            }
        }

        private void LoadData()
        {
            serv = new InspecServ();
            DataTable dt = serv.GetTable();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            SearchPanel = false;
        }

		private void btnDelete_Click(object sender, EventArgs e)
        {

            INSPECT_MSTVO save = (INSPECT_MSTVO)pgGrid.SelectedObject;

            bool result = serv.Delete(save);
            if (result)
            {
                MessageBox.Show("삭제되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("수정되었습니다.");
                return;
            }
            
        }

		private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
            INSPECT_MSTVO vo = new INSPECT_MSTVO(csDataGridView1.Rows[e.RowIndex]); //데이터그리드뷰 row를 한 개만 선택되는 경우로 상정함

            pgGrid.SelectedObject = vo;

            pgGrid.PropertySort = PropertySort.NoSort;
        }

		private void btnRead_Click(object sender, EventArgs e)
		{
            SearchVo vo = new SearchVo();

            pgSearch.SelectedObject = vo;

            if (pgSearch.SelectedObject == null)
            {
                MessageBox.Show("rr");
                return; 
            }
        }
	}
}
