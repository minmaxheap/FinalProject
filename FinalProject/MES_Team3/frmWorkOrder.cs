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
using VO;

namespace MES_Team3
{
    public partial class frmWorkOrder : MES_Team3.Base1_1
    {

        //public List<Bar> barlist;
        string sUserID;
        string titleName;
        public string TitleName { get { return titleName; } set { } }
        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();
        DataTable dt;
        public frmWorkOrder()
        {
            InitializeComponent();
            sUserID = frmLogin.userID;
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            titleName = frmMain.TitleName;
            lblUpTitle.Text = "   " + titleName;
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업일자", "ORDER_DATE", DataGridViewContentAlignment.MiddleLeft, 170);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업지시", "WORK_ORDER_ID",width:120);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사", "CUSTOMER_CODE", width: 160);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사명", "CUSTOMER_NAME", width: 160);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE", DataGridViewContentAlignment.MiddleLeft, 160);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME", width:120);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "지시수량", "ORDER_QTY", DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "상태", "ORDER_STATUS", DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생산수량", "PRODUCT_QTY",DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "불량수량", "DEFECT_QTY",DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업 시작시간", "WORK_START_TIME", DataGridViewContentAlignment.MiddleLeft, 170);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "마감 처리자", "WORK_CLOSE_USER_ID", width: 120);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "마감 시간", "WORK_CLOSE_TIME", DataGridViewContentAlignment.MiddleLeft, 170);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME", DataGridViewContentAlignment.MiddleLeft, 170);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID", width: 120);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME", DataGridViewContentAlignment.MiddleLeft, 170);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            csDataGridView1.Columns["ORDER_QTY"].DefaultCellStyle.Format = "#,###,##0.##";
            csDataGridView1.Columns["PRODUCT_QTY"].DefaultCellStyle.Format = "#,###,##0.##";
            csDataGridView1.Columns["DEFECT_QTY"].DefaultCellStyle.Format = "#,###,##0.##";

            LoadData();

            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

        }
        public void LoadData()
        {
            WorkOrderServ serv = new WorkOrderServ();
            dt = serv.GetWorkOrderList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            BSearchPanel = false;

            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

            ResetCount();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            save.CREATE_USER_ID = sUserID;
            WorkOrderServ serv = new WorkOrderServ();
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
            WorkOrderProperty vo = new WorkOrderProperty();
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

            if (dr.Cells["ORDER_DATE"].Value != null && dr.Cells["ORDER_DATE"].Value != DBNull.Value)
                vo.ORDER_DATE = Convert.ToDateTime(dr.Cells["ORDER_DATE"].Value);
            if (dr.Cells["WORK_ORDER_ID"].Value != null && dr.Cells["WORK_ORDER_ID"].Value != DBNull.Value)
                vo.WORK_ORDER_ID = dr.Cells["WORK_ORDER_ID"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();

            if (dr.Cells["ORDER_QTY"].Value != null && dr.Cells["ORDER_QTY"].Value != DBNull.Value)
                vo.ORDER_QTY = Convert.ToInt32(dr.Cells["ORDER_QTY"].Value);
            if (dr.Cells["ORDER_STATUS"].Value != null && dr.Cells["ORDER_STATUS"].Value != DBNull.Value)
                vo.ORDER_STATUS = dr.Cells["ORDER_STATUS"].Value.ToString();
            if (dr.Cells["PRODUCT_QTY"].Value != null && dr.Cells["PRODUCT_QTY"].Value != DBNull.Value)
                vo.PRODUCT_QTY = Convert.ToInt32(dr.Cells["PRODUCT_QTY"].Value);

            if (dr.Cells["DEFECT_QTY"].Value != null && dr.Cells["DEFECT_QTY"].Value != DBNull.Value)
                vo.DEFECT_QTY = Convert.ToInt32(dr.Cells["DEFECT_QTY"].Value);
            if (dr.Cells["WORK_START_TIME"].Value != null && dr.Cells["WORK_START_TIME"].Value != DBNull.Value)
                vo.WORK_START_TIME = Convert.ToDateTime(dr.Cells["WORK_START_TIME"].Value);
            if (dr.Cells["WORK_CLOSE_USER_ID"].Value != null && dr.Cells["WORK_CLOSE_USER_ID"].Value != DBNull.Value)
                vo.WORK_CLOSE_USER_ID = dr.Cells["WORK_CLOSE_USER_ID"].Value.ToString();
            if (dr.Cells["WORK_CLOSE_TIME"].Value != null && dr.Cells["WORK_CLOSE_TIME"].Value != DBNull.Value)
                vo.WORK_CLOSE_TIME = Convert.ToDateTime(dr.Cells["WORK_CLOSE_TIME"].Value);

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

            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            WorkOrderServ serv = new WorkOrderServ();
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
            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            save.UPDATE_USER_ID = sUserID;
            save.ORDER_QTY = Convert.ToInt32(save.ORDER_QTY);
            WorkOrderServ serv = new WorkOrderServ();
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
            WorkOrderPropertySch search = (WorkOrderPropertySch)pgSearch.SelectedObject;
            WorkOrderServ serv = new WorkOrderServ();
            List<WorkOrderProperty> list = serv.GetWorkOrderSearch(search);

            DataTable convertedDT = ConvertToDataTable(list);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = convertedDT;
            ResetCount();
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            WorkOrderPropertySch search = (WorkOrderPropertySch)pgSearch.SelectedObject;
            WorkOrderServ serv = new WorkOrderServ();
            List<WorkOrderProperty> list = serv.GetWorkOrderSearch(search);

            DataTable convertedDT = ConvertToDataTable(list);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = convertedDT;
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
            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
        }
        //private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (iSearchedList.Count == 0)
        //        {
        //            DataTable copy_dt = dt;
        //            IEnumerable<DataRow> linq_row = null;
        //            if (txtSearch.Text == "")
        //            {
        //                csDataGridView1.DataSource = copy_dt;
        //            }
        //            else
        //            {
        //                foreach (DataRow row in copy_dt.Rows)
        //                {
        //                    linq_row = from item in row.ItemArray
        //                               where item.ToString().ToLower().Contains(txtSearch.Text.ToLower())
        //                               select row;
        //                    foreach (DataRow dt in linq_row)
        //                    {
        //                        int iCntSearch = copy_dt.Rows.IndexOf(row);
        //                        iSearchedList.Add(iCntSearch);
        //                        DataRow dr = dtSearchedList.NewRow();
        //                        dr["Count"] = iCntSearch;
        //                        dtSearchedList.Rows.Add(dr);
        //                        break;
        //                    }
        //                }
        //                iSelectedRow = iSearchedList.ToList();
        //                dtSearchedList.AsEnumerable().CopyToDataTable(dtSelectedRow, LoadOption.Upsert);

        //            }
        //        }
        //        if (iSearchedList.Count > 0)
        //        {
        //            int iTestNum = iSelectedRow.Count(n => n == -1);
        //            if (iTestNum == iSearchedList.Count)
        //                iSelectedRow = iSearchedList.ToList();
        //            for (int i = 0; i < iSearchedList.Count; i++)
        //            {
        //                if (iSelectedRow[i] == iSearchedList[i])
        //                {
        //                    csDataGridView1.CurrentCell = csDataGridView1.Rows[iSearchedList[i]].Cells[0];
        //                    iSelectedRow[i] = -1;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        iSearchedList.Clear();
        //        iSelectedRow.Clear();
        //    }
        //}
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

        private void button1_Click(object sender, EventArgs e)
        {
            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            save.WORK_CLOSE_USER_ID = sUserID;
            WorkOrderServ serv = new WorkOrderServ();
            bool bResult = serv.WorkEnd(save);
            if (bResult)
            {
                LoadData();
                MessageBox.Show("마감이 성공적으로 등록되었습니다.");
            }
            else
            {
                MessageBox.Show("마감 중 문제가 발생했습니다. 다시 확인하여 주시기 바랍니다.");
            }
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWorkOrder_Shown(object sender, EventArgs e)
        {
            csDataGridView1.CurrentCell = null;
        }

        private void csDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in csDataGridView1.Rows)
            {
                if (row.Cells["ORDER_STATUS"].Value.ToString() == "CLOSE")
                    //row.DefaultCellStyle.BackColor = Color.DarkGray;
                    csDataGridView1.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGray;
                else if (row.Cells["ORDER_STATUS"].Value.ToString() == "PROC")
                    csDataGridView1.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                else if (row.Cells["ORDER_STATUS"].Value.ToString() == "OPEN")
                    csDataGridView1.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}

