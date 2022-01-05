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
    public partial class frmSalesOrder : MES_Team3.Base1_1
    {

        //public List<Bar> barlist;
        string sUserID;

        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();
        DataTable dt;
        DataTable dt_PRD;
        DataTable dt_CUST;
        public frmSalesOrder()
        {
            InitializeComponent();
            sUserID = frmLogin.userID;
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "주문일자", "ORDER_DATE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "주문서코드", "SALES_ORDER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사명", "CUSTOMER_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "주문수량", "ORDER_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "확정여부", "CONFIRM_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "출하여부", "SHIP_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            SalesOrderProperty vo = new SalesOrderProperty();
            SalesOrderPropertySch svo = new SalesOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

        }
        public void LoadData()
        {
            SalesOrderServ serv = new SalesOrderServ();
            dt = serv.GetSalesOrderList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            BSearchPanel = false;

            SalesOrderProperty vo = new SalesOrderProperty();
            SalesOrderPropertySch svo = new SalesOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

            ResetCount();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            SalesOrderProperty save = (SalesOrderProperty)pgProperty.SelectedObject;
            save.CREATE_USER_ID = sUserID;
            SalesOrderServ serv = new SalesOrderServ();
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
            //DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            //DataRow row = (DataRow)((DataRowView)dr.DataBoundItem).Row;
            //DataTable dt = row.Table.Clone();
            //dt.ImportRow(row);
            //List<SalesOrderProperty> selectedRow = Helper.DataTableMapToList<SalesOrderProperty>(dt);

            //pgProperty.SelectedObject = selectedRow[0];
            //pgProperty.PropertySort = PropertySort.NoSort;

            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            SalesOrderProperty vo = new SalesOrderProperty();
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
            if (dr.Cells["SALES_ORDER_ID"].Value != null && dr.Cells["SALES_ORDER_ID"].Value != DBNull.Value)
                vo.SALES_ORDER_ID = dr.Cells["SALES_ORDER_ID"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();

            if (dr.Cells["ORDER_QTY"].Value != null && dr.Cells["ORDER_QTY"].Value != DBNull.Value)
                vo.ORDER_QTY = Convert.ToInt32(dr.Cells["ORDER_QTY"].Value);
            if (dr.Cells["CONFIRM_FLAG"].Value != null && dr.Cells["CONFIRM_FLAG"].Value != DBNull.Value)
                vo.CONFIRM_FLAG = dr.Cells["CONFIRM_FLAG"].Value.ToString();
            if (dr.Cells["SHIP_FLAG"].Value != null && dr.Cells["SHIP_FLAG"].Value != DBNull.Value)
                vo.SHIP_FLAG = dr.Cells["SHIP_FLAG"].Value.ToString();

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

            SalesOrderProperty save = (SalesOrderProperty)pgProperty.SelectedObject;
            SalesOrderServ serv = new SalesOrderServ();
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
            SalesOrderProperty vo = new SalesOrderProperty();
            SalesOrderPropertySch svo = new SalesOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SalesOrderProperty save = (SalesOrderProperty)pgProperty.SelectedObject;
            save.UPDATE_USER_ID = sUserID;
            save.ORDER_QTY = Convert.ToInt32(save.ORDER_QTY);
            SalesOrderServ serv = new SalesOrderServ();
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
            SalesOrderPropertySch search = (SalesOrderPropertySch)pgSearch.SelectedObject;
            SalesOrderServ serv = new SalesOrderServ();
            List<SalesOrderProperty> list = serv.GetSalesOrderSearch(search);

            DataTable convertedDT = ConvertToDataTable(list);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = convertedDT;
            ResetCount();
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            SalesOrderPropertySch search = (SalesOrderPropertySch)pgSearch.SelectedObject;
            SalesOrderServ serv = new SalesOrderServ();
            List<SalesOrderProperty> list = serv.GetSalesOrderSearch(search);

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
            SalesOrderProperty vo = new SalesOrderProperty();
            SalesOrderPropertySch svo = new SalesOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SalesOrderProperty vo = new SalesOrderProperty();
            SalesOrderPropertySch svo = new SalesOrderPropertySch();

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
    }
}

