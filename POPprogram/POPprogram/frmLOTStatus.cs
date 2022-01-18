using DAC;
using POPprogram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmLOTStatus : Form
    {
        DataTable mdtAll;
        List<int> iSearchedList;
        List<int> iSelectedRow;
        string titleName;
        public string TitleName { get { return titleName; } set { } }
        public bool BIsSearchPanel
        {
            get { return pnlSearch.Visible; }
            set
            {
                pnlSearch.Visible = value;
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ LOT 상태";
                lblPanel.BackColor = Color.FromArgb(225, 241, 255); 
                btnPanel.BackColor = lblPanel.BackColor;
            }
        }
        public frmLOTStatus()
        {
            InitializeComponent();
            
        }

        private void frmLOTStatus_Load(object sender, EventArgs e)
        {
            titleName = frmMain.TitleName;
            lblUpTitle.Text = "   " + titleName;
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LOT ID", "LOT_ID",width:150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LOT 설명", "LOT_DESC", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "수량", "LOT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정", "OPERATION_CODE");

            csDataGridView1.Columns["LOT_QTY"].DefaultCellStyle.Format = "#,###,##0.##";

            iSearchedList = new List<int>();
            iSelectedRow = new List<int>();

            LoadData();


            LOTProperty pr = new LOTProperty();
            pgProperty.SelectedObject = pr;

            pgProperty.PropertySort = PropertySort.NoSort;

            BIsSearchPanel = false;

            LOTSearchProperty ps = new LOTSearchProperty();
            pgSearch.SelectedObject = ps;

            pgSearch.PropertySort = PropertySort.NoSort;

            DataGridViewUtil.SetInitGridView(csDataGridView2);
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "이력 순번", "HIST_SEQ");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "처리 시간", "TRAN_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "처리 코드", "TRAN_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "공정", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "공정명", "OPERATION_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "수량", "LOT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "작업 시작 여부", "START_FLAG",width:120);
            csDataGridView2.Columns["LOT_QTY"].DefaultCellStyle.Format = "#,###,##0.##";

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
        private void btnSearchPnl_Click(object sender, EventArgs e)
        {
            LOTProperty lot = new LOTProperty();
            LOTSearchProperty ps = new LOTSearchProperty();

            pgProperty.SelectedObject = lot;
            pgSearch.SelectedObject = ps;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
            PanelVisible();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            LOTProperty lot = new LOTProperty();
            LOTSearchProperty ps = new LOTSearchProperty();

            pgProperty.SelectedObject = lot;
            pgSearch.SelectedObject = ps;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
            ResetCount();
            PanelVisible();
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            btnReadBottom.PerformClick();
        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {
            if (pgSearch.SelectedObject != null)
            {
                LOTSearchProperty search = (LOTSearchProperty)pgSearch.SelectedObject;
                LOTServ serv = new LOTServ();
                DataTable dt = serv.GetLOTSearch(search);
                csDataGridView1.DataSource = null;
                csDataGridView1.DataSource = dt;
                ResetCount();
            }
          
        }

        private void LoadData()
        {
            LOTServ serv = new LOTServ();
            mdtAll = serv.GetLOTAllList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = mdtAll;
            csDataGridView1.Focus();
            // BSearchPanel = false; 
            ResetCount();
        }

        private void ResetCount()
        {
            iSearchedList.Clear();
            iSelectedRow.Clear();
        }
        private void PanelVisible()
        {
            if (pnlProperty.Visible)
            {
                pnlProperty.Visible = false;
                pnlSearch.Visible = true;
                lblPanel.Text = "▶ 검색 조건";
                lblPanel.BackColor = Color.FromArgb(230, 244, 241); //230, 244, 241 //187, 187, 187
                btnPanel.BackColor = lblPanel.BackColor;

            }
            else
            {
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ LOT 상태";
                lblPanel.BackColor = Color.FromArgb(225, 241, 255); //125, 125, 125
                btnPanel.BackColor = lblPanel.BackColor;

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

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string lotID = csDataGridView1["LOT_ID", e.RowIndex].Value.ToString();

            LOTServ serv = new LOTServ();
            if (csDataGridView1["OPERATION_CODE", e.RowIndex].Value != null)
            {
               
                if (lotID.Split('-')[1] == "PD")
                {
                    DataTable dtHis = serv.GetLOTHistory(lotID);
                    List<LOTProperty> list = serv.GetLOTStatus(lotID);

                    csDataGridView2.DataSource = null;
                    csDataGridView2.DataSource = dtHis;
                    if (list.Count > 0) pgProperty.SelectedObject = list[0];
                }
                else 
                {
                    DataTable dtHis = serv.GetMaterialLOTHistory(lotID);
                    List<LOTProperty> list = serv.GetLOTStatus(lotID);

                    csDataGridView2.DataSource = null;
                    csDataGridView2.DataSource = dtHis;
                    if (list.Count > 0) pgProperty.SelectedObject = list[0];
                }
            }
          
       
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLOTStatus_Activated(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////
            foreach (Control ctl1 in this.Controls)
            {
                foreach (Control ctl2 in this.Controls[this.Controls.IndexOf(ctl1)].Controls)
                    if (typeof(TextBox) == ctl2.GetType())
                    {
                        ctl2.Text = null;
                    }
                    else if (typeof(ComboBox) == ctl2.GetType())
                    {
                        ComboBox dd = (ComboBox)ctl2;
                        if (dd != null)
                        {
                            dd.Text = string.Empty;
                            dd.SelectedIndex = -1;
                        }
                    }
                    else if (typeof(csDataGridView) == ctl2.GetType())
                    {
                        csDataGridView dd = (csDataGridView)ctl2;
                        if (dd != null)
                        {
                            dd.DataSource = null;
                        }
                    }
            }
            ////////////////////////////////////////////////////////////////////////////
            LoadData();
        }
    }
}
