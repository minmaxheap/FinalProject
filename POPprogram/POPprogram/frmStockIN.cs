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

namespace POPprogram
{
    public partial class frmStockIN : POPprogram.Base2
    {
        StockServ serv;
        DataGridViewCheckBoxColumn dgvChk = null;
        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();

        List<string> MstList = null;

        string msUserID;
        public frmStockIN()
        {
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        public string name { get; set; }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            serv = new StockServ();
            DataTable dt = serv.Purchase_warehousing(txtCode1.Text, txtSearch.Text);
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            frmPrurchaseDialog dlg = new frmPrurchaseDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow dr = dlg.SelectedRow;
                txtSearch.Text = dr.Cells["PURCHASE_ORDER_ID"].Value.ToString();
                txtCode1.Text = dr.Cells["PRODUCT_CODE"].Value.ToString();
                txtName1.Text = dr.Cells["PRODUCT_NAME"].Value.ToString();
                txtCode2.Text = dr.Cells["CUSTOMER_CODE"].Value.ToString();
                txtName2.Text = dr.Cells["CUSTOMER_NAME"].Value.ToString();
                txtCode3.Text = dr.Cells["ORDER_QTY"].Value.ToString();

            }
        }

        private void frmStockIN_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DgvChk(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 품번", "MATERIAL_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 품명", "MATERIAL_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "단위 수량", "REQUIRE_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "수량", "QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "입하 여부", "STOCK_IN_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재LOT ID", "STOCK_IN_LOT_ID", width :120);


            LoadData();
        }

        private void DgvChk(DataGridView dgv)
        {
            dgv.EndEdit();
            dgvChk = new DataGridViewCheckBoxColumn();
            dgvChk.HeaderText = " ";
            dgvChk.Name = "chk";
            dgvChk.Width = 40;

            dgv.Columns.Add(dgvChk);
        }
        private void LoadData()
        {
            serv = new StockServ();
            MstList = serv.GetStore_Code();
            MstList.Insert(0, "");
            comboBox1.ValueMember = "STORE_CODE";
            comboBox1.DisplayMember = "STORE_CODE";
            comboBox1.DataSource = MstList;

        }

        private void csDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);

                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell

                int nChkBoxWidth = 15;
                int nChkBoxHeight = 15;
                int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
                int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;

                pt.X += offsetx;
                pt.Y += offsety;

                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(csDataGridView1CheckBox_CheckedChanged);

                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }

        }
        private void csDataGridView1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            csDataGridView1.EndEdit();
            foreach (DataGridViewRow r in csDataGridView1.Rows)
            {
                r.Cells["chk"].Value = ((CheckBox)sender).Checked;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            csDataGridView1.EndEdit();
            int countQty = 0;
            int countLOT = 0;
            //List<int> countQty = new List<int>();
            foreach (DataGridViewRow row in csDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;


                if (chk != null)
                {
                    if (Convert.ToBoolean(chk.Value))
                    {
                        countQty += Convert.ToInt32(row.Cells["QTY"].Value);
                        countLOT += 1;
                    }
                }
            }

            textBox1.Text = countLOT.ToString();
            textBox2.Text = countQty.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("창고선택");
                return;
            }
            List<string> lotList = new List<string>();
            foreach (DataGridViewRow row in csDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;


                if (chk != null)
                {
                    if (Convert.ToBoolean(chk.Value))
                    {
                        lotList.Add(row.Cells["STOCK_IN_LOT_ID"].Value.ToString());
                    }
                }
            }

            if (lotList.Count < 1)
            {
                MessageBox.Show("LOTID 선택 ");
                return;
            }

            bool bResult = serv.SaveStockLot(lotList, comboBox1.SelectedValue.ToString(), msUserID);
            if (bResult)
            {
                MessageBox.Show("성공적");
                serv = new StockServ();
                DataTable dt = serv.Purchase_warehousing(txtSearch.Text, txtSearch.Text);
                csDataGridView1.DataSource = null;
                csDataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("재시도");
            }
        }

        private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = csDataGridView1[7, csDataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (iSearchedList.Count == 0)
                {
                    DataTable copy_dt = GetDataGridViewAsDataTable(csDataGridView1);
                    IEnumerable<DataRow> linq_row = null;
                    if (textBox7.Text == "")
                    {
                        csDataGridView1.DataSource = copy_dt;
                    }
                    else
                    {
                        foreach (DataRow row in copy_dt.Rows)
                        {
                            linq_row = from item in row.ItemArray
                                       where item.ToString().ToLower().Contains(textBox7.Text.ToLower())
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
        //private void DgvChk(DataGridView dgv)
        //{
        //    dgv.EndEdit();
        //    dgvChk = new DataGridViewCheckBoxColumn();
        //    dgvChk.HeaderText = " ";
        //    dgvChk.Name = "chk";
        //    dgvChk.Width = 40;

        //    dgv.Columns.Add(dgvChk);
        //}
    }
}
