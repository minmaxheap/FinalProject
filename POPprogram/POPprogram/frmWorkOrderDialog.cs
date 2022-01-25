using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmWorkOrderDialog : POPprogram.BaseDialog
    {
        List<int> iSearchedList;
        List<int> iSelectedRow;
        public DataGridViewRow SelectedRow { get { if (dgvWorkOrder.SelectedRows.Count > 0) return dgvWorkOrder.SelectedRows[0]; else return null; } set { } }
        public frmWorkOrderDialog()
        {
            InitializeComponent();
        }

        private void frmWorkOrderDialog1_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvWorkOrder);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "작업일자", "ORDER_DATE",width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "작업지시", "WORK_ORDER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "고객사", "CUSTOMER_CODE", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "고객사명", "CUSTOMER_NAME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "품번", "PRODUCT_CODE", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "품명", "PRODUCT_NAME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "공정코드", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "공정명", "OPERATION_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "ORDER_QTY");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "상태", "ORDER_STATUS");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "생산수량", "PRODUCT_QTY");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "불량수량", "DEFECT_QTY");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "작업 시작시간", "WORK_START_TIME");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "마감 처리자", "WORK_CLOSE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "마감 시간", "WORK_CLOSE_TIME");

            dgvWorkOrder.Columns["ORDER_QTY"].DefaultCellStyle.Format = "#,###,##0.##";
            dgvWorkOrder.Columns["PRODUCT_QTY"].DefaultCellStyle.Format = "#,###,##0.##";
            dgvWorkOrder.Columns["DEFECT_QTY"].DefaultCellStyle.Format = "#,###,##0.##";

            iSearchedList = new List<int>();
            iSelectedRow = new List<int>();

            LOTServ serv = new LOTServ();
            DataTable dt = serv.GetWorkOrderList();
            dgvWorkOrder.DataSource = null;
            dgvWorkOrder.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //애초에 db에서 불러올 때 조건 만족하는 값을 가져와야겠다
            
                this.DialogResult = DialogResult.OK;
                this.Close();

   
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            if (iSearchedList.Count == 0)
            {
                DataTable copy_dt = GetDataGridViewAsDataTable(dgvWorkOrder);
                IEnumerable<DataRow> linq_row = null;
                if (txtSearch.Text == "")
                {
                    dgvWorkOrder.DataSource = copy_dt;
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
                        dgvWorkOrder.CurrentCell = dgvWorkOrder.Rows[iSearchedList[i]].Cells[0];
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
    }
}
