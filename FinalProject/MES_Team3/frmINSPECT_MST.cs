using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{

    public partial class frmINSPECT_MST : MES_Team3.Base1_1
    {
        DataTable dt;
        List<int> iSearchedList;
        List<int> iSelectedRow;

        InspecServ serv = null;
        string Inspect_id = string.Empty;
        int rowIndex;
        string mUserID = frmLogin.userID;


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
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "Target", "SPEC_TARGET");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "USL", "SPEC_USL");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            iSearchedList = new List<int>();
            iSelectedRow = new List<int>();

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
            save.CREATE_USER_ID = mUserID;
            InspecServ serv = new InspecServ();

            if (string.IsNullOrWhiteSpace(save.INSPECT_ITEM_CODE) || string.IsNullOrWhiteSpace(save.INSPECT_ITEM_NAME) || string.IsNullOrWhiteSpace(save.VALUE_TYPE))
            {
                MessageBox.Show("필요한 값을 입력해주세요");
                return;
            }

            if (save.VALUE_TYPE == "N")
            {
                if (string.IsNullOrWhiteSpace(save.SPEC_LSL) || string.IsNullOrWhiteSpace(save.SPEC_USL))
                {
                    MessageBox.Show("LSL,USL을 입력해주세요");
                    return;
                }
            }
            if (save.VALUE_TYPE == "C")
            {
                if (string.IsNullOrWhiteSpace(save.SPEC_TARGET))
                {
                    MessageBox.Show("Target 입력하세요");
                    return;
                }
            }

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
            dt = serv.GetTable();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            BSearchPanel = false;

            ResetCount();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //수정

            // Inspect_id 
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgGrid.SelectedObject;

            if (save == null)
            {
                MessageBox.Show("아이디가 존재 하지않습니다.");
                return;
            }

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


        private void btnRead_Click(object sender, EventArgs e)
        {
            //SearchVo vo = new SearchVo();
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgSearch.SelectedObject;
            if (save == null)
            {
                MessageBox.Show("검색조건을 키시고 조회 클릭하세요");
                return;
            }

            List<INSPECT_MSTVO> list = serv.GetINSPECT_MST_Search(save);
            save.IsSearchPanel = false;

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;

            //txtSearch.Text = save.INSPECT_ITEM_CODE;

            ResetCount();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgGrid.SelectedObject;
            save.UPDATE_USER_ID = mUserID;
            // save.CREATE_USER_ID = null;
            //save.CREATE_TIME = DateTime.n;
            InspecServ serv = new InspecServ();
            if (string.IsNullOrWhiteSpace(save.INSPECT_ITEM_CODE) || string.IsNullOrWhiteSpace(save.INSPECT_ITEM_NAME))
            {
                MessageBox.Show("필요한 값을 입력해주세요");
                return;
            }
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
            //double k;
            //if (e.ChangedItem.Label == "C")
            //{
            //    INSPECT_MSTVO vo = new INSPECT_MSTVO();

            //    if (!double.TryParse(e.ChangedItem.Value.ToString(), out k))
            //    {
            //        MessageBox.Show("문자 입력 할수없습니다.");

            //        return;
            //    }
            //}
            //else
            //{
            //    if (double.TryParse(e.ChangedItem.Value.ToString(), out k))
            //    {
            //        INSPECT_MSTVO vo = new INSPECT_MSTVO();
            //        MessageBox.Show("문자 입력하세요.");
            //        vo.SPEC_LSL = string.Empty;

            //        return;
            //    }
            //}

            ////int k;
            ////    //if (e.ChangedItem.Label == "품번")
            ////    //{
            ////    //    if (!int.TryParse(e.ChangedItem.Value.ToString(), out k))
            ////    //    {
            ////    //        MessageBox.Show("문자 입력할 수 없습니다");
            ////    //    }
            ////    //}
            //if (e.ChangedItem.Label == "LSL")
            //{

            //}
            

            int k;
            INSPECT_MSTVO vo = (INSPECT_MSTVO)pgGrid.SelectedObject;

            if (e.ChangedItem.Label == "LSL" || (e.ChangedItem.Label =="USL"))
            {
                if (!int.TryParse(e.ChangedItem.Value.ToString(), out k))
                {
                    MessageBox.Show("문자 입력할 수 없습니다");
                    vo.SPEC_LSL = null;

                    this.currentItem = e.ChangedItem;

                    this.BeginInvoke(new MethodInvoker(reset));//re-select the changed item.

                }

            }

            if (e.ChangedItem.Label == "C")
            {
                if (e.ChangedItem.Label == "Target")
                {
                    if (int.TryParse(e.ChangedItem.Value.ToString(), out k))
                    {
                        MessageBox.Show("숫자 입력할 수 없습니다");
                        vo.SPEC_TARGET = null;

                        this.currentItem = e.ChangedItem;

                        this.BeginInvoke(new MethodInvoker(reset));//re-select the changed item.

                    }

                }
            }

        }

        private GridItem currentItem;


        private void ResetCount()
        {
            iSearchedList.Clear();
            iSelectedRow.Clear();
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

        //private void D()
        //{
        //    //KeyEventArgs enter = new KeyEventArgs(Keys.Enter);

        //    // txtSearch_KeyDown(null,enter);

        //    //int row = csDataGridView1.CurrentCellAddress.Y + 1;
        //    //csDataGridView1.CurrentCell = csDataGridView1.Rows[row].Cells[0];

        //    //         string searchValue = txtSearch.Text;
        //    //         bool check = false;
        //    ////MessageBox.Show("1번째" + rowIndex.ToString());
        //    ////csDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    //try
        //    //         {

        //    //            // csDataGridView1.CurrentCell = csDataGridView1.Rows[row].Cells[0];
        //    //             for (int i = csDataGridView1.CurrentCell.RowIndex; i < csDataGridView1.Rows.Count; i++)
        //    //             {
        //    //                 //i = csDataGridView1.CurrentCellAddress.Y + 1;
        //    //                 if (csDataGridView1.Rows[i].Cells[0].Value.ToString().Contains(searchValue))
        //    //                 {

        //    //                     check = true;
        //    //                     csDataGridView1.Rows[i].Selected = true;

        //    //                     csDataGridView1.CurrentCell = csDataGridView1[0, i];

        //    //                     break;
        //    //                 }

        //    //                 csDataGridView1.Rows[i].Selected = false;
        //    //             }
        //    //             if (!check)
        //    //             {
        //    //                 for (int j = 0; j < csDataGridView1.Rows.Count; j++)
        //    //                 {
        //    //                     if (csDataGridView1.Rows[j].Cells[0].Value.ToString().Contains(searchValue))
        //    //                     {
        //    //                         check = true;
        //    //                         csDataGridView1.Rows[j].Selected = true;

        //    //                         break;
        //    //                     }
        //    //                 }
        //    //             }
        //    //             if (check)
        //    //             {
        //    //                 MessageBox.Show("검색완료");
        //    //                 return;
        //    //             }

        //    //	//MessageBox.Show("3번째" + rowIndex.ToString());

        //    //}
        //    //catch (Exception exc)
        //    //{
        //    //	MessageBox.Show(exc.Message);
        //    //}
        //}

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
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }   

        private void btnPanel_Click(object sender, EventArgs e)
		{
            INSPECT_MSTVO vo = new INSPECT_MSTVO();
            vo.IsSearchPanel = true;

            pgSearch.SelectedObject = vo;

            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
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

		private void csDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
          

        }

        private void reset()

        {

            if (currentItem != null)

            {

                currentItem.Select();

            }

        }

		private void btnReadTop_Click(object sender, EventArgs e)
		{
            //SearchVo vo = new SearchVo();
            INSPECT_MSTVO save = (INSPECT_MSTVO)pgSearch.SelectedObject;
            if (save == null)
            {
                MessageBox.Show("검색조건을 키시고 조회 클릭하세요");
                return;
            }

            List<INSPECT_MSTVO> list = serv.GetINSPECT_MST_Search(save);
            save.IsSearchPanel = false;

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;

            ResetCount();
        }

		private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            //이거 안됨 
            if (e.RowIndex < 0)
            {
                return;
            }

            //아이디
            Inspect_id = csDataGridView1["INSPECT_ITEM_CODE", e.RowIndex].Value.ToString();
            MessageBox.Show($"{Inspect_id}를 선택하셨습니다.");

            //유효값 처리

            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            INSPECT_MSTVO vo = new INSPECT_MSTVO();
            BIsSearchPanel = false;
            vo.IsSearchPanel = false;

            if (dr.Cells["INSPECT_ITEM_CODE"].Value != null && dr.Cells["INSPECT_ITEM_CODE"].Value != DBNull.Value)
                vo.INSPECT_ITEM_CODE = dr.Cells["INSPECT_ITEM_CODE"].Value.ToString();

            if (dr.Cells["INSPECT_ITEM_NAME"].Value != null && dr.Cells["INSPECT_ITEM_NAME"].Value != DBNull.Value)
                vo.INSPECT_ITEM_NAME = dr.Cells["INSPECT_ITEM_NAME"].Value.ToString();

            if (dr.Cells["VALUE_TYPE"].Value != null && dr.Cells["VALUE_TYPE"].Value != DBNull.Value)
                vo.VALUE_TYPE = dr.Cells["VALUE_TYPE"].Value.ToString();

            if (dr.Cells["SPEC_LSL"].Value != null && dr.Cells["SPEC_LSL"].Value != DBNull.Value)
                vo.SPEC_LSL = dr.Cells["SPEC_LSL"].Value.ToString();

            if (dr.Cells["SPEC_USL"].Value != null && dr.Cells["SPEC_USL"].Value != DBNull.Value)
                vo.SPEC_USL = dr.Cells["SPEC_USL"].Value.ToString();


            if (dr.Cells["SPEC_TARGET"].Value != null && dr.Cells["SPEC_TARGET"].Value != DBNull.Value)
                vo.SPEC_TARGET = dr.Cells["SPEC_TARGET"].Value.ToString();

            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);

            if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
                vo.CREATE_USER_ID = dr.Cells["CREATE_USER_ID"].Value.ToString();

            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);

            if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
                vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            pgGrid.SelectedObject = vo;

            pgGrid.PropertySort = PropertySort.NoSort;


            pnlProperty.Visible = true;
            pnlSearch.Visible = false;
        }
	}
}


