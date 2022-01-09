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
    public partial class frmShipBarcode : POPprogram.BaseDialog
    {
        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();
        List<ShipPropertyBarcode> spb;
        public int MyProperty { get; set; }
        public frmShipBarcode()
        {
            InitializeComponent();
        }

        private void frmPrurchaseDialog_Load(object sender, EventArgs e)
        {


            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewCheckBoxColumn checkbox1 = new DataGridViewCheckBoxColumn();
            checkbox1.Name = "";
            csDataGridView1.Columns.Add(checkbox1);

            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "주문서코드", "BARCODE_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE", DataGridViewContentAlignment.MiddleLeft, 140);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "PRODUCT_TIME", DataGridViewContentAlignment.MiddleLeft, 140);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "주문수량", "LOT_QTY");

            LoadData();

        }
        public void LoadData()
        {
            spb = new List<ShipPropertyBarcode>();
            ShipServ serv = new ShipServ();
            DataTable dt = serv.GetBarcodeList();


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
            if (spb.Count==0)
            {
                MessageBox.Show("출력할 바코드 데이터를 선택하세요.");
                return;
            }
            DataTable dt = ConvertToDataTable(spb);

            XtraReport1 rpt = new XtraReport1();
            rpt.DataSource = dt;

            frmReportPreview frm = new frmReportPreview(rpt);
        }

        private void csDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(csDataGridView1.CurrentRow.Cells[""].Value) == true)
            {
                DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
                //DataTable dt2 = GetDataGridViewAsDataTable(csDataGridView1);

                ShipPropertyBarcode barcodevo = new ShipPropertyBarcode();

                if (dr.Cells["BARCODE_ID"].Value != null && dr.Cells["BARCODE_ID"].Value != DBNull.Value)
                    barcodevo.BARCODE_ID = dr.Cells["BARCODE_ID"].Value.ToString();
                if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                    barcodevo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
                if (dr.Cells["PRODUCT_NAME"].Value != null && dr.Cells["PRODUCT_NAME"].Value != DBNull.Value)
                    barcodevo.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
                if (dr.Cells["LOT_QTY"].Value != null && dr.Cells["LOT_QTY"].Value != DBNull.Value)
                    barcodevo.LOT_QTY = Convert.ToInt32(dr.Cells["LOT_QTY"].Value);
                if (dr.Cells["PRODUCT_TIME"].Value != null && dr.Cells["PRODUCT_TIME"].Value != DBNull.Value)
                    barcodevo.PRODUCT_TIME = Convert.ToDateTime(dr.Cells["PRODUCT_TIME"].Value);

                spb.Add(barcodevo);
            }
            else
            {
                DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
                //DataTable dt2 = GetDataGridViewAsDataTable(csDataGridView1);

                ShipPropertyBarcode barcodevo = new ShipPropertyBarcode();

                if (dr.Cells["BARCODE_ID"].Value != null && dr.Cells["BARCODE_ID"].Value != DBNull.Value)
                    barcodevo.BARCODE_ID = dr.Cells["BARCODE_ID"].Value.ToString();
                if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                    barcodevo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
                if (dr.Cells["PRODUCT_NAME"].Value != null && dr.Cells["PRODUCT_NAME"].Value != DBNull.Value)
                    barcodevo.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
                if (dr.Cells["LOT_QTY"].Value != null && dr.Cells["LOT_QTY"].Value != DBNull.Value)
                    barcodevo.LOT_QTY = Convert.ToInt32(dr.Cells["LOT_QTY"].Value);
                if (dr.Cells["PRODUCT_TIME"].Value != null && dr.Cells["PRODUCT_TIME"].Value != DBNull.Value)
                    barcodevo.PRODUCT_TIME = Convert.ToDateTime(dr.Cells["PRODUCT_TIME"].Value);

                int result = FindIntListVOIndex(spb, barcodevo);
                spb.RemoveAt(result);
            }
        }
        static int FindIntListVOIndex(List<ShipPropertyBarcode> list, ShipPropertyBarcode val)
        {
            if (list == null)
                return -1;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].BARCODE_ID == val.BARCODE_ID)
                    return i;
            }
            return -1;
        }

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

        }

        private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

        private void csDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (csDataGridView1.IsCurrentCellDirty)
                csDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
