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
        public bool BIsSearchPanel
        {
            get { return pnlSearch.Visible; }
            set
            {
                pnlSearch.Visible = value;
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ LOT 상태";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
                btnPanel.BackColor = lblPanel.BackColor;
            }
        }
        public frmLOTStatus()
        {
            InitializeComponent();
        }

        private void frmLOTStatus_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LOT ID", "LOT_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LOT 설명", "LOT_DESC");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "수량", "LOT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정", "OPERATION_CODE");

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
            DataGridViewUtil.AddGridTextColumn(csDataGridView2, "작업 시작 여부", "START_FLAG");


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
            PanelVisible();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            PanelVisible();
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {

        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {

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
                lblPanel.BackColor = Color.FromArgb(164, 194, 229);
                btnPanel.BackColor = lblPanel.BackColor;

            }
            else
            {
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ LOT 상태";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
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

        }

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string lotID = csDataGridView1["LOT_ID", e.RowIndex].Value.ToString();

            LOTServ serv = new LOTServ();
            DataTable dtHis = serv.GetLOTHistory(lotID);
           List<LOTProperty> list = serv.GetLOTStatus(lotID);

            csDataGridView2.DataSource = dtHis;
            if(list.Count>0) pgProperty.SelectedObject = list[0];
       
        }
    }
}
