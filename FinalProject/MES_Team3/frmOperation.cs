using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmOperation : MES_Team3.BaseForms.Base1_1
    {
        //public List<Bar> barlist;
        public frmOperation()
        {
            InitializeComponent();
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정명", "OPERATION_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "불량 입력", "CHECK_DEFECT_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사 데이터 입력", "CHECK_INSPECT_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 사용", "CHECK_MATERIAL_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            OperationProperty vo = new OperationProperty();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;


        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            OperationProperty save = (OperationProperty)pgProperty.SelectedObject;
            OperationServ serv = new OperationServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                LoadData();
            }
            else
            {
                
            }
        }


        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            OperationProperty vo = new OperationProperty();
            //vo.OPERATION_CODE = dr.Cells["OPERATION_CODE"].Value.ToString();
            //vo.OPERATION_NAME = dr.Cells["OPERATION_NAME"].Value.ToString();
            //vo.CHECK_DEFECT_FLAG = dr.Cells["CHECK_DEFECT_FLAG"].Value.ToString();
            //vo.CHECK_INSPECT_FLAG = dr.Cells["CHECK_INSPECT_FLAG"].Value.ToString();
            //vo.CHECK_MATERIAL_FLAG = dr.Cells["CHECK_MATERIAL_FLAG"].Value.ToString();
            //if (csDataGridView1.Rows[e.RowIndex].Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
            //    vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            //vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            //if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
            //    vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            //vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            if (dr.Cells["OPERATION_CODE"].Value != null && dr.Cells["OPERATION_CODE"].Value != DBNull.Value)
                vo.OPERATION_CODE = dr.Cells["OPERATION_CODE"].Value.ToString();
            if (dr.Cells["OPERATION_NAME"].Value != null && dr.Cells["OPERATION_NAME"].Value != DBNull.Value)
                vo.OPERATION_NAME = dr.Cells["OPERATION_NAME"].Value.ToString();
            if (dr.Cells["CHECK_DEFECT_FLAG"].Value != null && dr.Cells["CHECK_DEFECT_FLAG"].Value != DBNull.Value)
                vo.CHECK_DEFECT_FLAG = dr.Cells["CHECK_DEFECT_FLAG"].Value.ToString();
            if (dr.Cells["CHECK_INSPECT_FLAG"].Value != null && dr.Cells["CHECK_INSPECT_FLAG"].Value != DBNull.Value)
                vo.CHECK_INSPECT_FLAG = dr.Cells["CHECK_INSPECT_FLAG"].Value.ToString();
            if (dr.Cells["CHECK_MATERIAL_FLAG"].Value != null && dr.Cells["CHECK_MATERIAL_FLAG"].Value != DBNull.Value)
                vo.CHECK_MATERIAL_FLAG = dr.Cells["CHECK_MATERIAL_FLAG"].Value.ToString();
            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
                vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
                vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pk를 받아서 delete 하기 //이거 유틸로 할 수 있지 않을까? 

            OperationProperty save = (OperationProperty)pgProperty.SelectedObject;
            OperationServ serv = new OperationServ();
            bool bResult = serv.Delete(save);
            LoadData();

        }

        public void LoadData()
        {
            OperationServ serv = new OperationServ();
            DataTable dt = serv.GetOperationList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            SearchPanel = false;
        }

		private void button3_Click(object sender, EventArgs e)
		{

            OperationProperty search = new OperationProperty();

            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            // propertyPanel.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OperationProperty save = (OperationProperty)pgProperty.SelectedObject;
            OperationServ serv = new OperationServ();
            bool bResult = serv.Update(save);
            LoadData();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OperationProperty search = (OperationProperty)pgSearch.SelectedObject;
            OperationServ serv = new OperationServ();
            List<OperationProperty> list = serv.GetOperationSearch(search);
            csDataGridView1.DataSource = list;

        }
    }


}
