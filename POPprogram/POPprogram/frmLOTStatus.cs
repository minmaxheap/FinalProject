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
        public bool BIsSearchPanel
        {
            get { return pnlSearch.Visible; }
            set
            {
                pnlSearch.Visible = value;
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ 속성";
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
            this.WindowState = FormWindowState.Maximized;
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
                lblPanel.Text = "▶ 속성";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
                btnPanel.BackColor = lblPanel.BackColor;

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
    }
}
