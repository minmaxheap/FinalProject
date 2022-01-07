using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAC;

namespace POPprogram
{
    public partial class frmShipSearch : POPprogram.BaseDialog
    {
        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();
        DataTable dt;
        public static ShipProperty vo;
        bool clickFlag=false;
        public int MyProperty { get; set; }
        public frmShipSearch()
        {
            InitializeComponent();
        }

        private void frmPrurchaseDialog_Load(object sender, EventArgs e)
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

        }
        public void LoadData()
        {
            ShipServ serv = new ShipServ();
            dt = serv.GetSalesOrderList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            csDataGridView1.CurrentCell = null;
            ResetCount();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (vo!=null) 
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("다른 작업지시를 선택해주시길 바랍니다.");
            }
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
        private void ResetCount()
        {
            iSearchedList.Clear();
            iSelectedRow.Clear();
        }

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            clickFlag= true;
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            vo = new ShipProperty();
            if (dr.Cells["ORDER_DATE"].Value != null && dr.Cells["ORDER_DATE"].Value != DBNull.Value)
                vo.ORDER_DATE = Convert.ToDateTime(dr.Cells["ORDER_DATE"].Value);
            if (dr.Cells["SALES_ORDER_ID"].Value != null && dr.Cells["SALES_ORDER_ID"].Value != DBNull.Value)
                vo.SALES_ORDER_ID = dr.Cells["SALES_ORDER_ID"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["CUSTOMER_NAME"].Value != null && dr.Cells["CUSTOMER_NAME"].Value != DBNull.Value)
                vo.CUSTOMER_NAME = dr.Cells["CUSTOMER_NAME"].Value.ToString();
            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_NAME"].Value != null && dr.Cells["PRODUCT_NAME"].Value != DBNull.Value)
                vo.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
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
            if (vo != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            clickFlag = true;
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            vo = new ShipProperty();
            if (dr.Cells["ORDER_DATE"].Value != null && dr.Cells["ORDER_DATE"].Value != DBNull.Value)
                vo.ORDER_DATE = Convert.ToDateTime(dr.Cells["ORDER_DATE"].Value);
            if (dr.Cells["SALES_ORDER_ID"].Value != null && dr.Cells["SALES_ORDER_ID"].Value != DBNull.Value)
                vo.SALES_ORDER_ID = dr.Cells["SALES_ORDER_ID"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["CUSTOMER_NAME"].Value != null && dr.Cells["CUSTOMER_NAME"].Value != DBNull.Value)
                vo.CUSTOMER_NAME = dr.Cells["CUSTOMER_NAME"].Value.ToString();
            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_NAME"].Value != null && dr.Cells["PRODUCT_NAME"].Value != DBNull.Value)
                vo.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
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
        }
    }
}
