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
    public partial class frmOperation : MES_Team3.Base1_1
    {
        //public List<Bar> barlist;
        string sUserID;

        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();
        DataTable dt;
        public frmOperation()
        {
            InitializeComponent();
            sUserID = frmLogin.userID;
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정명", "OPERATION_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "불량 입력", "CHECK_DEFECT_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "검사 데이터 입력", "CHECK_INSPECT_FLAG", width: 120);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 사용", "CHECK_MATERIAL_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            OperationProperty vo = new OperationProperty();
            OperationPropertySch svo = new OperationPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

        }
        public void LoadData()
        {
            OperationServ serv = new OperationServ();
            dt = serv.GetOperationList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            BSearchPanel = false;

            OperationProperty vo = new OperationProperty();
            OperationPropertySch svo = new OperationPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

            ResetCount();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            OperationProperty save = (OperationProperty)pgProperty.SelectedObject;
            save.CREATE_USER_ID = sUserID;
            OperationServ serv = new OperationServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                LoadData();
                MessageBox.Show("생성이 성공적으로 작업되었습니다.");
            }
            else
            {
                MessageBox.Show("생성 중 문제가 발생했습니다. 다시 확인하여 주시기 바랍니다.");
            }
        }


        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
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
            if (bResult)
            {
                LoadData();
                MessageBox.Show("삭제가 성공적으로 작업되었습니다.");
            }
            else
            {
                MessageBox.Show("삭제 중 문제가 발생했습니다. 다시 확인하여 주시기 바랍니다.");
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            OperationProperty vo = new OperationProperty();
            OperationPropertySch svo = new OperationPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OperationProperty save = (OperationProperty)pgProperty.SelectedObject;
            save.UPDATE_USER_ID = sUserID;
            OperationServ serv = new OperationServ();
            bool bResult = serv.Update(save);
            if (bResult)
            {
                LoadData();
                MessageBox.Show("변경이 성공적으로 작업되었습니다.");
            }
            else
            {
                MessageBox.Show("변경 중 문제가 발생했습니다. 다시 확인하여 주시기 바랍니다.");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OperationPropertySch search = (OperationPropertySch)pgSearch.SelectedObject;
            OperationServ serv = new OperationServ();
            List<OperationProperty> list = serv.GetOperationSearch(search);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;
            ResetCount();
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            OperationPropertySch search = (OperationPropertySch)pgSearch.SelectedObject;
            OperationServ serv = new OperationServ();
            List<OperationProperty> list = serv.GetOperationSearch(search);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;
            ResetCount();
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

        private void btnPanel_Click(object sender, EventArgs e)
        {
            OperationProperty vo = new OperationProperty();
            OperationPropertySch svo = new OperationPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            OperationProperty vo = new OperationProperty();
            OperationPropertySch svo = new OperationPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
        }
        private void ResetCount()
        {
            iSearchedList.Clear();
            iSelectedRow.Clear();
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

