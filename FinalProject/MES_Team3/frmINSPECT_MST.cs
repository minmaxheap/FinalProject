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
        string Inspect_id = string.Empty;
        int rowIndex;

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

            BSearchPanel = false;
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
            INSPECT_MSTVO vo = new INSPECT_MSTVO();
            vo.IsSearchPanel = true;

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
            BSearchPanel = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //수정

            // Inspect_id 
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
                MessageBox.Show("삭제 중 실패되었습니다.");
                return;
            }

        }

        private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //이거 안됨 
            if (e.RowIndex < 0)
            {
                return;
            }

            //아이디
            Inspect_id = csDataGridView1["INSPECT_ITEM_CODE", e.RowIndex].Value.ToString();
            MessageBox.Show($"{Inspect_id}를 선택하셨습니다.");


            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            INSPECT_MSTVO vo = new INSPECT_MSTVO();
            lblPanel.Text = "▶ 속성";
            vo.IsSearchPanel = false;
            vo.INSPECT_ITEM_CODE = dr.Cells["INSPECT_ITEM_CODE"].Value.ToString();
            vo.INSPECT_ITEM_NAME = dr.Cells["INSPECT_ITEM_NAME"].Value.ToString();
            vo.VALUE_TYPE = dr.Cells["VALUE_TYPE"].Value.ToString();
            vo.SPEC_LSL = dr.Cells["SPEC_LSL"].Value.ToString();
            vo.SPEC_USL = dr.Cells["SPEC_USL"].Value.ToString();

            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);

            vo.CREATE_USER_ID = dr.Cells["CREATE_USER_ID"].Value.ToString();

            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);

            vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            pgGrid.SelectedObject = vo;

            pgGrid.PropertySort = PropertySort.NoSort;


            pnlProperty.Visible = true;
            pnlSearch.Visible = false;


        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //SearchVo vo = new SearchVo();
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgSearch.SelectedObject;

            List<INSPECT_MSTVO> list = serv.GetINSPECT_MST_Search(save);
            save.IsSearchPanel = false;

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgGrid.SelectedObject;
            InspecServ serv = new InspecServ();
            bool bResult = serv.Update(save);
            if (bResult)
            {
                MessageBox.Show("수정되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("수정중 실패");
                return;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pgGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "C")
            {
                INSPECT_MSTVO vo = new INSPECT_MSTVO();
                vo.SPEC_LSL = "";
                vo.SPEC_USL = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PropertyDescriptor pd = pgGrid.SelectedGridItem.PropertyDescriptor;
            pd.ResetValue(pgGrid.SelectedObject);

            INSPECT_MSTVO search = new INSPECT_MSTVO();
            search.IsSearchPanel = false;
            pgGrid.SelectedObject = search;
            pgGrid.PropertySort = PropertySort.NoSort;
        }

        // Like 부분을 써서 사용해야함 
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            int cr = -1;
            csDataGridView1.Rows[rowIndex].Selected = false;

            MessageBox.Show("1번째" + rowIndex.ToString());
            //csDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //try
            //{
            //    foreach (DataGridViewRow row in csDataGridView1.Rows)
            //    {
            //        if (row.Cells["검사항목명"].Value.ToString().Equals(searchValue))
            //        {
            //            rowIndex++;
            //            csDataGridView1.Rows[rowIndex].Selected = true;

            //            break;
            //        }
            //    }
            //    MessageBox.Show("3번째" + rowIndex.ToString());

            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}

        }
    }
}


