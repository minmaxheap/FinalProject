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
    public partial class frmPrurchaseDialog : POPprogram.BaseDialog
    {
        List<int> iSearchedList;
        List<int> iSelectedRow;
        public DataGridViewRow SelectedRow { get { if (dgvPurchase.SelectedRows.Count > 0) return dgvPurchase.SelectedRows[0]; else return null; } set { } }
        public frmPrurchaseDialog()
        {
            InitializeComponent();
        }

        private void frmPrurchaseDialog_Load(object sender, EventArgs e)
        {
            
            DataGridViewUtil.SetInitGridView(dgvPurchase);
            DataGridViewUtil.AddGridTextColumn(dgvPurchase, "구매 납품서 코드", "PURCHASE_ORDER_ID",width:150);
            //DataGridViewUtil.AddGridTextColumn(dgvPurchase, "고객 주문서 코드", "SALES_ORDER_ID");
            //DataGridViewUtil.AddGridTextColumn(dgvPurchase, "구매 발주 일자", "ORDER_DATE");
            DataGridViewUtil.AddGridTextColumn(dgvPurchase, "고객 코드", "CUSTOMER_CODE", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvPurchase, "고객명", "CUSTOMER_NAME", width: 150);
            //DataGridViewUtil.AddGridTextColumn(dgvPurchase, "자재 품번", "MATERIAL_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvPurchase, "품번", "PRODUCT_CODE", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvPurchase, "품명", "PRODUCT_NAME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvPurchase, "발주 수량", "ORDER_QTY");
            //DataGridViewUtil.AddGridTextColumn(dgvPurchase, "입하 여부", "STOCK_IN_FLAG");
            //DataGridViewUtil.AddGridTextColumn(dgvPurchase, "입하 창고 코드", "STOCK_IN_STORE_CODE");
            //DataGridViewUtil.AddGridTextColumn(dgvPurchase, "입하 자재 LOT ID", "STOCK_IN_LOT_ID");
            dgvPurchase.Columns["ORDER_QTY"].DefaultCellStyle.Format = "#,###,##0.##";


            iSearchedList = new List<int>();
            iSelectedRow = new List<int>();

            StockServ serv = new StockServ();
            DataTable dt = serv.GetPurchaseList();
            dgvPurchase.DataSource = null;
            dgvPurchase.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (true) //작업일자 등 유효성 검사 통과했을 때만. 아직 안 함(애초에 db에서 불러올 때 조건 만족하는 값을 가져와야겠다)
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
                DataTable copy_dt = GetDataGridViewAsDataTable(dgvPurchase);
                IEnumerable<DataRow> linq_row = null;
                if (txtSearch.Text == "")
                {
                    dgvPurchase.DataSource = copy_dt;
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
                        dgvPurchase.CurrentCell = dgvPurchase.Rows[iSearchedList[i]].Cells[0];
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
