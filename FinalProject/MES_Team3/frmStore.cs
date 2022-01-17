using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmStore : MES_Team3.Base1_1
    {
        List<StoreVO> allList;
        DataTable mdtAll;
        //string msUserID;
        string msUserID = frmLogin.userID;
        List<int> iSearchedList;
        List<int> iSelectedRow;
        public frmStore()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            StoreServ serv = new StoreServ();
            allList = serv.GetStoreList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = allList;
            BSearchPanel = false;
        }

        private void frmStore_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고", "STORE_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고명", "STORE_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고 유형", "STORE_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "선입선출 여부", "FIFO_FLAG", width: 120);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME", DataGridViewContentAlignment.MiddleLeft, 140);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME", DataGridViewContentAlignment.MiddleLeft, 140);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");
            csDataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            csDataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            List<StoreVO> list = new List<StoreVO>();
            iSearchedList = new List<int>();
            iSelectedRow = new List<int>();


            LoadData();

            StoreVO vo = new StoreVO();

            pgProperty.SelectedObject = vo;
            vo.IsSearchPanel = false;

            pgProperty.PropertySort = PropertySort.NoSort;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            StoreVO save = (StoreVO)pgProperty.SelectedObject;
            save.CREATE_USER_ID = msUserID;
            StoreServ serv = new StoreServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("등록 중 실패하였습니다.");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StoreVO save = (StoreVO)pgProperty.SelectedObject;
            StoreServ serv = new StoreServ();
            bool bResult = serv.Delete(save);
            if (bResult)
            {
                MessageBox.Show("삭제되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("삭제 중 실패하였습니다.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StoreVO save = (StoreVO)pgProperty.SelectedObject;
            save.UPDATE_USER_ID = msUserID;
            StoreServ serv = new StoreServ();
            bool bResult = serv.Update(save);
            if (bResult)
            {
                MessageBox.Show("수정되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("수정 중 실패하였습니다.");
            }
        }

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            StoreVO vo = new StoreVO();
            BIsSearchPanel = false;
            vo.IsSearchPanel = false;

            if (dr.Cells["STORE_CODE"].Value != null && dr.Cells["STORE_CODE"].Value != DBNull.Value)
                vo.STORE_CODE = dr.Cells["STORE_CODE"].Value.ToString();
            if (dr.Cells["STORE_NAME"].Value != null && dr.Cells["STORE_NAME"].Value != DBNull.Value)
                vo.STORE_NAME = dr.Cells["STORE_NAME"].Value.ToString();
            if (dr.Cells["STORE_TYPE"].Value != null && dr.Cells["STORE_TYPE"].Value != DBNull.Value)
                vo.STORE_TYPE = dr.Cells["STORE_TYPE"].Value.ToString();
            if (dr.Cells["FIFO_FLAG"].Value != null && dr.Cells["FIFO_FLAG"].Value != DBNull.Value)
                vo.FIFO_FLAG = dr.Cells["FIFO_FLAG"].Value.ToString();
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

            pgProperty.Visible = true;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (pgProperty.SelectedGridItem != null)
            {
                PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
                pd.ResetValue(pgProperty.SelectedObject);

                StoreVO sv = new StoreVO();
                sv.IsSearchPanel = false;
                pgProperty.SelectedObject = sv;
                pgProperty.PropertySort = PropertySort.NoSort;
            }
        }

        private void btnSearchPnl_Click(object sender, EventArgs e)
        {

            StoreVO search = new StoreVO();
            search.IsSearchPanel = true;
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            // propertyPanel.Visible = false;
        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {
            if (pgSearch.SelectedObject != null)
            {
                StoreVO search = (StoreVO)pgSearch.SelectedObject;
                StoreServ serv = new StoreServ();
                List<StoreVO> list = serv.GetStoreSearch(search);
                search.IsSearchPanel = false;

                csDataGridView1.DataSource = null;
                csDataGridView1.DataSource = list;
            }
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            StoreVO search = new StoreVO();
            search.IsSearchPanel = true;
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            // propertyPanel.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (iSearchedList.Count == 0)
                {
                    DataTable copy_dt = mdtAll;
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
            else
            {
                iSearchedList.Clear();
                iSelectedRow.Clear();
            }
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            btnReadBottom.PerformClick();
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
            catch
            {
                return null;
            }
        }
    }
}
